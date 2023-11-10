using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API;
using API.Database.DuckSoup;
using API.EventFactory;
using API.Extensions;
using API.ServiceFactory;
using API.Session;
using Database.VSRO188;
using Database.VSRO188.Context;
using DuckSoup.Agent.Vsro;
using DuckSoup.Library.Party;
using DuckSoup.Library.Server;
using DuckSoup.Library.Session;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PacketLibrary.Handler;
using PacketLibrary.VSRO188.Agent.Client;
using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Enums.Logout;
using PacketLibrary.VSRO188.Agent.Objects;
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
        var dataHandlers = new DataHandler(PacketHandler);
        var entityParsingHandlers = new EntityParsingHandler(PacketHandler);
        var exploitHandlers = new ExploitHandler(PacketHandler);
        var partyManagerHandlers = new PartyManagerHandlers(PacketHandler);

        PacketHandler.RegisterClientHandler<CLIENT_CHAT_REQUEST>(async (data, session) =>
        {
            var split = data.Message.ToLower().Split(' ');
            if (split.Length == 2 && split[0] == "start")
                session.GetTimerManager().Start(int.Parse(split[1]), async () => { await session.SendNotice("Test"); });

            if (split.Length == 1 && split[0] == "stop") session.GetTimerManager().Stop();

            if (split.Length == 2 && split[0] == "start2")
                session.GetCountdownManager()
                    .Start(int.Parse(split[1]), async () => { await session.SendNotice("Test"); });

            if (split.Length == 1 && split[0] == "stop2") session.GetCountdownManager().Stop();
            
            if (split.Length == 1 && split[0] == "debug") Log.Information("{0}", JsonConvert.SerializeObject(session.GetRawSessionData(), Formatting.Indented));
            
            return data;
        });
    }

    /*
    

    public void ParseSpawn(ISession session, Packet packet, bool isGroup = false)
    {
        // Credits: Mostly taken from RSBot https://github.com/SDClowen/RSBot/
        var refObjId = packet.ReadUInt32();
        if (refObjId == uint.MaxValue)
        {
            return;
        }

        // ghidra(isro client): FUN_009dd970 maybe flowers?
        if (refObjId == 0xfffffffe)
        {
            packet.ReadUInt32();
            packet.ReadUInt32();
        }

        var hasValue = SharedObjects.RefObjCommon.TryGetValue((int)refObjId, out var obj);

        if (!hasValue)
        {
            return;
        }

        switch (obj.TypeID1)
        {
            case 1:
                switch (obj.TypeID2)
                {
                    case 1:
                    {
                        var spawnedPlayer = new SpawnedPlayer(refObjId);
                        spawnedPlayer.Deserialize(packet);
                        var spawnedPlayerSession = SharedObjects.AgentSessions.FirstOrDefault(c =>
                            c.SessionData.UniqueCharId == spawnedPlayer.UniqueId);
                        if (spawnedPlayerSession == null)
                        {
                            break;
                        }

                        if (spawnedPlayerSession.TimerManager.IsStarted() &&
                            spawnedPlayerSession.TimerManager.IsBroadcast())
                        {
                            Task.Run(() =>
                            {
                                Thread.Sleep(100);
                                spawnedPlayerSession.TimerManager.Send(session);
                            });
                        }
                    }
                        break;
                    case 2: // Moveable?
                        switch (obj.TypeID3)
                        {
                            case 1:
                            {
                                var spawnedMonster = new SpawnedMonster(refObjId);
                                spawnedMonster.Deserialize(packet);
                            }
                                break;
                            case 3:
                            {
                                var spawnedCos = new SpawnedCos(refObjId);
                                spawnedCos.Deserialize(packet);
                            }
                                break;
                            case 4: // cos guard
                            {
                                var bionic = new SpawnedNpc(refObjId);
                                bionic.ParseBionicDetails(packet);
                                bionic.Deserialize(packet);

                                var guildId = packet.ReadUInt32();
                                var guildName = packet.ReadAscii();
                                break;
                            }
                            case 5:
                            {
                                var spawnedFortressStructure = new SpawnedFortressStructure(refObjId);
                                spawnedFortressStructure.Deserialize(packet);
                            }
                                break;

                            default:
                            {
                                var spawnedNpc = new SpawnedNpcNpc(refObjId);
                                spawnedNpc.ParseBionicDetails(packet);
                                spawnedNpc.Deserialize(packet);
                            }
                                break;
                        }

                        break;
                }

                break;
            case 3:
                var spawnedItem = SpawnedItem.FromPacket(packet, refObjId);
                break;

            case 4:
                var spawnedPortal = SpawnedPortal.FromPacket(packet, refObjId);
                break;
        }

        if (!isGroup)
        {
            if (obj.TypeID1 == 1 || obj.TypeID1 == 4)
            {
                packet.ReadUInt8(); // 1 = Normal, 3 = Spawning, 4 = Running
            }
            else if (obj.TypeID1 == 3)
            {
                packet.ReadUInt8(); // DropSource
                packet.ReadUInt32(); // DropUID
            }
        }
    }
     */
    
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