using API.Enums;
using API.Plugin;
using WatsonWebserver.Core;
using HttpMethod = WatsonWebserver.Core.HttpMethod;

namespace API.Webserver;

public interface IWebserverManager
{
    void Start(string hostname, int port);

    void Stop();

    void addProtectedPrefix(string path, List<UserRole> roles);

    void addProtectedPrefix(string path, UserRole[] roles);

    void addStaticRoute(HttpMethod method, string path, Func<HttpContextBase, Task> handler);

    void addStaticRoute(string path, Func<HttpContextBase, Task> handler);

    void removeStaticRoute(HttpMethod method, string path);

    void removeStaticRoute(string path);

    void addParameterRoute(HttpMethod method, string path, Func<HttpContextBase, Task> handler);

    void addParameterRoute(string path, Func<HttpContextBase, Task> handler);

    void removeParameterRoute(HttpMethod method, string path);

    void removeParameterRoute(string path);
    
    void RegisterPlugin(IPlugin plugin, List<IWebserverPluginRoute> routes);
    Dictionary<IPlugin, List<IWebserverPluginRoute>> GetRegisteredPlugins();
    void UnregisterPlugin(IPlugin plugin);
}