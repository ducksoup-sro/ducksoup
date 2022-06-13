namespace API.Settings;

public interface ISettingsManager : IDisposable
{
    ISettings Settings { get; }
}