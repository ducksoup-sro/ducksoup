namespace API.Logging;

/// <summary>
/// Provides recent in-memory log entries for API/dashboard consumption.
/// </summary>
public interface ILogCapture
{
    /// <summary>
    /// Returns the most recent log entries (newest first).
    /// </summary>
    /// <param name="limit">Max number of entries to return (e.g. 200).</param>
    /// <param name="minLevel">Optional minimum level: "Verbose", "Debug", "Information", "Warning", "Error", "Fatal".</param>
    /// <param name="source">Optional filter: "Application" (from Serilog/filter), "Interface" (from panel/API), or null for all.</param>
    IReadOnlyList<LogEntryDto> GetRecent(int limit = 200, string? minLevel = null, string? source = null);
}

/// <summary>
/// A single log entry for API serialization.
/// </summary>
public class LogEntryDto
{
    public string Timestamp { get; set; } = "";
    public string Level { get; set; } = "";
    public string Message { get; set; } = "";
    public string? Exception { get; set; }
    /// <summary>Origin: "Application" (program/filter) or "Interface" (panel/API).</summary>
    public string Source { get; set; } = "Application";
}
