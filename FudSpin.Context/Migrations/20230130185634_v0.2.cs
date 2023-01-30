using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudSpin.Context.Migrations
{
    /// <inheritdoc />
    public partial class v02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpinnerMaster",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_SpinnerMaster", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpinnerMaster_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpinnerDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SpinnerMasterID = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_SpinnerDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpinnerDetail_SpinnerMaster_SpinnerMasterID",
                        column: x => x.SpinnerMasterID,
                        principalTable: "SpinnerMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpinnerDetailSelection",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    SpinnerDetailID = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_SpinnerDetailSelection", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpinnerDetailSelection_SpinnerDetail_SpinnerDetailID",
                        column: x => x.SpinnerDetailID,
                        principalTable: "SpinnerDetail",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpinnerDetail_SpinnerMasterID",
                table: "SpinnerDetail",
                column: "SpinnerMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_SpinnerDetailSelection_SpinnerDetailID",
                table: "SpinnerDetailSelection",
                column: "SpinnerDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_SpinnerMaster_UserID",
                table: "SpinnerMaster",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpinnerDetailSelection");

            migrationBuilder.DropTable(
                name: "SpinnerDetail");

            migrationBuilder.DropTable(
                name: "SpinnerMaster");
        }
    }
}
