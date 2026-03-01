using API.Enums;
using API.Event;
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

    void RegisterEvent(IEvent evt, List<IWebserverPluginRoute> routes);
    Dictionary<IEvent, List<IWebserverPluginRoute>> GetRegisteredEvents();
    void UnregisterEvent(IEvent evt);

    /// <summary>Add an origin to the CORS allow list (e.g. for plugin-provided or external frontends).</summary>
    void AddAllowedOrigin(string origin);

    /// <summary>Remove an origin from the plugin-managed CORS list (default origins cannot be removed).</summary>
    void RemoveAllowedOrigin(string origin);

    /// <summary>Returns all allowed CORS origins (default + plugin-added).</summary>
    IReadOnlyList<string> GetAllowedOrigins();

    /// <summary>Returns only the origins that were added via AddAllowedOrigin (plugin/custom). These can be removed.</summary>
    IReadOnlyList<string> GetPluginAllowedOrigins();
}