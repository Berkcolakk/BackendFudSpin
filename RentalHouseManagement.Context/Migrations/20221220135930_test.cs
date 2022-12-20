using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalHouseManagement.Context.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyID = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    CompanyDescription = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Identity = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: true),
                    TR = table.Column<string>(type: "text", nullable: true),
                    EN = table.Column<string>(type: "text", nullable: true),
                    CompanyID = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "Title",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CompanyID = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_Title", x => x.ID);
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
                    SecondPassword = table.Column<string>(type: "text", nullable: true),
                    TitleID = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyID = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_User_Title_TitleID",
                        column: x => x.TitleID,
                        principalTable: "Title",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_TitleID",
                table: "User",
                column: "TitleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Title");
        }
    }
}
