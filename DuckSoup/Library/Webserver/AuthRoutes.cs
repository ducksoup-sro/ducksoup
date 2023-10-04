using System;
using System.Text.Json;
using System.Threading.Tasks;
using API.Database.DuckSoup;
using API.Enums;
using API.ServiceFactory;
using API.Services;
using API.Webserver;
using WatsonWebserver;

namespace DuckSoup.Library.Webserver;

public class AuthRoutes
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public AuthRoutes(IWebserverManager webserverManager)
    {
        _authService = ServiceFactory.Load<IAuthService>(typeof(IAuthService));
        _userService = ServiceFactory.Load<IUserService>(typeof(IUserService));

        webserverManager.addStaticRoute(HttpMethod.POST, "/api/v1/auth/login", LoginRoute);
        webserverManager.addStaticRoute(HttpMethod.POST, "/api/v1/auth/logout", LogoutRoute);
        webserverManager.addStaticRoute(HttpMethod.GET, "/api/v1/auth/invalidate", InvalidateRoute);
        webserverManager.addStaticRoute(HttpMethod.GET, "/api/v1/auth/refresh", RefreshRoute);
        webserverManager.addStaticRoute(HttpMethod.GET, "/api/v1/auth/me", UserInfoRoute);

        webserverManager.addProtectedPrefix("/api/v1/auth/login", new[] { UserRole.Anonymous });
        webserverManager.addProtectedPrefix("/api/v1/auth/logout", new[] { UserRole.Authenticated });
        webserverManager.addProtectedPrefix("/api/v1/auth/invalidate", new[] { UserRole.Authenticated });
        webserverManager.addProtectedPrefix("/api/v1/auth/refresh", new[] { UserRole.Anyone });
        webserverManager.addProtectedPrefix("/api/v1/auth/me", new[] { UserRole.Authenticated });
    }

    private async Task UserInfoRoute(HttpContext ctx)
    {
        if (ctx.Metadata is not User user)
        {
            ctx.Response.StatusCode = 401;
            await ctx.Response.Send();
            return;
        }

        ctx.Response.StatusCode = 200;
        await ctx.Response.Send(JsonSerializer.Serialize(user));
    }

    private async Task RefreshRoute(HttpContext ctx)
    {
        var hasCookie = ctx.Request.HeaderExists("Cookie");
        if (!hasCookie)
        {
            ctx.Response.StatusCode = 401;
            await ctx.Response.Send();
            return;
        }

        var cookies = ctx.Request.Headers["Cookie"].Split(";");
        string refreshToken = null;
        foreach (var cookie in cookies)
        {
            var split = cookie.Split("=");
            if (split.Length != 2) continue;

            if (!split[0].Equals("refresh_token")) continue;

            refreshToken = split[1];
            break;
        }

        if (refreshToken == null)
        {
            ctx.Response.StatusCode = 401;
            await ctx.Response.Send();
            return;
        }

        var refreshPayload = _authService.CheckRefreshToken(refreshToken);
        if (refreshPayload == null)
        {
            ctx.Response.StatusCode = 401;
            await ctx.Response.Send();
            return;
        }

        var user = _userService.GetUser(refreshPayload.aud);
        if (user == null || user.tokenVersion != refreshPayload.version)
        {
            ctx.Response.StatusCode = 401;
            await ctx.Response.Send();
            return;
        }

        var accessToken = _authService.GenerateAccessToken(user);

        ctx.Response.StatusCode = 200;
        await ctx.Response.Send("{ \"access_token\": \"" + accessToken + "\"}");
    }

    private async Task InvalidateRoute(HttpContext ctx)
    {
        if (ctx.Metadata is not User user)
        {
            ctx.Response.StatusCode = 401;
            await ctx.Response.Send();
            return;
        }

        user.tokenVersion += 1;
        _userService.AddUser(user);

        var accessToken = _authService.GenerateAccessToken(user);
        var refreshToken = _authService.GenerateRefreshToken(user);

        // TODO :: probably should enable secure if https is available
        // ctx.Response.Headers["Set-Cookie"] = $"refresh_token={refreshToken};Secure; HttpOnly";
        ctx.Response.Headers["Set-Cookie"] = $"refresh_token={refreshToken}; HttpOnly";
        ctx.Response.StatusCode = 200;
        await ctx.Response.Send("{ \"access_token\": \"" + accessToken + "\"}");
    }

    private async Task LogoutRoute(HttpContext ctx)
    {
        if (ctx.Metadata is not User)
        {
            ctx.Response.StatusCode = 401;
            await ctx.Response.Send();
            return;
        }

        // TODO :: probably should enable secure if https is available
        // ctx.Response.Headers["Set-Cookie"] = $"refresh_token=deleted;Secure; HttpOnly; expires=Thu, 01 Jan 1970 00:00:00 GMT";
        ctx.Response.Headers["Set-Cookie"] = "refresh_token=deleted; HttpOnly; expires=Thu, 01 Jan 1970 00:00:00 GMT";
        ctx.Response.StatusCode = 200;
        await ctx.Response.Send("{ \"status\": \"ok\"}");
    }

    private async Task LoginRoute(HttpContext ctx)
    {
        LoginRequest req;
        try
        {
            req = ctx.Request.DataAsJsonObject<LoginRequest>();

            if (req == null || req.Username == null || req.Password == null ||
                req.Username.Replace(" ", "").Length == 0 ||
                req.Password.Replace(" ", "").Length == 0)
            {
                ctx.Response.StatusCode = 400;
                await ctx.Response.Send();
                return;
            }
        }
        catch (Exception)
        {
            ctx.Response.StatusCode = 400;
            await ctx.Response.Send();
            return;
        }

        var user = _userService.GetUser(req.Username);
        if (user == null)
        {
            ctx.Response.StatusCode = 400;
            await ctx.Response.Send();
            return;
        }

        if (!_userService.VerifyPassword(req.Password, user.passwordHash, user.passwordSalt))
        {
            ctx.Response.StatusCode = 400;
            await ctx.Response.Send();
            return;
        }

        var accessToken = _authService.GenerateAccessToken(user);
        var refreshToken = _authService.GenerateRefreshToken(user);

        // TODO :: probably should enable secure if https is available
        // ctx.Response.Headers["Set-Cookie"] = $"refresh_token={refreshToken};Secure; HttpOnly";
        ctx.Response.Headers["Set-Cookie"] = $"refresh_token={refreshToken}; HttpOnly";
        ctx.Response.StatusCode = 200;
        await ctx.Response.Send("{ \"access_token\": \"" + accessToken + "\"}");
    }
}

// do not make an abstract class - it will crash the serialization
internal class LoginRequest
{
    public LoginRequest(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public string Username { get; }
    public string Password { get; }
}