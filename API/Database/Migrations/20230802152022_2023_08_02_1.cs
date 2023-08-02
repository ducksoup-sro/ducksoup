using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Database.Migrations
{
    /// <inheritdoc />
    public partial class _2023_08_02_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blacklist");

            migrationBuilder.DropTable(
                name: "Whitelist");

            migrationBuilder.AddColumn<byte>(
                name: "SecurityType",
                table: "Service",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecurityType",
                table: "Service");

            migrationBuilder.CreateTable(
                name: "Blacklist",
                columns: table => new
                {
                    BlacklistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MsgId = table.Column<int>(type: "int", nullable: false),
                    ServerType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Blacklist", x => x.BlacklistId);
                });

            migrationBuilder.CreateTable(
                name: "Whitelist",
                columns: table => new
                {
                    WhitelistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MsgId = table.Column<int>(type: "int", nullable: false),
                    ServerType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Whitelist", x => x.WhitelistId);
                });
        }
    }
}
