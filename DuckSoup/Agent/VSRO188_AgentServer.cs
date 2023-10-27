using System.Threading;
using System.Threading.Tasks;
using API;
using API.Database.DuckSoup;
using API.ServiceFactory;
using DuckSoup.Library.Server;
using DuckSoup.Library.Session;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Enums.Chat;
using PacketLibrary.VSRO188.Agent.Server;
using Serilog;
using SilkroadSecurityAPI.Message;

namespace DuckSoup.Agent;

public class VSRO188_AgentServer : FakeServer
{
    private readonly ISharedObjects _sharedObjects;

    public VSRO188_AgentServer(Service service) : base(service)
    {
        _sharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        PacketHandler.RegisterModuleHandler<SERVER_CHARACTER_DATA_BEGIN>(CHARACTER_DATA_BEGIN);
        PacketHandler.RegisterModuleHandler<SERVER_CHARACTER_DATA>(CHARACTER_DATA);
        PacketHandler.RegisterModuleHandler<SERVER_CHARACTER_DATA_END>(CHARACTER_DATA_END);
        PacketHandler.RegisterModuleHandler<SERVER_MOVEMENT>(SERVER_MOVEMENT);

    }

    private async Task<Packet> SERVER_MOVEMENT(SERVER_MOVEMENT data, ISession session)
    {
        Log.Debug("---------------------");
        // Log.Debug("X: " + data.Movement.Destination.X);        
        // Log.Debug("XOffset: " + data.Movement.Destination.XOffset);        
        // Log.Debug("XSectorOffset: " + data.Movement.Destination.XSectorOffset);     
        // Log.Debug("Y: " + data.Movement.Destination.Y);        
        // Log.Debug("YOffset: " + data.Movement.Destination.YOffset);        
        // Log.Debug("YSectorOffset: " + data.Movement.Destination.YSectorOffset);     
        // Log.Debug("RegionId: " + data.Movement.Destination.Region.Id);     
        // Log.Debug("RegionX: " + data.Movement.Destination.Region.X);
        // Log.Debug("RegionY: " + data.Movement.Destination.Region.Y);
        var distance = data.Movement.Source.DistanceTo(data.Movement.Destination);
        Log.Debug("Source: " + data.Movement.Source.ToString());
        Log.Debug("Destination: " + data.Movement.Destination.ToString());
        Log.Debug("Distance: " + distance);
        Log.Debug("---------------------");
        
        session.GetData("CharInfo", out var charInfo, new CharInfo());
        Log.Debug("walkSpeed: {0} - ETA: {1}" ,  charInfo.walkSpeed / 10f, distance / (charInfo.walkSpeed / 10f));
        Log.Debug("runSpeed: {0} - ETA: {1}" , charInfo.runSpeed / 10f, distance / (charInfo.runSpeed / 10f));
        Log.Debug("hwanSpeed: {0} - ETA: {1}" ,  charInfo.hwanSpeed / 10f, distance / (charInfo.hwanSpeed / 10f));
        Log.Debug("motionState: " + charInfo.motionState);

        Task.Run(async () =>
        {
            Thread.Sleep((int)(distance / (charInfo.walkSpeed / 10f) * 1000));
            session.SendToClient(await SERVER_CHAT_UPDATE.of(ChatType.Notice, "walk"));
        });
        
        Task.Run(async () =>
        {
            Thread.Sleep((int)(distance / (charInfo.runSpeed / 10f) * 1000));
            session.SendToClient(await SERVER_CHAT_UPDATE.of(ChatType.Notice, "run"));
        });
        
        Task.Run(async () =>
        {
            Thread.Sleep((int)(distance / (charInfo.hwanSpeed / 10f) * 1000));
            session.SendToClient(await SERVER_CHAT_UPDATE.of(ChatType.Notice, "hwan"));
        });
        
        return data;
    }

    private async Task<Packet> CHARACTER_DATA_BEGIN(SERVER_CHARACTER_DATA_BEGIN data, ISession session)
    {
        session.GetData("CharInfo", out var charInfo, new CharInfo());
        charInfo.Initialize();
        
        return data;
    }
    
    private async Task<Packet> CHARACTER_DATA(SERVER_CHARACTER_DATA data, ISession session)
    {
        session.GetData("CharInfo", out var charInfo, new CharInfo());
        charInfo.Append(data);
        data.ResultType = PacketResultType.Block;
        
        return data;
    }
    
    private async Task<Packet> CHARACTER_DATA_END(SERVER_CHARACTER_DATA_END data, ISession session)
    {
        session.GetData("CharInfo", out var charInfo, new CharInfo());
        var charPacket = charInfo.GetPacket();
        if (charPacket == null)
        {
            return data;
        }
        
        await charInfo.Read();
        await session.SendToClient(charPacket);
        charInfo.Clear();

        return data;
    }

    public override void AddSession(ISession session)
    {
        base.AddSession(session);
        _sharedObjects.AgentSessions.Add(session);
    }

    public override void RemoveSession(ISession session)
    {
        base.RemoveSession(session);
        if (_sharedObjects.AgentSessions.Contains(session)) _sharedObjects.AgentSessions.Remove(session);
    }
}