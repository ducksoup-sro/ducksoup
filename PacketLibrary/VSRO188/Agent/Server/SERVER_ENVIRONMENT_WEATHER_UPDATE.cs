using PacketLibrary.VSRO188.Agent.Enums.Environment;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_ENVIRONMENT_WEATHER_UPDATE
public class SERVER_ENVIRONMENT_WEATHER_UPDATE : Packet
{
    public WeatherType WeatherType;
    public byte Intensity;
    
    public SERVER_ENVIRONMENT_WEATHER_UPDATE() : base(0x3809)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead(out WeatherType);
        TryRead(out Intensity);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(WeatherType);
        TryWrite(Intensity);
        return this;
    }

    public static Task<Packet> of(WeatherType weatherType, byte intensity)
    {
        return new SERVER_ENVIRONMENT_WEATHER_UPDATE
        {
            WeatherType = weatherType,
            Intensity = intensity
        }.Build();
    }
}