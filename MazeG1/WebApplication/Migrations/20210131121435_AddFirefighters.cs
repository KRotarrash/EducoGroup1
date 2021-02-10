using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class AddFirefighters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingTypeSafetyAssessment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfTypeSafetyAssessment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingTypeSafetyAssessment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireInspectionSchedule",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingAdressId = table.Column<long>(nullable: false),
                    DateInspectionSchedule = table.Column<DateTime>(nullable: false),
                    FireInspectionPeriodicity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireInspectionSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireInspectionSchedule_Adress_BuildingAdressId",
                        column: x => x.BuildingAdressId,
                        principalTable: "Adress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialUserFireInspection",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialUserFireInspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialUserFireInspection_SpecialUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FireInspectionBuilding",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingAdressId = table.Column<long>(nullable: true),
                    DateInspection = table.Column<DateTime>(nullable: false),
                    BuildingTypeSafetyAssessmentId = table.Column<long>(nullable: true),
                    SpecialUserFireInspectionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireInspectionBuilding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireInspectionBuilding_Adress_BuildingAdressId",
                        column: x => x.BuildingAdressId,
                        principalTable: "Adress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FireInspectionBuilding_BuildingTypeSafetyAssessment_BuildingTypeSafetyAssessmentId",
                        column: x => x.BuildingTypeSafetyAssessmentId,
                        principalTable: "BuildingTypeSafetyAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FireInspectionBuilding_SpecialUserFireInspection_SpecialUserFireInspectionId",
                        column: x => x.SpecialUserFireInspectionId,
                        principalTable: "SpecialUserFireInspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FireInspectionBuilding_BuildingAdressId",
                table: "FireInspectionBuilding",
                column: "BuildingAdressId");

            migrationBuilder.CreateIndex(
                name: "IX_FireInspectionBuilding_BuildingTypeSafetyAssessmentId",
                table: "FireInspectionBuilding",
                column: "BuildingTypeSafetyAssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FireInspectionBuilding_SpecialUserFireInspectionId",
                table: "FireInspectionBuilding",
                column: "SpecialUserFireInspectionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FireInspectionSchedule_BuildingAdressId",
                table: "FireInspectionSchedule",
                column: "BuildingAdressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialUserFireInspection_UserId",
                table: "SpecialUserFireInspection",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FireInspectionBuilding");

            migrationBuilder.DropTable(
                name: "FireInspectionSchedule");

            migrationBuilder.DropTable(
                name: "BuildingTypeSafetyAssessment");

            migrationBuilder.DropTable(
                name: "SpecialUserFireInspection");
        }
    }
}
