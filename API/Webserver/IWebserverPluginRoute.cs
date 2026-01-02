namespace API.Webserver;

public interface IWebserverPluginRoute
{
    string Title { get; }
    string Path { get; }
    string JsPath { get; }
    bool ShowInMenu { get; }
    string? Parent { get; }
}