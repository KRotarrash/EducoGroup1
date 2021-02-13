using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Model.Job;
using WebApplication.DbStuff.Model.Calendar;
using WebApplication.DbStuff.Model.Firefighters;
using WebApplication.DbStuff.Repository;
using WebApplication.DbStuff.Repository.IRepository.IJob;
using WebApplication.DbStuff.Repository.IRepository.ICalendar;
using WebApplication.DbStuff.Institutions;
using WebApplication.DbStuff.Model.Hospital;
using WebApplication.DbStuff.Repository.IRepository.IFirefighters;
using WebApplication.Models.Firefighters;

namespace WebApplication.DbStuff
{
    public static class HostSeed
    {
        //Const for specialUser
        public const string SpecialUserNameDefault = "Admin.Admin";
        private const string _specialUserPasswordDefault = "qwe123";
        private const int _specialUserAgeDefault = 18;
        private const int _specialUserHeightDefault = 175;
        private const WebRole _specialUserWebRole = WebRole.Admin;
        private const SupportLang _specialUserSupportLangDefault = SupportLang.Ru;
        private const int _specialUserSalaryDateDefault = 5;
        private const double _specialUserSalaryDefault = 0;
        
        //Const for position mayor
        private const string _mayorOrganizationDefault = "Администрация";
        public const string MayorPositionDefault = "Мэр";
        private const int _mayorSalaryDateDefault = 5;
        private const double _mayorSalaryDefault = 1000;

        //Const for position firefighters
        public const string FirefightersOrganizationDefault = "Пожарное отделение №1";
        public const string FirefightersPositionDefault = "Руководитель пожарного отделения";
        private const int _firefightersSalaryDateDefault = 5;
        private const double _firefightersSalaryDefault = 700;

        //Const for Adress
        public const string AdressCityDefault = "Minsk";
        public const string AdressStreetDefault = "Nezalejnasti Avenue";
        public const int AdressHouseNumberDefault = 1;

        //Const for firefighters
        public static string[] SafetyTypeAssessmentsOfBuilding = { "Безопасно", "Удовлетворительно", "Неудовлетворительно",
            "Недопустимо" };
        public const string SafetyAssessmentSafe = "Безопасно";
        public const int idSafetyAssessmentSafe = 1;
        public const InspectionPeriodicity PeriodicityDefault = InspectionPeriodicity.Annual;

        //Const for Job
        public const string OrganizationDefault = "Нет организации";
        public const string PositionDefault = "Безработный";

        //Const for Police
        public const string PoliceNameDefault = "Полиция";
        private const int _policeSalaryDateDefault = 1;
        private const OrganizationType _policeOrganizationTypeDefault = OrganizationType.Undefined;
        private const string _policeStartWorkDefault = "01/01/0001 00:00:00 AM";
        private const string _policeEndWorkDefault = "01/01/0001 00:00:00 AM";

        // CalendarEvent
        public const string NameOfTypeEventDefault = "День рождения";
        public const string NameOfTypeEventBooking = "Бронирование";

        //Const for Hospital
        public const string HospitalNameDefault = "Больница";
        public const string HospitalPositionDefault = "Руководитель больницы";
        public const int HospitalSalaryDateDefault = 1;
        private const double HospitalSalaryDefault = 500;
        public const OrganizationType HospitalOrganizationTypeDefault = OrganizationType.Hospital;
        public const string HospitalStartWorkDefault = "01/01/0001 00:00:00 AM";
        public const string HospitalEndWorkDefault = "01/01/0001 00:00:00 AM";

