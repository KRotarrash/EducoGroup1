﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication.DbStuff;

namespace WebApplication.Migrations
{
    [DbContext(typeof(WebContext))]
    [Migration("20210124162213_MarriageTable")]
    partial class MarriageTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication.DbStuff.Institutions.Dish", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DishType")
                        .HasColumnType("int");

                    b.Property<int>("Grams")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<long?>("RestaurantId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Dish");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Institutions.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long?>("RestaurantId")
                        .HasColumnType("bigint");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<long?>("СustomerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("СustomerId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Institutions.OrderDish", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("DishId")
                        .HasColumnType("bigint");

                    b.Property<long?>("OrderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDish");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Adress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FlatNumber")
                        .HasColumnType("int");

                    b.Property<int?>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypePlacing")
                        .HasColumnType("int");

                    b.Property<int>("TypeStreet")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.CalcHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Answer")
                        .HasColumnType("real");

                    b.Property<float>("Number1")
                        .HasColumnType("real");

                    b.Property<float>("Number2")
                        .HasColumnType("real");

                    b.Property<int>("Operation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CalcHistory");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Calendar.CalendarEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CalendarTypeEventId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateFinishEvent")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStartEvent")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CalendarTypeEventId");

                    b.ToTable("CalendarEvent");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Calendar.CalendarTypeEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameOfTypeEvent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CalendarTypeEvent");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Calendar.SpecialUserCalendarEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CalendarEventId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CalendarEventId");

                    b.HasIndex("UserId");

                    b.ToTable("SpecialUserCalendarEvent");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Hospital.MedicalRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("PatientId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("MedicalRecord");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Hospital.MedicalRecordDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfExamination")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("MedicalRecordId")
                        .HasColumnType("bigint");

                    b.Property<string>("ResultOfExamination")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("MedicalRecordId");

                    b.ToTable("MedicalRecordDetail");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Hotels.Hotel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OwnerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Hotels.HotelRoom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<long>("HotelId")
                        .HasColumnType("bigint");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("TypeRoom")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRoom");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Hotels.HotelRoomBooking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFinish")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<long>("HotelRoomId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("HotelRoomId");

                    b.HasIndex("UserId");

                    b.ToTable("HotelRoomBooking");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Job.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndWork")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationType")
                        .HasColumnType("int");

                    b.Property<long?>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<int>("SalaryDate")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartWork")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Organization");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Organization");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Job.OrganizationPosition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("OrganizationId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PositionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("PositionId");

                    b.ToTable("OrganizationPosition");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Job.OrganizationPositionCandidate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("OrganizationPositionId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationPositionId");

                    b.HasIndex("UserId");

                    b.ToTable("OrganizationPositionCandidate");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Job.Position", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Maze", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Maze");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.MazeUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("MazeId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MazeId");

                    b.HasIndex("UserId");

                    b.ToTable("MazeUser");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Questionnaire.Answer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Questionnaire.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("QuestionnaireId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionnaireId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Questionnaire.QuestionAnswer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AnswerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("QuestionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionAnswer");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Questionnaire.QuestionnaireModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuestionnaireModel");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Questionnaire.QuestionnaireRegistration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long?>("QuestionnaireId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("QuestionnaireId");

                    b.HasIndex("UserId");

                    b.ToTable("QuestionnaireRegistration");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Questionnaire.QuestionnaireResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<long?>("QuestionnaireRegistrationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuestionnaireRegistrationId");

                    b.ToTable("QuestionnaireResult");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Questionnaire.QuestionnaireResultDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AnswerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("QuestionnaireResultId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionnaireResultId");

                    b.ToTable("QuestionnaireResultDetails");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.SpecialUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<long?>("CurrentWorkId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateBlocked")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndBlocked")
                        .HasColumnType("datetime2");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<long?>("HotelUserIsHelperId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<long>("PartnerID")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupportLang")
                        .HasColumnType("int");

                    b.Property<int>("WebRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentWorkId");

                    b.HasIndex("HotelUserIsHelperId");

                    b.ToTable("SpecialUser");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.SpecialUserAddress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AdressId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.HasIndex("UserId");

                    b.ToTable("SpecialUserAddress");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.SpecialUserTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("TagId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("UserId");

                    b.ToTable("SpecialUserTag");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Institutions.Police", b =>
                {
                    b.HasBaseType("WebApplication.DbStuff.Model.Job.Organization");

                    b.HasDiscriminator().HasValue("Police");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Institutions.Restaurant", b =>
                {
                    b.HasBaseType("WebApplication.DbStuff.Model.Job.Organization");

                    b.HasDiscriminator().HasValue("Restaurant");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Institutions.Dish", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Institutions.Restaurant", "Restaurant")
                        .WithMany("Dishes")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("WebApplication.DbStuff.Institutions.Order", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Institutions.Restaurant", "Restaurant")
                        .WithMany("Orders")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication.DbStuff.Model.SpecialUser", "Сustomer")
                        .WithMany("Orders")
                        .HasForeignKey("СustomerId");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Institutions.OrderDish", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Institutions.Dish", "Dish")
                        .WithMany("Orders")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication.DbStuff.Institutions.Order", "Order")
                        .WithMany("Dishes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Calendar.CalendarEvent", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Calendar.CalendarTypeEvent", "CalendarTypeEvent")
                        .WithMany("CalendarEvents")
                        .HasForeignKey("CalendarTypeEventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Calendar.SpecialUserCalendarEvent", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Calendar.CalendarEvent", "CalendarEvent")
                        .WithMany("SeenCalendarEventByUsers")
                        .HasForeignKey("CalendarEventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication.DbStuff.Model.SpecialUser", "User")
                        .WithMany("SeenCalendarEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Hospital.MedicalRecord", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.SpecialUser", "Patient")
                        .WithOne("MedicalRecord")
                        .HasForeignKey("WebApplication.DbStuff.Model.Hospital.MedicalRecord", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Hospital.MedicalRecordDetail", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.SpecialUser", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("WebApplication.DbStuff.Model.Hospital.MedicalRecord", "MedicalRecord")
                        .WithMany("Examinations")
                        .HasForeignKey("MedicalRecordId");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Hotels.Hotel", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.SpecialUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Hotels.HotelRoom", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Hotels.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Hotels.HotelRoomBooking", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Hotels.HotelRoom", "HotelRoom")
                        .WithMany("Bookings")
                        .HasForeignKey("HotelRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.DbStuff.Model.SpecialUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Job.Organization", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.SpecialUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Job.OrganizationPosition", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Job.Organization", "Organization")
                        .WithMany("OrganizationPositions")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication.DbStuff.Model.Job.Position", "Position")
                        .WithMany("OrganizationPositions")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Job.OrganizationPositionCandidate", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Job.OrganizationPosition", "OrganizationPosition")
                        .WithMany("Candidates")
                        .HasForeignKey("OrganizationPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.DbStuff.Model.SpecialUser", "User")
                        .WithMany("Vacancies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.MazeUser", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Maze", "Maze")
                        .WithMany("Gamers")
                        .HasForeignKey("MazeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication.DbStuff.Model.SpecialUser", "User")
                        .WithMany("MyMazes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Questionnaire.Question", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Questionnaire.QuestionnaireModel", "Questionnaire")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionnaireId");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Questionnaire.QuestionAnswer", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Questionnaire.Answer", "Answer")
                        .WithMany("Questions")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication.DbStuff.Model.Questionnaire.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Questionnaire.QuestionnaireRegistration", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Questionnaire.QuestionnaireModel", "Questionnaire")
                        .WithMany("Registrations")
                        .HasForeignKey("QuestionnaireId");

                    b.HasOne("WebApplication.DbStuff.Model.SpecialUser", "User")
                        .WithMany("QuestionnaireRegistrations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Questionnaire.QuestionnaireResult", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Questionnaire.Question", "Question")
                        .WithMany("QuestionnaireResults")
                        .HasForeignKey("QuestionId");

                    b.HasOne("WebApplication.DbStuff.Model.Questionnaire.QuestionnaireRegistration", "QuestionnaireRegistration")
                        .WithMany("QuestionnaireResults")
                        .HasForeignKey("QuestionnaireRegistrationId");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.Questionnaire.QuestionnaireResultDetail", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Questionnaire.Answer", "Answer")
                        .WithMany("QuestionnaireReultDetails")
                        .HasForeignKey("AnswerId");

                    b.HasOne("WebApplication.DbStuff.Model.Questionnaire.QuestionnaireResult", "QuestionnaireResult")
                        .WithMany("QuestionnaireResultDetails")
                        .HasForeignKey("QuestionnaireResultId");
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.SpecialUser", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Job.OrganizationPosition", "CurrentWork")
                        .WithMany("Workers")
                        .HasForeignKey("CurrentWorkId");

                    b.HasOne("WebApplication.DbStuff.Model.Hotels.Hotel", "HotelUserIsHelper")
                        .WithMany("Helpers")
                        .HasForeignKey("HotelUserIsHelperId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.SpecialUserAddress", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Adress", "Adress")
                        .WithMany("Users")
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication.DbStuff.Model.SpecialUser", "User")
                        .WithMany("Adresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication.DbStuff.Model.SpecialUserTag", b =>
                {
                    b.HasOne("WebApplication.DbStuff.Model.Tag", "Tag")
                        .WithMany("Users")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication.DbStuff.Model.SpecialUser", "User")
                        .WithMany("Tags")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
