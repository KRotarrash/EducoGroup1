using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class RenameToCurrentWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialUser_OrganizationPosition_OrganizationPositionId",
                table: "SpecialUser");

            migrationBuilder.DropIndex(
                name: "IX_SpecialUser_OrganizationPositionId",
                table: "SpecialUser");

            migrationBuilder.DropColumn(
                name: "OrganizationPositionId",
                table: "SpecialUser");

            migrationBuilder.AddColumn<long>(
                name: "CurrentWorkId",
                table: "SpecialUser",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialUser_CurrentWorkId",
                table: "SpecialUser",
                column: "CurrentWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialUser_OrganizationPosition_CurrentWorkId",
                table: "SpecialUser",
                column: "CurrentWorkId",
                principalTable: "OrganizationPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialUser_OrganizationPosition_CurrentWorkId",
                table: "SpecialUser");

            migrationBuilder.DropIndex(
                name: "IX_SpecialUser_CurrentWorkId",
                table: "SpecialUser");

            migrationBuilder.DropColumn(
                name: "CurrentWorkId",
                table: "SpecialUser");

            migrationBuilder.AddColumn<long>(
                name: "OrganizationPositionId",
                table: "SpecialUser",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialUser_OrganizationPositionId",
                table: "SpecialUser",
                column: "OrganizationPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialUser_OrganizationPosition_OrganizationPositionId",
                table: "SpecialUser",
                column: "OrganizationPositionId",
                principalTable: "OrganizationPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
