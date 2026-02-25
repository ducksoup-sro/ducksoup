using System;
using API.Logging;
using Serilog.Core;
using Serilog.Events;

namespace DuckSoup.Library.Logging;

public sealed class LogCaptureSink : ILogEventSink
{
    private readonly LogCapture _capture;

    public LogCaptureSink(LogCapture capture)
    {
        _capture = capture ?? throw new ArgumentNullException(nameof(capture));
    }

    public void Emit(LogEvent logEvent)
    {
        var source = "Application";
        if (logEvent.Properties.TryGetValue("Source", out var sourceVal) && sourceVal is Serilog.Events.ScalarValue sv && sv.Value is string s)
            source = s;
        var dto = new LogEntryDto
        {
            Timestamp = logEvent.Timestamp.UtcDateTime.ToString("O"),
            Level = logEvent.Level.ToString(),
            Message = logEvent.RenderMessage(),
            Exception = logEvent.Exception?.ToString(),
            Source = source
        };
        _capture.Add(dto);
    }
}
