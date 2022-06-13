AGENT_GAME_READY
```csharp
            //
            // if (session.CurLevel > 90)
            // {
            //     long exp = Task.Run(() =>
            //         ServerManager.DatabaseManager.Database.ExecuteScalarAsync<long>(
            //             "SELECT Exp_C FROM SRO_VT_SHARD.dbo._RefLevel WHERE lvl = 90;")).Result - 1;
            //
            //     Task.Run(() =>
            //         ServerManager.DatabaseManager.Database.ExecuteAsync(
            //             "UPDATE SRO_VT_SHARD.dbo._CharSkillMastery SET Level = 90 WHERE CharID = @0 AND Level > 90;",
            //             session.Charid));
            //
            //     Task.Run(() =>
            //         ServerManager.DatabaseManager.Database.ExecuteAsync(
            //             "UPDATE SRO_VT_SHARD.dbo._Char SET ExpOffset = @0, RemainStatPoint = 267, Strength = 20, Intellect = 20, CurLevel = 90, MaxLevel = 90 WHERE CharID = @1 AND CurLevel > 90;",
            //             exp, session.Charid));
            //
            //     Task.Run(() =>
            //         ServerManager.DatabaseManager.Database.ExecuteAsync(
            //             "UPDATE SRO_VT_SHARD.dbo._GuildMember SET CharLevel = '90' WHERE CharName = @0;", exp,
            //             session.Charname));
            //
            //     Task.Run(() =>
            //         ServerManager.DatabaseManager.Database.ExecuteAsync(
            //             "INSERT INTO SR_ADDON_DB.dbo._InstantCharReloadDelivery (CharID) VALUES (@0);",
            //             session.Charid));
            // }
            //
            // // Login Notice
            // if (Settings.LoginNoticeActive && !session.WelcomeNotice)
            // {
            //     session.WelcomeNotice = true;
            //     session.SendNotice(Settings.LoginNotice);
            // }
            //
            // if (session.GM)
            // {
            //     return new PacketResult(PacketResultType.Nothing);
            // }
            //
            // if (session.HasJobState())
            // {
            //     session.IsJobbing = true;
            //     var jobPerHwid = ServerManager.AgentServers.SelectMany(agentServer => agentServer.Sessions)
            //         .Count(agentServerSession =>
            //             agentServerSession.Hwid == session.Hwid && agentServerSession.IsJobbing);
            //     var jobPerIp = ServerManager.AgentServers.SelectMany(agentServer => agentServer.Sessions)
            //         .Count(agentServerSession =>
            //             agentServerSession.ClientIp == session.ClientIp && agentServerSession.IsJobbing);
            //
            //     if (Settings.JobPerHwid != 0)
            //     {
            //         if (jobPerHwid > Settings.JobPerHwid)
            //         {
            //             session.SendNotice(Settings.JobPerHwidExceeded);
            //             Task.Delay(1000).ContinueWith(t => session.Destroy());
            //         }
            //
            //         if (jobPerIp > Settings.JobPerHwid)
            //         {
            //             var otherusername = "";
            //             foreach (var agentServerSession in ServerManager.AgentServers.SelectMany(agentServer =>
            //                 agentServer.Sessions.Where(agentServerSession =>
            //                     agentServerSession.ClientIp == session.ClientIp &&
            //                     agentServerSession.Username != session.Username && agentServerSession.IsJobbing)))
            //             {
            //                 otherusername = agentServerSession.Username;
            //             }
            //
            //             //_LogIpJobbing
            //             Task.Run(() =>
            //                 ServerManager.DatabaseManager.Database.ExecuteAsync(
            //                     "INSERT INTO SRO_VT_PROXY.dbo._LogIpJobbing VALUES (@0, @1, @2, GETDATE());",
            //                     session.Username,
            //                     otherusername, session.ClientIp));
            //         }
            //     }
            // }
            // else
            // {
            //     session.IsJobbing = false;
            // }
            //
            // if (session.HwidCheck)
            // {
            //     // Fixes permanent reapply of hwid checks
            //     return new PacketResult(PacketResultType.Nothing);
            // }
            //
            // if (Settings.HwidWhitelist.Contains(session.Username))
            // {
            //     return new PacketResult(PacketResultType.Nothing);
            // }
            //
            //
            // // if HWIDLimit is not turned off
            // if (Settings.HwidLimit != 0)
            // {
            //     var hwidcounter = ServerManager.AgentServers.Sum(agentServer =>
            //         agentServer.Sessions.Count(serverSession => serverSession.Hwid == session.Hwid));
            //
            //     if (hwidcounter == 0)
            //     {
            //         session.SendNotice(Settings.HwidEmpty);
            //         Task.Delay(1000).ContinueWith(t => session.Destroy());
            //     }
            //
            //     // hwid
            //     if (hwidcounter > Settings.HwidLimit)
            //     {
            //         session.SendNotice(Settings.HwidExceeded.Replace("%count%", Settings.HwidLimit.ToString()));
            //         Task.Delay(1000).ContinueWith(t => session.Destroy());
            //     }
            //
            //     session.HwidCheck = true;
            // }
            //
            // Task.Run(() =>
            //     ServerManager.DatabaseManager.Database.ExecuteAsync(
            //         "INSERT INTO SRO_VT_PROXY.dbo._LogHwid VALUES (@0, @1, @2, @3, @4, GETDATE());", session.Username,
            //         session.Charid, session.Charname, session.ClientIp,
            //         session.Hwid.Replace("{", "").Replace("}", "")));
```

