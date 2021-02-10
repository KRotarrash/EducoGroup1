using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class AddOffice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OfficeId",
                table: "Position",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    AdressId = table.Column<long>(nullable: false),
                    OfficeType = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Office_Adress_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Office_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Position_OfficeId",
                table: "Position",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_AdressId",
                table: "Office",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_OrganizationId",
                table: "Office",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_Office_OfficeId",
                table: "Position",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_Office_OfficeId",
                table: "Position");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropIndex(
                name: "IX_Position_OfficeId",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Position");
        }
    }
}
