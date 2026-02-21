using API.Enums;

namespace API.Webserver;

public interface IWebserverPluginRoute
{
    string Title { get; }
    string Path { get; }
    bool ShowInMenu { get; }
    string? Parent { get; }
    UserRole RequiredRole { get; }
}