AGENT_SIEGE_ACTION
```

            // tax percentage change
            // if (unk2 == 1 && unk3 == 1)
            // {
            //     packet.ReadUInt16();
            //     session.SendNotice(Settings.FwTaxManipulationNotice);
            //     return new PacketResult(PacketResultType.Block);
            // }

            // tax withdraw
            // if (unk2 == 2 && unk3 == 1)
            // {
            //     packet.ReadUInt64();
            //     session.SendNotice(Settings.FwWithdrawNotice);
            //     return new PacketResult(PacketResultType.Block);
            // }
```

```
 // private async Task<PacketResult> AGENT_GUILD_INVITE(Packet packet, Session session)
        // {
        //     var check = session.GetUnionMembersCount() >= Settings.GuildLimit;
        //     
        //     if (!check && Settings.GuildLimit != 1 && Settings.GuildLimit != 0)
        //         return new PacketResult(PacketResultType.Nothing);
        //     
        //     session.SendNotice(Settings.GuildLimitNotice);
        //     return new PacketResult(PacketResultType.Block);
        // }

        // private async Task<PacketResult> AGENT_GUILD_UNION_INVITE(Packet packet, Session session)
        // {
        //     var check = session.GetUnionMembersCount() >= Settings.UnionLimit;
        //     
        //     if (!check) return new PacketResult(PacketResultType.Nothing);
        //     
        //     session.SendNotice(Settings.UnionLimitNotice);
        //     return new PacketResult(PacketResultType.Block);
        // }

        // private async Task<PacketResult> AGENT_INVENTORY_ITEM_USE_SERVER(Packet packet, Session session)
        // {
        //     // var status = packet.ReadUInt8();
        //     // if (status != 1) return new PacketResult(PacketResultType.Nothing);
        //     //
        //     // packet.ReadUInt8(); // unk1
        //     // var unk2 = packet.ReadUInt16();
        //     // var unk3 = packet.ReadUInt16();
        //     //
        //     // if (unk2 == 1 && unk3 == 4301)
        //     // {
        //     //     if (session.HasJobState())
        //     //         return new PacketResult(PacketResultType.Nothing);
        //     //
        //     //     session.SendNotice(Settings.SecondPetPageReload);
        //     //
        //     //     Task.Run(() =>
        //     //         ServerManager.DatabaseManager.Database.ExecuteAsync(
        //     //             "INSERT INTO SR_ADDON_DB.dbo._InstantCharReloadDelivery (CharID) VALUES (@0);",
        //     //             session.Charid));
        //     // }
        //
        //     return new PacketResult(PacketResultType.Nothing);
        // }

        // private async Task<PacketResult> AGENT_INVENTORY_ITEM_USE_CLIENT(Packet packet, Session session)
        // {
        //      0x704C Client Use Inventory
        //      byte slot
        //      ushort itemType
        //      uint uniqueID
        //     
        //     byte slot = packet.ReadUInt8();
        //     byte type = packet.ReadUInt8();
        //     byte typeid = packet.ReadUInt8();
        //     
        //     // Reverse - slot 16 - itemType 236 - uniqueId 25 - remain 5
        //     // Global - slot 43 - itemType 237 - uniqueId 41 - remain 6
        //     /*
        //      * EVENT_RENT    - slot 37 - type 236 - typeid 25 - remain 5 (1)- packetsize 8 (4 wenn last / deathpoint)
        //      * EVENT         - slot 38 - type 236 - typeid 25 - remain 5 (1)- packetsize 8 (4 wenn last / deathpoint)
        //      * MALL          - slot 39 - type 237 - typeid 25 - remain 5 (1)- packetsize 8 (4 wenn last / deathpoint)
        //      */
        //     // reverse scrolls
        //     if (typeid != 25 || (type != 236 && type != 237)) return new PacketResult(PacketResultType.Nothing);
        //     
        //     var identifier = packet.ReadUInt8();
        //     if ((identifier == 3 || identifier == 2 || identifier == 7) &&
        //         DateTime.Now.Subtract(session.LastReverseTime).TotalSeconds > Settings.ReverseDelay)
        //     {
        //         session.LastReverseTime = DateTime.Now;
        //         return new PacketResult(PacketResultType.Nothing);
        //     }
        //     
        //     int timeleft = (int) (Settings.ReverseDelay - DateTime.Now.Subtract(session.LastReverseTime).TotalSeconds);
        //     session.SendNotice(Settings.ReverseDelayNotice.Replace("%time%", timeleft.ToString()));
        //     return new PacketResult(PacketResultType.Block);
        // }
        
         // private async Task<PacketResult> AGENT_GAME_NOTIFY(Packet packet, Session session)
        // {
        //     foreach (var agentServer in ServerManager.AgentServers)
        //     {
        //         if (session.ClientId == agentServer.Sessions.First().ClientId)
        //         {
        //             int type = packet.ReadInt8(); // 0x05 == spawn, 0x06 == kill
        //             packet.ReadInt8();
        //             var mobId = packet.ReadInt32();
        //             var mobCodename = Task.Run(() =>
        //                 ServerManager.DatabaseManager.Database.ExecuteScalarAsync<string>(
        //                     "Select CodeName128 from SRO_VT_SHARD.dbo._RefObjCommon where id = @0", mobId)).Result;
        //             switch (type)
        //             {
        //                 // spawn
        //                 case 0x05:
        //                     Task.Run(() =>
        //                         ServerManager.DatabaseManager.Database.ExecuteAsync(
        //                             "INSERT INTO SRO_VT_PROXY.dbo._LogUniqueSpawn VALUES (@0, GETDATE());",
        //                             mobCodename));
        //                     break;
        //                 // kill
        //                 case 0x06:
        //                 {
        //                     var name = packet.ReadAscii();
        //                     Task.Run(() =>
        //                         ServerManager.DatabaseManager.Database.ExecuteAsync(
        //                             "INSERT INTO SRO_VT_PROXY.dbo._LogUniqueKills VALUES (@0, @1, GETDATE());", name,
        //                             mobCodename));
        //                     break;
        //                 }
        //             }
        //         }
        //     
        //         break;
        //     }
        //
        //     return new PacketResult(PacketResultType.Nothing);
        // }

        // private async Task<PacketResult> CLIENT_QUESTMARK(Packet packet, Session session)
        // {
        //     return new PacketResult(PacketResultType.Block);
        // }
```

