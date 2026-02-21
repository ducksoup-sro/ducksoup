using API.Enums;

namespace API.Webserver;

public class WebserverPluginRoute : IWebserverPluginRoute
{
    public string Title { get; set; }
    public string Path { get; set; }
    public bool ShowInMenu { get; set; }
    public string? Parent { get; set; }
    public UserRole RequiredRole { get; set; } = UserRole.Authenticated;
}