using API;
using API.Database.DuckSoup;
using API.ServiceFactory;
using DuckSoup.Library.Server;
using PacketLibrary.Handler;

namespace DuckSoup.Agent;

public class VSRO188_AgentServer : FakeServer
{
    private readonly ISharedObjects _sharedObjects;

    public VSRO188_AgentServer(Service service) : base(service)
    {
        _sharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        PacketHandler.RegisterModuleHandler<SERVER_MOVEMENT>(SERVER_MOVEMENT);
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
        Log.Debug("Source: " + data.Movement.Source.ToString());
        Log.Debug("Destination: " + data.Movement.Destination.ToString());
        Log.Debug("---------------------");
        return data;
    }
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