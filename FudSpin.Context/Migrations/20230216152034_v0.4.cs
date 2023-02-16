using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudSpin.Context.Migrations
{
    /// <inheritdoc />
    public partial class v04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParameterMaster",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    ParameterName = table.Column<string>(type: "text", nullable: false),
                    IsEditable = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_ParameterMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ParameterDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Value2 = table.Column<string>(type: "text", nullable: false),
                    Value3 = table.Column<string>(type: "text", nullable: false),
                    Value4 = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ParameterMasterID = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_ParameterDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ParameterDetail_ParameterMaster_ParameterMasterID",
                        column: x => x.ParameterMasterID,
                        principalTable: "ParameterMaster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Nationality",
                table: "User",
                column: "Nationality");

            migrationBuilder.CreateIndex(
                name: "IX_User_PlaceOfBirth",
                table: "User",
                column: "PlaceOfBirth");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterDetail_ParameterMasterID",
                table: "ParameterDetail",
                column: "ParameterMasterID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ParameterDetail_Nationality",
                table: "User",
                column: "Nationality",
                principalTable: "ParameterDetail",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_ParameterDetail_PlaceOfBirth",
                table: "User",
                column: "PlaceOfBirth",
                principalTable: "ParameterDetail",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ParameterDetail_Nationality",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ParameterDetail_PlaceOfBirth",
                table: "User");

            migrationBuilder.DropTable(
                name: "ParameterDetail");

            migrationBuilder.DropTable(
                name: "ParameterMaster");

            migrationBuilder.DropIndex(
                name: "IX_User_Nationality",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PlaceOfBirth",
                table: "User");
        }
    }
}
