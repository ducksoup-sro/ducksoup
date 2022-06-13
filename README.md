![alt text](DuckSoup.png)

# DuckSoup

## What is DuckSoup?
DuckSoup is a C# packet filter for v188 Silkroad Online. The main focus is on quality, maintainability and stability. The base is fully written by myself with some help of friends and google. The only part I got inspired from was the PacketHandler part which has some links to Chernobyls PacketHandler.

Why is DuckSoup so special? DuckSoup does not use `.NET Framework`. It uses `.NET Core` which is by far more porefull, advanced and it can be used on Linux for some extra performance and security! Also DuckSoup is developed under the concept "quality over quantity".

## Motivation
Since florian0 released [SRO_DevKit](https://gitlab.com/florian0/sro_devkit) as a client addition, Devsome released [Silkroad Laravel](https://github.com/Devsome/silkroad-laravel) as a website for Silkroad so I thought it would be time to release a public, open source filter.  

## Requirements
### Windows Windows 7/Vista/8.1/Server 2008 R2/Server 2012 R2
- [Microsoft Visual C++ 2015 Redistributable Update 3](https://www.microsoft.com/en-us/download/details.aspx?id=52685)
- [KB2533623](https://support.microsoft.com/en-gb/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot)
> https://docs.microsoft.com/de-de/dotnet/core/install/windows?tabs=netcore31

### Windows Server 2016, 2019 and Windows 10 should be able to run netcore apps nativly.

### Linux (Ubuntu / Debian)
> $ wget https://packages.microsoft.com/config/debian/10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb
> $ sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-3.1

## Download
You can download the latest version from here [artifacts.zip](https://gitlab.com/b0ykoe/ducksoup/-/jobs/artifacts/master/download?job=build).

## SQL
```sql
CREATE DATABASE DuckSoup;

USE [SRO_VT_SHARD]
GO
/****** Object:  StoredProcedure [dbo].[_DS_GetCharId]    Script Date: 1/23/2021 5:47:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_DS_GetCharId]
	@charname varchar(50)
AS
BEGIN
	SELECT CharID FROM _Char WHERE CharName16 = @charname;
END
GO
/****** Object:  StoredProcedure [dbo].[_DS_GetRefObjCommon]    Script Date: 1/23/2021 5:47:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_DS_GetRefObjCommon]
AS
BEGIN
	SELECT * FROM _RefObjCommon
END
GO
/****** Object:  StoredProcedure [dbo].[_DS_GetRefSkill]    Script Date: 1/23/2021 5:47:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_DS_GetRefSkill]
AS
BEGIN
	SELECT * FROM _RefSkill
END
GO

USE [SRO_VT_ACCOUNT]
GO
/****** Object:  StoredProcedure [dbo].[_DS_GetNotice]    Script Date: 1/23/2021 5:47:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_DS_GetNotice]
AS
BEGIN
	SELECT * FROM _Notice
END
GO

USE [DuckSoup]
create table _CustomTitle
(
	CharId int not null,
	Title varchar(32) default null,
	Color int default 0xFFFFFF
)
go

create unique index _CustomTitle_CharId_uindex
	on _CustomTitle (CharId)
go

alter table _CustomTitle
	add constraint _CustomTitle_pk
		primary key nonclustered (CharId)
go

CREATE TABLE _RewardTime (
    CharId int,
    OverallPlaytime bigint,
    RewardedPlaytime bigint
);

GO
/****** Object:  StoredProcedure [dbo].[_DS_GetCharId]    Script Date: 1/23/2021 5:47:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_DS_GetOverallPlaytime]
	@charid int
AS
BEGIN
	IF exists (SELECT * FROM _RewardTime with (updlock,serializable) where CharId = @charid)
		BEGIN
			SELECT OverallPlaytime FROM _RewardTime WHERE CharId = @charid;
		END
	else
		BEGIN
		   SELECT 0
		END
END
GO

GO
/****** Object:  StoredProcedure [dbo].[_DS_GetCharId]    Script Date: 1/23/2021 5:47:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_DS_GetRewardedPlaytime]
	@charid int
AS
BEGIN

	IF exists (SELECT * FROM _RewardTime with (updlock,serializable) where CharId = @charid)
		BEGIN
			SELECT RewardedPlaytime FROM _RewardTime WHERE CharId = @charid;
		END
	else
		BEGIN
		   SELECT 0
		END
END
GO


GO
/****** Object:  StoredProcedure [dbo].[_DS_GetCharId]    Script Date: 1/23/2021 5:47:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_DS_UpdatePlaytime]
	@charid int,
	@overallPlaytime bigint,
	@rewardedPlaytime bigint
AS
BEGIN

	IF exists (SELECT * FROM _RewardTime with (updlock,serializable) where CharId = @charid)
		BEGIN
		   UPDATE _RewardTime SET OverallPlaytime = @overallPlaytime, RewardedPlaytime = @rewardedPlaytime WHERE CharId = @charid
		END
	else
		BEGIN
		   INSERT INTO _RewardTime (CharId, OverallPlaytime, RewardedPlaytime) VALUES (@charid, @overallPlaytime ,@rewardedPlaytime)
		END
END
GO

```

## Installation
The following steps will be the same for Windows & Linux.

Extract the folder you've just downloaded. Create at least 3 folders, one for each (Gateway, Download, Agent).

Go into each folder and open up DuckSoup.exe (or dotnet DuckSoup.dll), after that open `GlobalSettings.json`.

Set your Database settings and enter the Remote (Server) address, same as Port. Also add a Bind address, this is the IP of the filter server. Also set a Port for the component. I usually use 4000 for the Download Server, 4001 for the Gateway Server and 4002 (4003, 4004 and so on) for the Agent Servers.

Numbers for the "ServerType" option:

```
0 = None
1 = DownloadServer
2 = GatewayServer
3 = AgentServer
4 = ManagementServer
```

In the DownloadServer & AgentServer folder you dont have to do anything more.

In the GatewayServer folder you have to edit the `GatewaySettings.json`. If you want dont to remove the Captcha you can turn off "RemoveCaptcha". For that replace `  "RemoveCaptcha": true,` with `  "RemoveCaptcha": false,`. If you have any other captcha than `0` you have to replace the captcha here. Note that it only works with a static captcha.

Now you have to edit the `RedirectionRules`. There will always be a default rule you can copy & change. You should get the hang if you look at the example below.

Now all thats left is to patch your client to the filter IP and to the Gatewayport you've set in the `GatewayServer/GlobalSettings.json`

On Windows: Doubleclick the "DuckSoup.exe" in all folders
On Linux: `dotnet DuckSoup.dll` in all folders
> Hint: You might wanna use `screen` on Linux.

### Wanna use 2 Agent Servers?
Copy the `AgentServer` folder, change the Ports and IPs `GlobalSettings.json` and add a RedirectionRule in your `GatewaySettings.json` in the GatewayServer folder! Example below.

### Extras
GlobalSettings.json :
- ServerName is just a name, you can change it to whatever you like
- ServerType has a few options (0 -> None, 1-> DownloadServer, 2-> GatewayServer, 3->AgentServer, 4-> ManagementServer) 
- If your players get Disconnects you can upper the ByteLimitations 
- DebugLevel will show different stuff in log, more messages = more lag. If you set it to 7 it will show everything below it
- DebugLevel has a few options (0 -> nothing, 1 -> Fatal only, 2 -> adds Fatal, 3 -> adds Fatal, 4 -> adds Info, 5 -> adds Connections, 6 -> adds Debug, 7 Everything)
> Hint: None does absolutely nothing and ManagementServer is not ready yet

### Examples
```
  "RedirectionRules": [
    { // DownloadServer
      "RemoteAddress": "111.111.111.111", // server IP, will be hidden
      "RemotePort": 15881, // real downloadserver port (please use your port here this is a example value!)
      "RedirectAddress": "222.222.222.222", // filter IP, will be shown
      "RedirectPort": 4000 // filter port that will be redirected - please set correctly in the DownloadServer Folder (GlobalSettings.json)
    },
    { // AgentServer 1
      "RemoteAddress": "111.111.111.111", // server IP, will be hidden
      "RemotePort": 15882, // real agentserver1 port (please use your port here this is a example value!)
      "RedirectAddress": "222.222.222.222", // filter IP, will be shown
      "RedirectPort": 4002 // filter port that will be redirected - please set correctly in the AgentServer Folder (GlobalSettings.json)
    },
    { // AgentServer 2
      "RemoteAddress": "111.111.111.111", // server IP, will be hidden
      "RemotePort": 15882 , // real agentserver2 port (please use your port here this is a example value!)
      "RedirectAddress": "222.222.222.222", // filter IP, will be shown
      "RedirectPort": 4003 // filter port that will be redirected - please set correctly in the AgentServer2 Folder (GlobalSettings.json)
    }
  ],
```

## Features
- Async Server handling
- Async Database handling
- Exploit Protection
- Redirection Rules for Gateway -> Agent and Gateway -> Download

## Planned Features
- a centralized management server which handles requests regarding max IP, max hwid, synchronized actions and events
- silk per hour
- HWID restrictions
- IP restrictions
- sheduled notices (for all players & individual players)
- max plus
- plus notice
- and so on.. The basic filter stuff

## Performance
Testsystem: Dedicated Server - Ryzen 5 3600 - 64 GB Ram - 1Gbit connection
Testcase: Ghostuser connects a amount of clients and then sends all 5 seconds a movepacket on x users (configured) to the client, directly one after another. This is not a real test case, since this will NEVER happen (there isn't simply the case that those mass on packets come in at in a 1ms timeframe, as long as you're not electus!). There wont be the case that 300 clients will send movement packets at ONCE (ONCE ONCE, not with a timespan of like a few ms between them). 

Conclusion: The filter performs way better on Linux. Windows is doable and you will be able to handle more players on more cores. The higher CPU usage is good since we can handle more workload faster.

DuckSoup:
Login Test:
Windows:
1 Gateway - 2 Agent - 650 Users, CPU spiked up to 95~% (on all 12 threads), all cients connected with a noticeable amount of lag (normal delay 1.5 - 2.5 sec)

Linux:
1 Gateway - 2 Agent - 650 Users, CPU spiked up to 45~% (on all 12 threads), all clients connected with lesser noticeable amount of lag (short delay 0.5 - 1.5 sec)

Movement Packet Test:
Windows:
2 Agents 300 Users, 300 moving, CPU spiked up to 20~% (on all 12 threads), client lag 0.5 - 1 seconds
2 Agents 650 Users, 300 moving, CPU spiked up to 70~% (on all 12 threads), client lag 1.5 - 2 seconds

Linux
2 Agents 900 Users, 450 moving, CPU spiked up to 40~% (on all 12 threads), client lag 1.5 - 2 seconds

Isolines Filter (SR_PROXY)
Login Test:
1 Gateway - 1 Agent - 650 Users (actually only 325 users connected on the Agent duo to 2 Agent setup) , CPU spiked up to 65~% (first 6 threads), not all clients connected duo to a timeout issue with a big amount of lag (big delay random between 1 - 4 sec)

Movement Packet Test:
Windows
1 Agent 300 Users, (650 connected overall), 150 moving, CPU spikes up to 25~% (first 6 threads), client lag 2-3 seconds
1 Agent 300 Users, (650 connected overall), 300 moving, CPU spikes up to 60~% (first 6 threads), client lag 4-7 seconds

## Errors
Q: My Server is stuck at starting!
A: Check your Database connection, if it has no connection it won't start since its loading LauncherNews, Skills, Items from the DB.

Q: I can't connect!
A: Check your Ports.

Q: It does not redirect to the AgentServer!
A: Check if your `RedirectionRules` in your `GatewayServer/GatewaySettings.json` are correct.

Q: My client won't patch!
A: Check if your `RedirectionRules` in your `GatewayServer/GatewaySettings.json` are correct.

## Special Thanks
- qqdev
	- for the kind words, the motivation and that you helped me on my questions
- [Devsome](https://github.com/Devsome/)
	- for the kind words, the motivation and ideas
	- his Silkroad Laravel project can be found [here](https://github.com/Devsome/silkroad-laravel)
- [florian0](https://gitlab.com/florian0/)
	- for the kind words, the motivation and ideas
	- his SRO_DevKit can be found [here](https://gitlab.com/florian0/sro_devkit)
- [pushedx](https://www.elitepvpers.com/forum/members/900141-pushedx.html)
	- for the original released SilkroadSecurityAPI (originaly released [here](https://www.elitepvpers.com/forum/sro-coding-corner/1063078-c-silkroadsecurity.html)) 
- [DaxterSoul](https://www.elitepvpers.com/forum/members/1084164-daxtersoul.html)
	- for the  SilkroadDocs (can be found [here](https://github.com/DummkopfOfHachtenduden/SilkroadDoc/))
- Chernobyl
	- for the idea and the PacketHandler

## License
This code has been licensed under the *DON'T BE A DICK PUBLIC LICENSE*. For the full license text, see the
[LICENSE.txt](LICENSE.txt) file.
