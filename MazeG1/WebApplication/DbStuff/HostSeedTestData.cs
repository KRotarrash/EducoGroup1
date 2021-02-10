using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Model.Calendar;
using WebApplication.DbStuff.Model.Firefighters;
using WebApplication.DbStuff.Repository;
using WebApplication.DbStuff.Repository.IRepository.ICalendar;
using WebApplication.DbStuff.Repository.IRepository.IFirefighters;
using WebApplication.Models.Address;

namespace WebApplication.DbStuff
{
    public static class HostSeedTestData
    {
        //Const for Adress
        private const string _adressCountryDefault = "Republic of Belarus";
        private const int _adressFlatNumberDefault = 1;
        private const int _adressFloorDefault = 1;

        public static IHost SeedTestData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                CheckAndCreateDefaultCalendarEvent(serviceProvider);
                CheckAndCreateDefaultAdress(serviceProvider);
                CheckAndCreateDefaultFireInspectionBuilding(serviceProvider);
                CheckAndCreateDefaultFireInspectionSchedule(serviceProvider);
            }
            return host;
        }

        private static void CheckAndCreateDefaultCalendarEvent(IServiceProvider serviceProvider)
        {
            var calendarTypeEvent = FindOrCreateDefaultCalendarTypeEvent(serviceProvider, HostSeed.NameOfTypeEventDefault);
            CreateDefaultCalendarEventIfNotExist(serviceProvider, calendarTypeEvent);
        }

        private static CalendarTypeEvent FindOrCreateDefaultCalendarTypeEvent(IServiceProvider serviceProvider, string nameOfTypeEvent)
        {
            HostSeed.CreateCalendarTypeEventIfNotExist(serviceProvider, nameOfTypeEvent);
            var calendarTypeEventRepository = serviceProvider.GetService<ICalendarTypeEventRepository>();
            var calendarTypeEvent = calendarTypeEventRepository.GetByNameOfTypeEvent(nameOfTypeEvent);
            return calendarTypeEvent;
        }

        private static void CreateDefaultCalendarEventIfNotExist(IServiceProvider serviceProvider, CalendarTypeEvent calendarTypeEvent)
        {
            var calendarEventRepository = serviceProvider.GetService<ICalendarEventRepository>();
            var title = string.Format("{0} {1}", HostSeed.NameOfTypeEventDefault, HostSeed.SpecialUserNameDefault);
            var calendarEvent = calendarEventRepository.GetByTitleOfEvent(title);
            if (calendarEvent != null)
            {
                return;
            }

            calendarEvent = new CalendarEvent()
            {
                Title = title,
                Description = HostSeed.NameOfTypeEventDefault,
                DateStartEvent = DateTime.Now,
                CalendarTypeEvent = calendarTypeEvent
            };
            calendarEventRepository.Save(calendarEvent);
        }

        private static void CheckAndCreateDefaultAdress(IServiceProvider serviceProvider)
        {
            CreateDefaultAdressIfNotExist(serviceProvider);
        }

        private static void CreateDefaultAdressIfNotExist(IServiceProvider serviceProvider)
        {
            var adressRepository = serviceProvider.GetService<IAdressRepository>();
            var adress = adressRepository.GetAdressDefaultForFireInspection(HostSeed.AdressCityDefault,
                  HostSeed.AdressStreetDefault, HostSeed.AdressHouseNumberDefault);
            if (adress != null)
            {
                return;
            }

            adress = new Adress()
            {
                TypePlacing = TypePlacing.Living,
                Country = _adressCountryDefault,
                City = HostSeed.AdressCityDefault,
                TypeStreet = TypeStreet.Avenue,
                Street = HostSeed.AdressStreetDefault,
                HouseNumber = HostSeed.AdressHouseNumberDefault,
                FlatNumber = _adressFlatNumberDefault,
                Floor = _adressFloorDefault
            };
            adressRepository.Save(adress);
        }

        private static void CheckAndCreateDefaultFireInspectionBuilding(IServiceProvider serviceProvider)
        {
            var buildingTypeSafetyAssessment = FindOrCreateDefaultBuildingTypeSafetyAssessment(serviceProvider, HostSeed.idSafetyAssessmentSafe);
            CreateDefaultFireInspectionBuildingIfNotExist(serviceProvider, buildingTypeSafetyAssessment);
        }

        private static BuildingTypeSafetyAssessment FindOrCreateDefaultBuildingTypeSafetyAssessment(IServiceProvider serviceProvider,
              int idSafetyAssessmentSafe)
        {
            HostSeed.CreateBuildingTypeSafetyAssessmentIfNotExist(serviceProvider, idSafetyAssessmentSafe);
            var buildingTypeSafetyAssessmentRepository = serviceProvider.GetService<IBuildingTypeSafetyAssessmentRepository>();
            var buildingTypeSafetyAssessment = buildingTypeSafetyAssessmentRepository.GetById(idSafetyAssessmentSafe);
            return buildingTypeSafetyAssessment;
        }

        private static void CreateDefaultFireInspectionBuildingIfNotExist(IServiceProvider serviceProvider,
             BuildingTypeSafetyAssessment buildingTypeSafetyAssessment)
        {
            var fireInspectionBuildingRepository = serviceProvider.GetService<IFireInspectionBuildingRepository>();
            var adressRepository = serviceProvider.GetService<IAdressRepository>();
            var adressFromfireInspectionBuilding = adressRepository.GetAdressDefaultForFireInspectionBuilding(HostSeed.AdressCityDefault,
                          HostSeed.AdressStreetDefault, HostSeed.AdressHouseNumberDefault);

            if (adressFromfireInspectionBuilding != null)
            {
                return;
            }

            var userRepository = serviceProvider.GetService<ISpecialUserRepository>();
            var admin = userRepository.GetUserByName(HostSeed.SpecialUserNameDefault);

            var specialUserFireInspectionRepository = serviceProvider.GetService<ISpecialUserFireInspectionRepository>();
            var specialUserFireInspection = specialUserFireInspectionRepository.GetByUserId(admin.Id);

            if (specialUserFireInspection == null)
            {
                specialUserFireInspection = new SpecialUserFireInspection()
                {
                    User = admin,
                };
            }

            var adress = adressRepository.GetAdressDefaultForFireInspection(HostSeed.AdressCityDefault,
                  HostSeed.AdressStreetDefault, HostSeed.AdressHouseNumberDefault);
            var fireInspectionBuilding = new FireInspectionBuilding()
            {
                BuildingAdress = adress,
                DateInspection = DateTime.Now,
                BuildingTypeSafetyAssessment = buildingTypeSafetyAssessment,
                PerformedFireInspectionBuildingByUser = specialUserFireInspection
            };
            fireInspectionBuildingRepository.Save(fireInspectionBuilding);
        }

        private static void CheckAndCreateDefaultFireInspectionSchedule(IServiceProvider serviceProvider)
        {
            CreateDefaultFireInspectionScheduleIfNotExist(serviceProvider);
        }

        private static void CreateDefaultFireInspectionScheduleIfNotExist(IServiceProvider serviceProvider)
        {
            var fireInspectionScheduleRepository = serviceProvider.GetService<IFireInspectionScheduleRepository>();
            var adressRepository = serviceProvider.GetService<IAdressRepository>();
            var adressFromfireInspectionSchedule = adressRepository.GetAdressDefaultForFireInspectionSchedule(HostSeed.AdressCityDefault,
                          HostSeed.AdressStreetDefault, HostSeed.AdressHouseNumberDefault);

            if (adressFromfireInspectionSchedule != null)
            {
                return;
            }

            var adress = adressRepository.GetAdressDefaultForFireInspection(HostSeed.AdressCityDefault,
                  HostSeed.AdressStreetDefault, HostSeed.AdressHouseNumberDefault);
            var fireInspectionSchedule = new FireInspectionSchedule()
            {
                BuildingAdress = adress,
                DateInspectionSchedule = DateTime.Now,
                FireInspectionPeriodicity = HostSeed.PeriodicityDefault
            };
            fireInspectionScheduleRepository.Save(fireInspectionSchedule);
        }
    }
}
