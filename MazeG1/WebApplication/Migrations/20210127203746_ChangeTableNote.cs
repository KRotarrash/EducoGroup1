using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class ChangeTableNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_SpecialUser_RequestSenderId",
                table: "Notification");

            migrationBuilder.AlterColumn<long>(
                name: "RequestSenderId",
                table: "Notification",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_SpecialUser_RequestSenderId",
                table: "Notification",
                column: "RequestSenderId",
                principalTable: "SpecialUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_SpecialUser_RequestSenderId",
                table: "Notification");

            migrationBuilder.AlterColumn<long>(
                name: "RequestSenderId",
                table: "Notification",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_SpecialUser_RequestSenderId",
                table: "Notification",
                column: "RequestSenderId",
                principalTable: "SpecialUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
