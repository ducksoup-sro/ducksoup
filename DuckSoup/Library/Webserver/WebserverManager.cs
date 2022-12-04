using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API;
using API.ServiceFactory;
using API.Webserver;
using WatsonWebserver;
using HttpMethod = WatsonWebserver.HttpMethod;

namespace DuckSoup.Library.Webserver;

public class WebserverManager : IWebserverManager
{
    private WatsonWebserver.Server _server;
    private List<string> _protectedRoutes;

    public WebserverManager()
    {
        ServiceFactory.Register<IWebserverManager>(typeof(IWebserverManager), this);
        Start("0.0.0.0", 9000);
    }

    public void Start(string hostname, int port)
    {
        _protectedRoutes = new List<string>();
        _server = new WatsonWebserver.Server(hostname, port, false, DefaultRoute);
        _server.Routes.PreRouting = PreRoutingHandler;
        _server?.Start();
        Global.Logger.InfoFormat("Webserver on http://{0}:{1} started", hostname, port);
    }

    private Task<bool> PreRoutingHandler(HttpContext ctx)
    {
        var needsAuth = false;
        if (_protectedRoutes == null)
        {
            // block access because we cannot verify if the route is legit or not
            return Task.FromResult(true);
        }
        
        foreach (var unused in _protectedRoutes.Where(protectedRoute => ctx.Request.Url.RawWithQuery.ToLower().StartsWith(protectedRoute)))
        {
            needsAuth = true;
        }
        
        // TODO :: implement JWT auth

        return Task.FromResult(false); // allow the connection
    }

    public void Stop()
    {
        _server?.Stop();
        _server = null;
    }

    public void addProtectedPrefix(string path)
    {
        _protectedRoutes?.Add(path);
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