```csharp
 private async Task<PacketResult> AGENT_CHAT(Packet packet, Session session)
        {
            session.SendNotice(session.UniqueCharId.ToString());
            //Logger.InfoFormat("{0} - {1} - {2} - {3} - {4} - {5}", session.Charid, session.UniqueCharId, session.LatestRegionId, session.PositionX, session.PositionY, session.PositionZ);
/*
            int chat = packet.ReadUInt8();

            if (chat != 0x01)
            {
                return new PacketResult(PacketResultType.Nothing);
            }
            int xasd = packet.ReadUInt8();

            
            var text = packet.ReadAscii();
            var textParts = text.Split(' ');

            await session.SendNotice($"{textParts.Length} complete");

            if (textParts.Length < 2)
            {
                return new PacketResult(PacketResultType.Nothing);
            }

            await session.SendNotice($"0x{textParts[1]} start");

            var exploit = new Packet(0x70A7);
            exploit.WriteUInt8(byte.Parse(textParts[1]));
            await session.SendToServer(exploit);

            await session.SendNotice($"0x{textParts[1]} finish");*/

            return new PacketResult(PacketResultType.Nothing);
        }
```

```
        /*private static DateTime RoundUp(DateTime dt)
        {
            var d = TimeSpan.FromMinutes(60);
            var time = new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
            return time.Hour % 2 == 1 ? time.AddHours(1) : time;
        }*/
       
```

```
// Mainly Features
            // Login Notice
            // Item control
            //PacketHandler.RegisterClientHandler(0x704C, AGENT_INVENTORY_ITEM_USE_CLIENT);
            //PacketHandler.RegisterModuleHandler(0xB04C, AGENT_INVENTORY_ITEM_USE_SERVER);
            // Union Limit - Invite: 0x70FB
            // PacketHandler.RegisterClientHandler(0x70FB, AGENT_GUILD_UNION_INVITE);
            // Guild Limit - Invite: 0x70F3
            //PacketHandler.RegisterClientHandler(0x70F3, AGENT_GUILD_INVITE);
            // QuestHelper Mark - Unique Targetting
            //PacketHandler.RegisterClientHandler(0x7402, CLIENT_QUESTMARK);
            // Unique Logging
            //PacketHandler.RegisterModuleHandler(0x300C, AGENT_GAME_NOTIFY);
            // Premium use item thing packet
            //serverXServerEngine.PacketManager.RegisterClientHandler(0x715F, TestPackets.Handle);
            /*PacketHandler.RegisterClientHandler(0x7060, CLIENT_PARTY_CREATION_REQUEST); 
            PacketHandler.RegisterModuleHandler(0xB060, SERVER_PARTY_INVITATION_RESPONSE);
            PacketHandler.RegisterModuleHandler(0xB069, SERVER_PARTY_MATCH_CREATION_RESPONSE);
            PacketHandler.RegisterModuleHandler(0xB06B, SERVER_PARTY_MATCH_DELETE_RESPONSE)*/
                        /*PacketHandler.RegisterClientHandler(0x705A, async (packet, session) =>
            {
                Logger.Info(Utility.HexDump(packet.GetBytes()));
                return new PacketResult(PacketResultType.Nothing);
            });*/ // Character Spawn Packet
```