using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database;
using API.Database.DuckSoup;
using API.Enums;
using API.ServiceFactory;
using API.Services;
using API.Webserver;
using Serilog;
using WatsonWebserver;
using HttpMethod = WatsonWebserver.HttpMethod;

namespace DuckSoup.Library.Webserver;

public class WebserverManager : IWebserverManager
{
    private WatsonWebserver.Server _server;
    private Dictionary<string, List<UserRole>> _protectedRoutes;
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public WebserverManager()
    {
        ServiceFactory.Register<IWebserverManager>(typeof(IWebserverManager), this);
        _authService = ServiceFactory.Load<IAuthService>(typeof(IAuthService));
        _userService = ServiceFactory.Load<IUserService>(typeof(IUserService));

        Start(DatabaseHelper.GetSettingOrDefault("WebserverHost", "*"),
            int.Parse(DatabaseHelper.GetSettingOrDefault("WebserverPort", "9000")));
    }

    public void Start(string hostname, int port)
    {
        _protectedRoutes = new Dictionary<string, List<UserRole>>();
        _server = new WatsonWebserver.Server("*", port, false, DefaultRoute);
        _server.Routes.PreRouting = PreRoutingHandler;
        _server?.Start();
        Log.Information("Webserver on http://{0}:{1} started", hostname, port);
        var authRoutes = new AuthRoutes(this);
    }

    private Task<bool> PreRoutingHandler(HttpContext ctx)
    {
        if (_protectedRoutes == null)
        {
            // block access because we cannot verify if the route is legit or not
            return Task.FromResult(true);
        }

        var needsAuth = false;
        var roles = new List<UserRole>();
        foreach (var protectedRoute in _protectedRoutes.Where(protectedRoute =>
                     ctx.Request.Url.RawWithQuery.ToLower().StartsWith(protectedRoute.Key)))
        {
            roles = protectedRoute.Value;
            needsAuth = true;
        }

        if (!needsAuth)
        {
            // we can early escape because the route is not in the protected list
            return Task.FromResult(false);
        }

        User user = null;
        string accessToken = null;
        IAuthPayload payload = null;
        var hasHeader = ctx.Request.HeaderExists("Authorization");
        if (hasHeader)
        {
            var split = ctx.Request.Headers["Authorization"].Split(" ");
            if (split.Length == 2)
            {
                accessToken = split[1];
            }
        }

        if (accessToken != null)
        {
            payload = _authService.CheckAccessToken(accessToken);
            if (payload != null)
            {
                user = _userService.GetUser(payload.aud);
            }
        }
        ctx.Metadata = user;

        if (roles.Contains(UserRole.Anyone))
        {
            return Task.FromResult(false);
        }

        if (roles.Contains(UserRole.Anonymous) && (user == null || user.tokenVersion != payload.version))
        {
            return Task.FromResult(false);
        }

        if (user == null || user.tokenVersion != payload.version)
        {
            // user was not found - Unauthorized
            // could also be access token invalid
            // or if the token version changed
            ctx.Response.StatusCode = 401;
            ctx.Response.Send();
            return Task.FromResult(true);
        }

        if (roles.Contains(UserRole.Authenticated))
        {
            return Task.FromResult(false);
        }
        
        if (roles.Contains(user.Role))
        {
            return Task.FromResult(false);
        }
        
        // user was found, but has not the required roles - Forbidden
        ctx.Response.StatusCode = 403;
        ctx.Response.Send();
        return Task.FromResult(true);
    }

    public void Stop()
    {
        _server?.Stop();
        _server = null;
    }

    public void addProtectedPrefix(string path, List<UserRole> roles)
    {
        _protectedRoutes?.Add(path, roles);
    }

    public void addProtectedPrefix(string path, UserRole[] roles)
    {
        _protectedRoutes?.Add(path, roles.ToList());
    }

    public void addStaticRoute(HttpMethod method, string path, Func<HttpContext, Task> handler)
    {
        _server?.Routes.Static.Add(method, path, handler);
    }

    public void addStaticRoute(string path, Func<HttpContext, Task> handler)
    {
        addStaticRoute(HttpMethod.GET, path, handler);
    }

    public void removeStaticRoute(HttpMethod method, string path)
    {
        _server?.Routes.Static.Remove(method, path);
    }

    public void removeStaticRoute(string path)
    {
        removeStaticRoute(HttpMethod.GET, path);
    }

    public void addParameterRoute(HttpMethod method, string path, Func<HttpContext, Task> handler)
    {
        _server?.Routes.Parameter.Add(method, path, handler);
    }

    public void addParameterRoute(string path, Func<HttpContext, Task> handler)
    {
        addParameterRoute(HttpMethod.GET, path, handler);
    }

    public void removeParameterRoute(HttpMethod method, string path)
    {
        _server?.Routes.Parameter.Remove(method, path);
    }

    public void removeParameterRoute(string path)
    {
        removeParameterRoute(HttpMethod.GET, path);
    }

    static async Task DefaultRoute(HttpContext ctx)
    {
        ctx.Response.StatusCode = 200;
        await ctx.Response.Send("It works!");
    }
}