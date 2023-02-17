using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FudSpin.Context.Migrations
{
    /// <inheritdoc />
    public partial class v09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "SpinnerMaster",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "SpinnerMaster");
        }
    }
}
