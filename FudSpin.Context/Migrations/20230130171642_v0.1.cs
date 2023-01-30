using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudSpin.Context.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Lang = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CrtIPAddress = table.Column<string>(type: "text", nullable: true),
                    CrtUserID = table.Column<Guid>(type: "uuid", nullable: false),
                    CrtDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdIPAddress = table.Column<string>(type: "text", nullable: true),
                    UpdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdUserID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Identity = table.Column<string>(type: "text", nullable: true),
                    Language = table.Column<string>(type: "text", nullable: true),
                    PlaceOfBirth = table.Column<Guid>(type: "uuid", nullable: false),
                    Nationality = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NameSurname = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CrtIPAddress = table.Column<string>(type: "text", nullable: true),
                    CrtUserID = table.Column<Guid>(type: "uuid", nullable: false),
                    CrtDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdIPAddress = table.Column<string>(type: "text", nullable: true),
                    UpdDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdUserID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
