using System.Text.RegularExpressions;
using WatsonWebserver;
using HttpMethod = WatsonWebserver.HttpMethod;

namespace API.Webserver;

public interface IWebserverManager
{
    void Start(string hostname, int port);
    void Stop();
    void addProtectedPrefix(string path);
    void addStaticRoute(HttpMethod method, string path, Func<HttpContext, Task> handler);
    void addStaticRoute(string path, Func<HttpContext, Task> handler);
    void removeStaticRoute(HttpMethod method, string path);
    void removeStaticRoute(string path);
    void addParameterRoute(HttpMethod method, string path, Func<HttpContext, Task> handler);
    void addParameterRoute(string path, Func<HttpContext, Task> handler);
    void removeParameterRoute(HttpMethod method, string path);
    void removeParameterRoute(string path);
}