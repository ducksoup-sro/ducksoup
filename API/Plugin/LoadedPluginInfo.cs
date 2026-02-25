namespace API.Plugin;

/// <summary>Loaded plugin with optional folder name (folder from which it was loaded).</summary>
public class LoadedPluginInfo
{
    public string Name { get; set; } = "";
    public string Version { get; set; } = "";
    public string Author { get; set; } = "";
    /// <summary>Folder name under plugins/ from which this plugin was loaded, or null if unknown.</summary>
    public string? Folder { get; set; }
}
