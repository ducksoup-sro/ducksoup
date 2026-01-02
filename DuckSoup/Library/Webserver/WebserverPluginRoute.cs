using API.Webserver;

namespace DuckSoup.Library.Webserver;

public class WebserverPluginRoute : IWebserverPluginRoute
{
    public string Title { get; set; }
    public string Path { get; set; }
    public string JsPath { get; set; }
    public bool ShowInMenu { get; set; }
    public string? Parent { get; set; }
}