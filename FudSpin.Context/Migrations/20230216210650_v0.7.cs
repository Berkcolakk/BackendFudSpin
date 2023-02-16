using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudSpin.Context.Migrations
{
    /// <inheritdoc />
    public partial class v07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ParameterDetail_Nationality",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "User",
                newName: "NationalityID");

            migrationBuilder.RenameIndex(
                name: "IX_User_Nationality",
                table: "User",
                newName: "IX_User_NationalityID");

            migrationBuilder.AddColumn<Guid>(
                name: "GenderID",
                table: "User",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_GenderID",
                table: "User",
                column: "GenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ParameterDetail_GenderID",
                table: "User",
                column: "GenderID",
                principalTable: "ParameterDetail",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ParameterDetail_NationalityID",
                table: "User",
                column: "NationalityID",
                principalTable: "ParameterDetail",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ParameterDetail_GenderID",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ParameterDetail_NationalityID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_GenderID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GenderID",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "NationalityID",
                table: "User",
                newName: "Nationality");

            migrationBuilder.RenameIndex(
                name: "IX_User_NationalityID",
                table: "User",
                newName: "IX_User_Nationality");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ParameterDetail_Nationality",
                table: "User",
                column: "Nationality",
                principalTable: "ParameterDetail",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
