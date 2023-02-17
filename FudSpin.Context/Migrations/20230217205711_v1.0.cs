using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudSpin.Context.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpinnerMaster_User_UserID",
                table: "SpinnerMaster");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "SpinnerMaster",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_SpinnerMaster_User_UserID",
                table: "SpinnerMaster",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpinnerMaster_User_UserID",
                table: "SpinnerMaster");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "SpinnerMaster",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpinnerMaster_User_UserID",
                table: "SpinnerMaster",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