        // Months count
        public const int CountMonth = 12;

        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                CheckAndCreateDefaultUser(serviceProvider);
                CheckAndCreateDefaultMayor(serviceProvider);
                CheckAndCreateDefaultPolice(serviceProvider);
                CheckAndCreateDefaulFirefighters(serviceProvider);
                CheckAndCreateDefaultTypeSafetyAssessment(serviceProvider);
                CheckAndCreateDefaultCalendarTypeEvent(serviceProvider);
                CheckAndCreateBookingCalendarEvent(serviceProvider);
                CheckAndCreateDefaultHospital(serviceProvider);
            }
            return host;
        }

        private static void CheckAndCreateDefaultPolice(IServiceProvider serviceProvider)
        {
            var organizationRepository = serviceProvider.GetService<IOrganizationRepository>();
            var organization = organizationRepository.GetOrganizationByName(PoliceNameDefault);

            if (organization != null)
            {
                return;
            }

            var organizationPositionRepository = serviceProvider.GetService<IOrganizationPositionRepository>();
            var userRepository = serviceProvider.GetService<ISpecialUserRepository>();

            var organizationPosition = organizationPositionRepository
                .GetByPositionName(MayorPositionDefault);

            var mayor = userRepository
                .GetUserOnOrganizationPosition(organizationPosition.Id);

            var policeOrganization = new Police()
            {
                Name = PoliceNameDefault,
                Owner = mayor,
                SalaryDate = _policeSalaryDateDefault,
                OrganizationType = _policeOrganizationTypeDefault,
                StartWork = DateTime.Parse(_policeStartWorkDefault),
                EndWork = DateTime.Parse(_policeEndWorkDefault),
            };

            organizationRepository.Save(policeOrganization);
        }
        private static void CheckAndCreateDefaultHospital(IServiceProvider serviceProvider)
        {
            var organizationRepository = serviceProvider.GetService<IOrganizationRepository>();
            var organization = organizationRepository.GetOrganizationByName(HospitalNameDefault);

            if (organization != null)
            {
                return;
            }

            var hospital = new Hospital()
            {
                Name = HospitalNameDefault,
                SalaryDate = HospitalSalaryDateDefault,
                OrganizationType = HospitalOrganizationTypeDefault,
                StartWork = DateTime.Parse(HospitalStartWorkDefault),
                EndWork = DateTime.Parse(HospitalEndWorkDefault),
            };
            organizationRepository.Save(hospital);

            var organization2 = organizationRepository.GetOrganizationByName(HospitalNameDefault);
            var position = FindOrCreatePositionForHospital(serviceProvider);
            CreateOrganizationPositionIfNotExist(serviceProvider, organization2, position);
        }

        private static void CheckAndCreateDefaultUser(IServiceProvider serviceProvider)
        {
            var userRepository = serviceProvider.GetService<ISpecialUserRepository>();
            var admin = userRepository.GetUserByName(SpecialUserNameDefault);
            if (admin != null)
            {
                return;
            }

            var position = FindOrCreateOrganizationPositionForSpecialUser(serviceProvider);
            var user = new SpecialUser()
            {
                Name = SpecialUserNameDefault,
                Password = _specialUserPasswordDefault,
                Age = _specialUserAgeDefault,
                Height = _specialUserHeightDefault,
                WebRole = _specialUserWebRole,
                SupportLang = _specialUserSupportLangDefault,
                CurrentWork = position
            };
            userRepository.Save(user);
        }

        private static void CheckAndCreateDefaultMayor(IServiceProvider serviceProvider)
        {
            var organization = FindOrCreateOrganizationForMayor(serviceProvider);
            var position = FindOrCreatePositionForMayor(serviceProvider);
            var organizationPositionMayor = CreateOrganizationPositionIfNotExist(serviceProvider, organization, position);

            var userRepository = serviceProvider.GetService<ISpecialUserRepository>();
            var mayor = userRepository.GetMayor();
            if (mayor == null)
            {
                var admin = userRepository.GetUserByName(SpecialUserNameDefault);
                admin.CurrentWork = organizationPositionMayor;
                userRepository.Save(admin);
            }
        }

        private static void CheckAndCreateDefaulFirefighters(IServiceProvider serviceProvider)
        {
            var organization = FindOrCreateOrganizationForFirefighters(serviceProvider);
            var position = FindOrCreatePositionForFirefighters(serviceProvider);
            var organizationPositionFirefighter = CreateOrganizationPositionIfNotExist(serviceProvider, organization, position);

            var userRepository = serviceProvider.GetService<ISpecialUserRepository>();
            var firefighter = userRepository.GetFirefighter();
            if (firefighter == null)
            {
                var admin = userRepository.GetUserByName(SpecialUserNameDefault);
                admin.CurrentWork = organizationPositionFirefighter;
                userRepository.Save(admin);
            }
        }

        private static void CheckAndCreateDefaultTypeSafetyAssessment(IServiceProvider serviceProvider)
        {
            for (int i = 0; i < SafetyTypeAssessmentsOfBuilding.Length; i++)
            {
                CreateBuildingTypeSafetyAssessmentIfNotExist(serviceProvider, i+1);
            }
        }

        private static void CheckAndCreateDefaultCalendarTypeEvent(IServiceProvider serviceProvider)
        {
            CreateCalendarTypeEventIfNotExist(serviceProvider, NameOfTypeEventDefault);
        }

        private static void CheckAndCreateBookingCalendarEvent(IServiceProvider serviceProvider)
        {
            CreateCalendarTypeEventIfNotExist(serviceProvider, NameOfTypeEventBooking);
        }

        private static Organization FindOrCreateOrganizationForMayor(IServiceProvider serviceProvider)
        {
            var organization = FindOrCreateOrganization(serviceProvider, _mayorOrganizationDefault, _mayorSalaryDateDefault);
            return organization;
        }

        private static Position FindOrCreatePositionForMayor(IServiceProvider serviceProvider)
        {
            var position = FindOrCreatePosition(serviceProvider, MayorPositionDefault, _mayorSalaryDefault);
            return position;
        }

        private static Organization FindOrCreateOrganizationForFirefighters(IServiceProvider serviceProvider)
        {
            var organization = FindOrCreateOrganization(serviceProvider, FirefightersOrganizationDefault, _firefightersSalaryDateDefault,
                 OrganizationType.FirefightersDepartment);
            return organization;
        }

        private static Position FindOrCreatePositionForFirefighters(IServiceProvider serviceProvider)
        {
            var position = FindOrCreatePosition(serviceProvider, FirefightersPositionDefault, _firefightersSalaryDefault);
            return position;
        }

        private static Position FindOrCreatePositionForHospital(IServiceProvider serviceProvider)
        {
            var position = FindOrCreatePosition(serviceProvider, HospitalPositionDefault, HospitalSalaryDefault);
            return position;
        }

        private static OrganizationPosition FindOrCreateOrganizationPositionForSpecialUser(IServiceProvider serviceProvider)
        {
            var organization = FindOrCreateOrganizationForSpecialUser(serviceProvider);
            var position = FindOrCreatePositionForSpecialUser(serviceProvider);
            var organizationPosition = FindOrCreateOrganizationPosition(serviceProvider, organization, position);
            return organizationPosition;
        }

        private static Organization FindOrCreateOrganizationForSpecialUser(IServiceProvider serviceProvider)
        {
            var organization = FindOrCreateOrganization(serviceProvider, OrganizationDefault, _specialUserSalaryDateDefault);
            return organization;
        }

        private static Position FindOrCreatePositionForSpecialUser(IServiceProvider serviceProvider)
        {
            var position = FindOrCreatePosition(serviceProvider, PositionDefault, _specialUserSalaryDefault);
            return position;
        }

        private static OrganizationPosition FindOrCreateOrganizationPosition(IServiceProvider serviceProvider,
            Organization organization, Position position)
        {
            CreateOrganizationPositionIfNotExist(serviceProvider, organization, position);
            var organizationPositionRepository = serviceProvider.GetService<IOrganizationPositionRepository>();
            var organizationPosition = organizationPositionRepository.GetOrganizationPositionDefault(organization, position);
            return organizationPosition;
        }

        private static OrganizationPosition CreateOrganizationPositionIfNotExist(IServiceProvider serviceProvider,
            Organization organization, Position position)
        {
            var organizationPositionRepository = serviceProvider.GetService<IOrganizationPositionRepository>();
            var organizationPosition = organizationPositionRepository.GetOrganizationPositionDefault(organization, position);
            if (organizationPosition != null)
            {
                return organizationPosition;
            }

            organizationPosition = new OrganizationPosition()
            {
                Organization = organization,
                Position = position
            };
            organizationPositionRepository.Save(organizationPosition);

            return organizationPosition;
        }

        private static Organization FindOrCreateOrganization(IServiceProvider serviceProvider,
            string organizationDefault, int salaryDateDefault, OrganizationType organizationType = OrganizationType.Undefined)
        {
            var organizationRepository = serviceProvider.GetService<IOrganizationRepository>();
            var organization = organizationRepository.GetOrganizationByName(organizationDefault);
            if (organization != null)
            {
                return organization;
            }

            var userRepository = serviceProvider.GetService<ISpecialUserRepository>();
            var admin = userRepository.GetUserByName(SpecialUserNameDefault);
            organization = new Organization()
            {
                Name = organizationDefault,
                SalaryDate = salaryDateDefault,
                Owner = admin,
                OrganizationType = organizationType

            };
            organizationRepository.Save(organization);
            return organization;
        }

        private static Position FindOrCreatePosition(IServiceProvider serviceProvider,
              string positionDefault, double positionSalaryDefault)
        {
            var positionRepository = serviceProvider.GetService<IPositionRepository>();
            var position = positionRepository.GetPositionByName(positionDefault);
            if (position != null)
            {
                return position;
            }

            position = new Position()
            {
                Name = positionDefault,
                Salary = positionSalaryDefault
            };
            positionRepository.Save(position);
            return position;
        }

        public static void CreateCalendarTypeEventIfNotExist(IServiceProvider serviceProvider, string nameOfTypeEvent)
        {
            var calendarTypeEventRepository = serviceProvider.GetService<ICalendarTypeEventRepository>();
            var calendarTypeEvent = calendarTypeEventRepository.GetByNameOfTypeEvent(nameOfTypeEvent);
            if (calendarTypeEvent != null)
            {
                return; 
            }

            calendarTypeEvent = new CalendarTypeEvent()
            {
                NameOfTypeEvent = nameOfTypeEvent
            };
            calendarTypeEventRepository.Save(calendarTypeEvent);
        }

        public static void CreateBuildingTypeSafetyAssessmentIfNotExist(IServiceProvider serviceProvider, int idTypeSafetyAssessment)
        {
            var buildingTypeSafetyAssessmentRepository = serviceProvider.GetService<IBuildingTypeSafetyAssessmentRepository>();
            var buildingTypeSafetyAssessment = buildingTypeSafetyAssessmentRepository.GetById(idTypeSafetyAssessment);
            if (buildingTypeSafetyAssessment != null)
            {
                return;
            }

            buildingTypeSafetyAssessment = new BuildingTypeSafetyAssessment()
            {
                NameOfTypeSafetyAssessment = SafetyTypeAssessmentsOfBuilding[idTypeSafetyAssessment - 1]
            };
            buildingTypeSafetyAssessmentRepository.Save(buildingTypeSafetyAssessment);
        }
    }
}
