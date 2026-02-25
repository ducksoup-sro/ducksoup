using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using API.Logging;

namespace DuckSoup.Library.Logging;

/// <summary>
/// In-memory log capture for dashboard/API. Keeps the last N entries.
/// </summary>
public sealed class LogCapture : ILogCapture
{
    private const int DefaultCapacity = 2000;
    private readonly ConcurrentQueue<LogEntryDto> _entries = new();
    private readonly int _capacity;
    private int _count;

    public LogCapture(int capacity = DefaultCapacity)
    {
        _capacity = capacity > 0 ? capacity : DefaultCapacity;
    }

    internal void Add(LogEntryDto entry)
    {
        _entries.Enqueue(entry);
        if (Interlocked.Increment(ref _count) > _capacity)
        {
            while (_count > _capacity && _entries.TryDequeue(out _))
                Interlocked.Decrement(ref _count);
        }
    }

    public IReadOnlyList<LogEntryDto> GetRecent(int limit = 200, string? minLevel = null, string? source = null)
    {
        var minLevelOrdinal = ParseLevel(minLevel);
        var list = new List<LogEntryDto>();
        foreach (var e in _entries)
        {
            if (minLevelOrdinal.HasValue && CompareLevel(e.Level, minLevelOrdinal.Value) < 0)
                continue;
            if (!string.IsNullOrWhiteSpace(source) && !string.Equals(e.Source ?? "Application", source.Trim(), StringComparison.OrdinalIgnoreCase))
                continue;
            list.Add(e);
        }
        var take = Math.Min(limit, list.Count);
        var start = list.Count - take;
        return list.Skip(start).Take(take).Reverse().ToList();
    }

    private static int LevelOrdinal(string level)
    {
        return level?.ToUpperInvariant() switch
        {
            "VERBOSE" => 0,
            "DEBUG" => 1,
            "INFORMATION" or "INFO" => 2,
            "WARNING" or "WARN" => 3,
            "ERROR" => 4,
            "FATAL" => 5,
            _ => 2
        };
    }

    private static int? ParseLevel(string? minLevel)
    {
        if (string.IsNullOrWhiteSpace(minLevel)) return null;
        return LevelOrdinal(minLevel.Trim());
    }

    private static int CompareLevel(string level, int minOrdinal)
    {
        return LevelOrdinal(level).CompareTo(minOrdinal);
    }
}
