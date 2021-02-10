using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class NewLiveForMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypePlacing = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    TypeStreet = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<int>(nullable: false),
                    FlatNumber = table.Column<int>(nullable: true),
                    Floor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalcHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number1 = table.Column<float>(nullable: false),
                    Number2 = table.Column<float>(nullable: false),
                    Answer = table.Column<float>(nullable: false),
                    Operation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalendarTypeEvent",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfTypeEvent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarTypeEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maze",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maze", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Salary = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireModel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalendarEvent",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateStartEvent = table.Column<DateTime>(nullable: false),
                    DateFinishEvent = table.Column<DateTime>(nullable: false),
                    CalendarTypeEventId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarEvent_CalendarTypeEvent_CalendarTypeEventId",
                        column: x => x.CalendarTypeEventId,
                        principalTable: "CalendarTypeEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionnaireId = table.Column<long>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_QuestionnaireModel_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "QuestionnaireModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<long>(nullable: true),
                    QuestionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Answer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialUserAddress",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    AdressId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialUserAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialUserAddress_Adress_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireResultDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionnaireResultId = table.Column<long>(nullable: true),
                    AnswerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireResultDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionnaireResultDetails_Answer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialUserCalendarEvent",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    CalendarEventId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialUserCalendarEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialUserCalendarEvent_CalendarEvent_CalendarEventId",
                        column: x => x.CalendarEventId,
                        principalTable: "CalendarEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDish",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(nullable: true),
                    DishId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDish", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelRoom",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<long>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    TypeRoom = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialUser",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    WebRole = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    SupportLang = table.Column<int>(nullable: false),
                    OrganizationPositionId = table.Column<long>(nullable: true),
                    DateBlocked = table.Column<DateTime>(nullable: false),
                    EndBlocked = table.Column<DateTime>(nullable: false),
                    HotelUserIsHelperId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    OwnerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_SpecialUser_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelRoomBooking",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelRoomId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: true),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateFinish = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRoomBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelRoomBooking_HotelRoom_HotelRoomId",
                        column: x => x.HotelRoomId,
                        principalTable: "HotelRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRoomBooking_SpecialUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MazeUser",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    MazeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MazeUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MazeUser_Maze_MazeId",
                        column: x => x.MazeId,
                        principalTable: "Maze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MazeUser_SpecialUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecord",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_SpecialUser_PatientId",
                        column: x => x.PatientId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    StartWork = table.Column<DateTime>(nullable: false),
                    EndWork = table.Column<DateTime>(nullable: false),
                    SalaryDate = table.Column<int>(nullable: false),
                    OrganizationType = table.Column<int>(nullable: false),
                    OwnerId = table.Column<long>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_SpecialUser_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireRegistration",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    QuestionnaireId = table.Column<long>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireRegistration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionnaireRegistration_QuestionnaireModel_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "QuestionnaireModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionnaireRegistration_SpecialUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialUserTag",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    TagId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialUserTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialUserTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialUserTag_SpecialUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecordDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalRecordId = table.Column<long>(nullable: true),
                    DateOfExamination = table.Column<DateTime>(nullable: false),
                    ResultOfExamination = table.Column<string>(nullable: true),
                    DoctorId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecordDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecordDetail_SpecialUser_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecordDetail_MedicalRecord_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dish",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Grams = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DishType = table.Column<int>(nullable: false),
                    RestaurantId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dish_Organization_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<long>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    СustomerId = table.Column<long>(nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Organization_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_SpecialUser_СustomerId",
                        column: x => x.СustomerId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationPosition",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<long>(nullable: true),
                    PositionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationPosition_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationPosition_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireResult",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionnaireRegistrationId = table.Column<long>(nullable: true),
                    QuestionId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionnaireResult_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionnaireResult_QuestionnaireRegistration_QuestionnaireRegistrationId",
                        column: x => x.QuestionnaireRegistrationId,
                        principalTable: "QuestionnaireRegistration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationPositionCandidate",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationPositionId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationPositionCandidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationPositionCandidate_OrganizationPosition_OrganizationPositionId",
                        column: x => x.OrganizationPositionId,
                        principalTable: "OrganizationPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationPositionCandidate_SpecialUser_UserId",
                        column: x => x.UserId,
                        principalTable: "SpecialUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvent_CalendarTypeEventId",
                table: "CalendarEvent",
                column: "CalendarTypeEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_RestaurantId",
                table: "Dish",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_OwnerId",
                table: "Hotel",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_HotelId",
                table: "HotelRoom",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomBooking_HotelRoomId",
                table: "HotelRoomBooking",
                column: "HotelRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoomBooking_UserId",
                table: "HotelRoomBooking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MazeUser_MazeId",
                table: "MazeUser",
                column: "MazeId");

            migrationBuilder.CreateIndex(
                name: "IX_MazeUser_UserId",
                table: "MazeUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_PatientId",
                table: "MedicalRecord",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordDetail_DoctorId",
                table: "MedicalRecordDetail",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordDetail_MedicalRecordId",
                table: "MedicalRecordDetail",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RestaurantId",
                table: "Order",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_СustomerId",
                table: "Order",
                column: "СustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDish_DishId",
                table: "OrderDish",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDish_OrderId",
                table: "OrderDish",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_OwnerId",
                table: "Organization",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPosition_OrganizationId",
                table: "OrganizationPosition",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPosition_PositionId",
                table: "OrganizationPosition",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPositionCandidate_OrganizationPositionId",
                table: "OrganizationPositionCandidate",
                column: "OrganizationPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPositionCandidate_UserId",
                table: "OrganizationPositionCandidate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionnaireId",
                table: "Question",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_AnswerId",
                table: "QuestionAnswer",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_QuestionId",
                table: "QuestionAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireRegistration_QuestionnaireId",
                table: "QuestionnaireRegistration",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireRegistration_UserId",
                table: "QuestionnaireRegistration",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireResult_QuestionId",
                table: "QuestionnaireResult",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireResult_QuestionnaireRegistrationId",
                table: "QuestionnaireResult",
                column: "QuestionnaireRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireResultDetails_AnswerId",
                table: "QuestionnaireResultDetails",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireResultDetails_QuestionnaireResultId",
                table: "QuestionnaireResultDetails",
                column: "QuestionnaireResultId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialUser_HotelUserIsHelperId",
                table: "SpecialUser",
                column: "HotelUserIsHelperId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialUser_OrganizationPositionId",
                table: "SpecialUser",
                column: "OrganizationPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialUserAddress_AdressId",
                table: "SpecialUserAddress",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialUserAddress_UserId",
                table: "SpecialUserAddress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialUserCalendarEvent_CalendarEventId",
                table: "SpecialUserCalendarEvent",
                column: "CalendarEventId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialUserCalendarEvent_UserId",
                table: "SpecialUserCalendarEvent",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialUserTag_TagId",
                table: "SpecialUserTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialUserTag_UserId",
                table: "SpecialUserTag",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialUserAddress_SpecialUser_UserId",
                table: "SpecialUserAddress",
                column: "UserId",
                principalTable: "SpecialUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireResultDetails_QuestionnaireResult_QuestionnaireResultId",
                table: "QuestionnaireResultDetails",
                column: "QuestionnaireResultId",
                principalTable: "QuestionnaireResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialUserCalendarEvent_SpecialUser_UserId",
                table: "SpecialUserCalendarEvent",
                column: "UserId",
                principalTable: "SpecialUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Dish_DishId",
                table: "OrderDish",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDish_Order_OrderId",
                table: "OrderDish",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Hotel_HotelId",
                table: "HotelRoom",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialUser_Hotel_HotelUserIsHelperId",
                table: "SpecialUser",
                column: "HotelUserIsHelperId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialUser_OrganizationPosition_OrganizationPositionId",
                table: "SpecialUser",
                column: "OrganizationPositionId",
                principalTable: "OrganizationPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPosition_Organization_OrganizationId",
                table: "OrganizationPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_SpecialUser_OwnerId",
                table: "Hotel");

            migrationBuilder.DropTable(
                name: "CalcHistory");

            migrationBuilder.DropTable(
                name: "HotelRoomBooking");

            migrationBuilder.DropTable(
                name: "MazeUser");

            migrationBuilder.DropTable(
                name: "MedicalRecordDetail");

            migrationBuilder.DropTable(
                name: "OrderDish");

            migrationBuilder.DropTable(
                name: "OrganizationPositionCandidate");

            migrationBuilder.DropTable(
                name: "QuestionAnswer");

            migrationBuilder.DropTable(
                name: "QuestionnaireResultDetails");

            migrationBuilder.DropTable(
                name: "SpecialUserAddress");

            migrationBuilder.DropTable(
                name: "SpecialUserCalendarEvent");

            migrationBuilder.DropTable(
                name: "SpecialUserTag");

            migrationBuilder.DropTable(
                name: "HotelRoom");

            migrationBuilder.DropTable(
                name: "Maze");

            migrationBuilder.DropTable(
                name: "MedicalRecord");

            migrationBuilder.DropTable(
                name: "Dish");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "QuestionnaireResult");

            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "CalendarEvent");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "QuestionnaireRegistration");

            migrationBuilder.DropTable(
                name: "CalendarTypeEvent");

            migrationBuilder.DropTable(
                name: "QuestionnaireModel");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "SpecialUser");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "OrganizationPosition");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
