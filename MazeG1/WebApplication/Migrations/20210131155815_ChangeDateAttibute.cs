using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class ChangeDateAttibute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_SpecialUser_RequestSenderId",
                table: "Notification");

            migrationBuilder.AlterColumn<long>(
                name: "RequestSenderId",
                table: "Notification",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFinishMarriage",
                table: "Marriage",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFinishMarriage",
                table: "Marriage",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_SpecialUser_RequestSenderId",
                table: "Notification",
                column: "RequestSenderId",
                principalTable: "SpecialUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
