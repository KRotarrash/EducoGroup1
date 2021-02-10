using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class MarriageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WifeID",
                table: "SpecialUser",
                newName: "WifeId");

            migrationBuilder.RenameColumn(
                name: "HusbandID",
                table: "SpecialUser",
                newName: "HusbandId");

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    RequestSenderId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_SpecialUser_RequestSenderId",
                        column: x => x.RequestSenderId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notification_SpecialUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_RequestSenderId",
                table: "Notification",
                column: "RequestSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.RenameColumn(
                name: "WifeId",
                table: "SpecialUser",
                newName: "WifeID");

            migrationBuilder.RenameColumn(
                name: "HusbandId",
                table: "SpecialUser",
                newName: "HusbandID");
        }
    }
}
