using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Database.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blacklist",
                columns: table => new
                {
                    BlacklistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MsgId = table.Column<int>(type: "int", nullable: false),
                    ServerType = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Blacklist", x => x.BlacklistId);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eventname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crontime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Event", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "GlobalSetting",
                columns: table => new
                {
                    SettingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.GlobalSetting", x => x.SettingsId);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Notice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Machine", x => x.MachineId);
                });

            migrationBuilder.CreateTable(
                name: "Whitelist",
                columns: table => new
                {
                    WhitelistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MsgId = table.Column<int>(type: "int", nullable: false),
                    ServerType = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Whitelist", x => x.WhitelistId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerType = table.Column<int>(type: "int", nullable: false),
                    RemotePort = table.Column<int>(type: "int", nullable: false),
                    BindPort = table.Column<int>(type: "int", nullable: false),
                    ByteLimitation = table.Column<int>(type: "int", nullable: false),
                    AutoStart = table.Column<bool>(type: "bit", nullable: false),
                    LocalMachineMachineId = table.Column<int>(name: "LocalMachine_MachineId", type: "int", nullable: false),
                    RemoteMachineMachineId = table.Column<int>(name: "RemoteMachine_MachineId", type: "int", nullable: false),
                    SpoofMachineMachineId = table.Column<int>(name: "SpoofMachine_MachineId", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Service", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_dbo.Service_dbo.Machine_LocalMachine_MachineId",
                        column: x => x.LocalMachineMachineId,
                        principalTable: "Machine",
                        principalColumn: "MachineId");
                    table.ForeignKey(
                        name: "FK_dbo.Service_dbo.Machine_RemoteMachine_MachineId",
                        column: x => x.RemoteMachineMachineId,
                        principalTable: "Machine",
                        principalColumn: "MachineId");
                    table.ForeignKey(
                        name: "FK_dbo.Service_dbo.Machine_SpoofMachine_MachineId",
                        column: x => x.SpoofMachineMachineId,
                        principalTable: "Machine",
                        principalColumn: "MachineId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalMachine_MachineId",
                table: "Service",
                column: "LocalMachine_MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_RemoteMachine_MachineId",
                table: "Service",
                column: "RemoteMachine_MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_SpoofMachine_MachineId",
                table: "Service",
                column: "SpoofMachine_MachineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blacklist");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "GlobalSetting");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Whitelist");

            migrationBuilder.DropTable(
                name: "Machine");
        }
    }
}
