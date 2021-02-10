using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Institutions;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Model.Hotels;
using WebApplication.DbStuff.Model.Job;
using WebApplication.DbStuff.Model.Questionnaire;
using WebApplication.DbStuff.Model.Calendar;
using WebApplication.DbStuff.Model.Hospital;
using WebApplication.DbStuff.Model.Firefighters;

namespace WebApplication.DbStuff
{
    public class WebContext : DbContext
    {
        public DbSet<SpecialUser> SpecialUser { get; set; }
        public DbSet<CalcHistory> CalcHistory { get; set; }
        public DbSet<Adress> Adress { get; set; }
        public DbSet<Maze> Maze { get; set; }

        public DbSet<SpecialUserTag> SpecialUserTag { get; set; }
        public DbSet<Tag> Tag { get; set; }

        //Questionnaire
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public DbSet<QuestionnaireModel> QuestionnaireModel { get; set; }
        public DbSet<QuestionnaireRegistration> QuestionnaireRegistration { get; set; }
        public DbSet<QuestionnaireResult> QuestionnaireResult { get; set; }
        public DbSet<QuestionnaireResultDetail> QuestionnaireResultDetails { get; set; }
        //EndQuestionnaire

        public DbSet<Office> Office { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Police> Polices { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<OrganizationPosition> OrganizationPosition { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDish> OrderDish {get; set;}

        public DbSet<Marriage> Marriage { get; set; }

        public WebContext(DbContextOptions dbContext) : base(dbContext) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpecialUser>()
                .HasMany(x => x.Adresses)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpecialUser>()
                .HasMany(x => x.MyMazes)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpecialUser>()
                .HasMany(x => x.Tags)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Adress>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Adress)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Adress>()
                .HasMany(x => x.Offices)
                .WithOne(x => x.Adress)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tag>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Tag)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Maze>()
                .HasMany(x => x.Gamers)
                .WithOne(x => x.Maze)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Question>()
                .HasMany(x => x.Answers)
                .WithOne(x => x.Question)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Answer>()
                .HasMany(x => x.Questions)
                .WithOne(x => x.Answer)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Organization>()
                .HasMany(x => x.OrganizationPositions)
                .WithOne(x => x.Organization)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Organization>()
                .HasMany(x => x.Offices)
                .WithOne(x => x.Organization)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Office>()
                .HasMany(x => x.Positions)
                .WithOne(x => x.Office);

            modelBuilder.Entity<Position>()
                .HasMany(x => x.OrganizationPositions)
                .WithOne(x => x.Position)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpecialUser>()
                .HasMany(x => x.Vacancies)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrganizationPosition>()
                .HasMany(x => x.Candidates)
                .WithOne(x => x.OrganizationPosition)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Hotel>()
                .HasMany(x => x.Rooms)
                .WithOne(x => x.Hotel)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Hotel>()
                .HasMany(x => x.Helpers)
                .WithOne(x => x.HotelUserIsHelper)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HotelRoom>()
                .HasMany(x => x.Bookings)
                .WithOne(x => x.HotelRoom)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Restaurant>()
                .HasMany(x => x.Dishes)
                .WithOne(x => x.Restaurant)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Restaurant>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.Restaurant)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.Dishes)
                .WithOne(x => x.Order)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Dish>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.Dish)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Hotel>()
                .HasMany(x => x.Rooms)
                .WithOne(x => x.Hotel)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpecialUser>()
                .HasOne(x => x.HotelUserIsHelper)
                .WithMany(x => x.Helpers)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpecialUser>()
                .HasMany(x => x.SeenCalendarEvents)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CalendarEvent>()
                .HasMany(x => x.SeenCalendarEventByUsers)
                .WithOne(x => x.CalendarEvent)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CalendarTypeEvent>()
                .HasMany(x => x.CalendarEvents)
                .WithOne(x => x.CalendarTypeEvent)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpecialUser>()
                .HasMany(x => x.PerformedFireInspectionsBuilding)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpecialUserFireInspection>()
                    .HasOne(x => x.FireInspectionBuilding)
                    .WithOne(x => x.PerformedFireInspectionBuildingByUser)
                    .HasForeignKey<FireInspectionBuilding>(x => x.SpecialUserFireInspectionId);

            modelBuilder.Entity<FireInspectionBuilding>()
                .HasOne(x => x.PerformedFireInspectionBuildingByUser)
                .WithOne(x => x.FireInspectionBuilding)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Adress>()
                .HasMany(x => x.FireInspectionBuilding)
                .WithOne(x => x.BuildingAdress)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BuildingTypeSafetyAssessment>()
                .HasMany(x => x.FireInspectionsBuilding)
                .WithOne(x => x.BuildingTypeSafetyAssessment)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Adress>()
                    .HasOne(x => x.FireInspectionSchedule)
                    .WithOne(x => x.BuildingAdress)
                    .HasForeignKey<FireInspectionSchedule>(x => x.BuildingAdressId);

            modelBuilder.Entity<FireInspectionSchedule>()
                .HasOne(x => x.BuildingAdress)
                .WithOne(x => x.FireInspectionSchedule)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalRecord>()
                .HasMany(x => x.Examinations)
                .WithOne(x => x.MedicalRecord);

            modelBuilder.Entity<SpecialUser>()
                .HasOne(x => x.MedicalRecord)
                .WithOne(x => x.Patient)
                .HasForeignKey<MedicalRecord>(x => x.PatientId);

            modelBuilder.Entity<SpecialUser>()
                .HasOne(x => x.CurrentWork)
                .WithMany(x => x.Workers)
                .IsRequired(false);

            modelBuilder.Entity<SpecialUser>()
                .HasMany(x => x.Notifications)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpecialUser>()
                .HasMany(x => x.MarriagesForHusband)
                .WithOne(x => x.Husband)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SpecialUser>()
                .HasMany(x => x.MarriagesForWife)
                .WithOne(x => x.Wife)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
