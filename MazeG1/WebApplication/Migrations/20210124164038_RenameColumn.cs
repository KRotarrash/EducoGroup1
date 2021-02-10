using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class RenameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartnerID",
                table: "SpecialUser");

            migrationBuilder.AddColumn<long>(
                name: "HusbandID",
                table: "SpecialUser",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WifeID",
                table: "SpecialUser",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Marriage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HusbandId = table.Column<long>(nullable: false),
                    WifeId = table.Column<long>(nullable: false),
                    DateStartMarriage = table.Column<DateTime>(nullable: false),
                    DateFinishMarriage = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marriage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marriage_SpecialUser_HusbandId",
                        column: x => x.HusbandId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marriage_SpecialUser_WifeId",
                        column: x => x.WifeId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marriage_HusbandId",
                table: "Marriage",
                column: "HusbandId");

            migrationBuilder.CreateIndex(
                name: "IX_Marriage_WifeId",
                table: "Marriage",
                column: "WifeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marriage");

            migrationBuilder.DropColumn(
                name: "HusbandID",
                table: "SpecialUser");

            migrationBuilder.DropColumn(
                name: "WifeID",
                table: "SpecialUser");

            migrationBuilder.AddColumn<long>(
                name: "PartnerID",
                table: "SpecialUser",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
