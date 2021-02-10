using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class NewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HusbandId",
                table: "SpecialUser");

            migrationBuilder.DropColumn(
                name: "WifeId",
                table: "SpecialUser");

            migrationBuilder.AddColumn<long>(
                name: "PartnerId",
                table: "SpecialUser",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "SpecialUser");

            migrationBuilder.AddColumn<long>(
                name: "HusbandId",
                table: "SpecialUser",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WifeId",
                table: "SpecialUser",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
