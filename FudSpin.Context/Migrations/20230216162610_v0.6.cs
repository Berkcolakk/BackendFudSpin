﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudSpin.Context.Migrations
{
    /// <inheritdoc />
    public partial class v06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ParameterDetail_PlaceOfBirth",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_PlaceOfBirth",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PlaceOfBirth",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlaceOfBirth",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_User_PlaceOfBirth",
                table: "User",
                column: "PlaceOfBirth");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ParameterDetail_PlaceOfBirth",
                table: "User",
                column: "PlaceOfBirth",
                principalTable: "ParameterDetail",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
