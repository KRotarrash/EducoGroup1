using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using MazeCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.DbStuff;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Model.Calendar;
using WebApplication.DbStuff.Repository;
using WebApplication.DbStuff.Repository.IRepository.ICalendar;
using WebApplication.Models;
using WebApplication.Models.Calendar;
using WebApplication.Models.Firefighters;
using WebApplication.DbStuff.Repository.Questionnaire;
using WebApplication.Presentation;
using WebApplication.Presentation.Questionnaire;
using WebApplication.Service;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using WebApplication.DbStuff.Repository.IRepository.IJob;
using WebApplication.DbStuff.Model.Job;
using WebApplication.Sevrice.Helper;
using WebApplication.DbStuff.Institutions;
using WebApplication.Models.Restaurant;
using WebApplication.DbStuff.Repository.IRepository.IRestaurant;
using WebApplication.DbStuff.Repository.IRepository.IHotels;
using WebApplication.DbStuff.Model.Hotels;
using WebApplication.DbStuff.Repository.IRepository.IFirefighters;
using WebApplication.DbStuff.Model.Firefighters;
using WebApplication.DbStuff.Model.Hospital;
using WebApplication.Models.Job;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace WebApplication
{
    public class Startup
    {
        public const string AuthMethod = "CoockieAuth";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterPresentation(services);

            RegisterServices(services);

            RegisterRepository(services);

            RegisterMapper(services);

            services.AddScoped(x => new MazeGenerator());

            services.AddDbContext<WebContext>(
                  options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));                   

            services.AddAuthentication(AuthMethod)
                .AddCookie(AuthMethod, config =>
                {
                    config.Cookie.Name = "User.Auth";
                    config.LoginPath = "/User/Login";
                    config.AccessDeniedPath = "/User/AccessDenied";
                });

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
        }

        private void RegisterMapper(IServiceCollection services)
        {
            var configurationExpression = new MapperConfigurationExpression();

            configurationExpression.CreateMap<SpecialUser, UserViewModel>()
                .ForMember(nameof(UserViewModel.UserName), opt => opt.MapFrom(x => x.Name))
                .ForMember(nameof(UserViewModel.Password), opt => opt.MapFrom(x => x.Password))
                .ForMember(nameof(UserViewModel.PasswordRepeat), opt => opt.MapFrom(x => x.Password))
                .ForMember(nameof(UserViewModel.Age), opt => opt.MapFrom(x => x.Age))
                .ForMember(nameof(UserViewModel.Height), opt => opt.MapFrom(x => x.Height))
                .ForMember(nameof(UserViewModel.AdressCount), opt => opt.MapFrom(x => x.Adresses.Count()))
                .ForMember(nameof(UserViewModel.Role), opt => opt.MapFrom(x => x.WebRole.ToString()))
                .ForMember(nameof(UserViewModel.OrganizationPosition), opt => opt.MapFrom(x => GetOrganizationPositionViewModel(x)))
                ;

            configurationExpression.CreateMap<UserViewModel, SpecialUser>()
                .ForMember(nameof(SpecialUser.Name), opt => opt.MapFrom(x => x.UserName))
                .ForMember(nameof(SpecialUser.Password), opt => opt.MapFrom(x => x.Password))
                .ForMember(nameof(SpecialUser.Password), opt => opt.MapFrom(x => x.PasswordRepeat))
                .ForMember(nameof(SpecialUser.Age), opt => opt.MapFrom(x => x.Age))
                .ForMember(nameof(SpecialUser.Height), opt => opt.MapFrom(x => x.Height))
                .ForMember(nameof(SpecialUser.WebRole), opt => opt.MapFrom(x =>
                   (WebRole)Enum.Parse(typeof(WebRole), x.Role)));

            configurationExpression.CreateMap<SpecialUser, RoleViewModel>()
                 .ForMember(nameof(RoleViewModel.OwnerId), opt => opt.MapFrom(dm => dm.Id))
                 .ForMember(nameof(RoleViewModel.UserName), opt => opt.MapFrom(dm => dm.Name))
                 .ForMember(nameof(RoleViewModel.RoleId), opt => opt.MapFrom(dm => (int)dm.WebRole));

            configurationExpression.CreateMap<SpecialUserTag, TagViewModel>()
                .ForMember(nameof(TagViewModel.TagName), opt => opt.MapFrom(x => x.Tag.Name))
                .ForMember(nameof(TagViewModel.UserId), opt => opt.MapFrom(x => x.User.Id));

            configurationExpression.CreateMap<CalcHistory, CalcHistoryViewModel>()
                .ForMember(nameof(CalcHistoryViewModel.Operation), opt => opt.MapFrom(x => x.Operation.ToString()));

            configurationExpression.CreateMap<Organization, OrganizationViewModel>()
                .ForMember(nameof(OrganizationViewModel.Positions), opt => opt.MapFrom(x => GetOrganizationPositionViewModel(x)));
            configurationExpression.CreateMap<OrganizationViewModel, Organization>();

            configurationExpression.CreateMap<Organization, OrganizationOfficesManagerViewModel>();
            configurationExpression.CreateMap<OrganizationOfficesManagerViewModel, Organization>();


            configurationExpression.CreateMap<OrganizationViewModel, Restaurant>();

            configurationExpression.CreateMap<Restaurant, RestaurantViewModel>();
            configurationExpression.CreateMap<RestaurantViewModel, Restaurant>();

            configurationExpression.CreateMap<Office, OfficeViewModel>()
                .ForMember(nameof(OfficeViewModel.Address), opt => opt.MapFrom(x => x.Adress));
            configurationExpression.CreateMap<OfficeViewModel, Office>();

            configurationExpression.CreateMap<Position, PositionViewModel>()
                .ForMember(nameof(PositionViewModel.Organizations), opt => opt.MapFrom(x => GetOrganizationPositionViewModel(x)));

            configurationExpression.CreateMap<CalcViewModel, CalcHistory>();

            configurationExpression.CreateMap<Adress, AdressViewModel>();
            configurationExpression.CreateMap<AdressViewModel, Adress>();

            configurationExpression.CreateMap<Dish, DishViewModel>();
            configurationExpression.CreateMap<DishViewModel, Dish>();

            configurationExpression.CreateMap<Dish, DishOptionViewModel>();
            configurationExpression.CreateMap<DishOptionViewModel, Dish>();

            configurationExpression.CreateMap<SpecialUserAddress, UserViewModel>()
                .ForMember(nameof(UserViewModel.Id), opt => opt.MapFrom(x => x.User.Id));

            configurationExpression.CreateMap<OrganizationPositionViewModel, OrganizationPosition>();
            configurationExpression.CreateMap<OrganizationPosition, OrganizationPositionViewModel>();
            configurationExpression.CreateMap<OrganizationPositionCandidateViewModel, OrganizationPositionCandidate>();
            configurationExpression.CreateMap<OrganizationPositionCandidate, OrganizationPositionCandidateViewModel>();
            configurationExpression.CreateMap<OrganizationPosition, VacancyViewModel>()
                .ForMember(nameof(VacancyViewModel.OrganizationPosition), opt => opt.MapFrom(x => GetOrganizationPosition(x)));

            configurationExpression.CreateMap<Hotel, HotelViewModel>();
            configurationExpression.CreateMap<HotelViewModel, Hotel>();

            configurationExpression.CreateMap<HotelRoom, HotelRoomViewModel>();
            configurationExpression.CreateMap<HotelRoomViewModel, HotelRoom>();

            configurationExpression.CreateMap<Order, OrderViewModel>()
                .ForMember(nameof(OrderViewModel.Dishes), opt => opt.MapFrom(x => GetDishes(x)))
                .ForMember(nameof(OrderViewModel.TotalCost), opt => opt.MapFrom(x => GetTotalCost(x)))
                .ForMember(nameof(OrderViewModel.Customer), opt => opt.MapFrom(x => x.Сustomer))
                .ForMember(nameof(OrderViewModel.Restaurant), opt => opt.MapFrom(x => x.Restaurant))
                .ForMember(nameof(OrderViewModel.Dishes), opt => opt.MapFrom(x => GetDishes(x)));

            configurationExpression.CreateMap<CalendarEvent, CalendarEventViewModel>()
                .ForMember(nameof(CalendarEventViewModel.FormatDateEvent), opt => opt.MapFrom(x => x.DateStartEvent.ToString("dd.MM.yyyy HH:mm")));

            configurationExpression.CreateMap<CalendarEventViewModel, CalendarEvent>()
                .ForMember(nameof(CalendarEvent.DateStartEvent), opt => opt.MapFrom(dm => GetDateTimeFromModel(dm)))
                .ForMember(nameof(CalendarEvent.DateFinishEvent), opt => opt.MapFrom(dm => GetDateTimeFromModel(dm)));

            configurationExpression.CreateMap<CalendarTypeEvent, CalendarTypeEventViewModel>();
            configurationExpression.CreateMap<CalendarTypeEventViewModel, CalendarTypeEvent>();

            configurationExpression.CreateMap<FireInspectionBuilding, FireInspectionBuildingViewModel>()
                .ForMember(nameof(FireInspectionBuildingViewModel.FormatDateInspection), opt => opt.MapFrom(x => x.DateInspection.ToString("dd.MM.yyyy HH:mm")))
                .ForMember(nameof(FireInspectionBuildingAddOrEditViewModel.BuildingTypeSafetyAssessmentId),
                     opt => opt.MapFrom(x => x.BuildingTypeSafetyAssessment.Id))
                .ForMember(nameof(FireInspectionBuildingViewModel.NameOfTypeSafetyAssessment),
                     opt => opt.MapFrom(x => x.BuildingTypeSafetyAssessment.NameOfTypeSafetyAssessment));

            configurationExpression.CreateMap<FireInspectionBuildingViewModel, FireInspectionBuilding>()
                    .ForMember(nameof(FireInspectionBuilding.BuildingTypeSafetyAssessment), opt => opt.MapFrom(dm => GetBuildingTypeSafetyAssessment(dm)));

            configurationExpression.CreateMap<FireInspectionBuilding, FireInspectionBuildingAddOrEditViewModel>()
                .ForMember(nameof(FireInspectionBuildingAddOrEditViewModel.BuildingTypeSafetyAssessmentId),
                     opt => opt.MapFrom(x => x.BuildingTypeSafetyAssessment.Id))
                .ForMember(nameof(FireInspectionBuildingAddOrEditViewModel.NameOfTypeSafetyAssessment),
                     opt => opt.MapFrom(x => x.BuildingTypeSafetyAssessment.NameOfTypeSafetyAssessment));

            configurationExpression.CreateMap<FireInspectionBuildingAddOrEditViewModel, FireInspectionBuilding>()
                    .ForMember(nameof(FireInspectionBuilding.DateInspection), opt => opt.MapFrom(dm => GetDateTimeFromModel(dm)))
                    .ForMember(nameof(FireInspectionBuilding.BuildingTypeSafetyAssessment), opt => opt.MapFrom(dm => GetBuildingTypeSafetyAssessment(dm)));

            configurationExpression.CreateMap<FireInspectionSchedule, FireInspectionScheduleViewModel>()
                .ForMember(nameof(FireInspectionScheduleViewModel.FormatDateInspectionSchedule), opt => opt.MapFrom(x => x.DateInspectionSchedule.ToString("dd.MM.yyyy HH:mm")));
            configurationExpression.CreateMap<FireInspectionScheduleViewModel, FireInspectionSchedule>();

            configurationExpression.CreateMap<FireInspectionSchedule, FireInspectionScheduleAddOrEditViewModel>();
            configurationExpression.CreateMap<FireInspectionScheduleAddOrEditViewModel, FireInspectionSchedule>()
                .ForMember(nameof(FireInspectionSchedule.DateInspectionSchedule), opt => opt.MapFrom(dm => GetDateTimeFromModel(dm)));

            configurationExpression.CreateMap<BuildingTypeSafetyAssessment, BuildingTypeSafetyAssessmentViewModel>();
            configurationExpression.CreateMap<BuildingTypeSafetyAssessmentViewModel, BuildingTypeSafetyAssessment>();

            configurationExpression.CreateMap<SpecialUserFireInspection, SpecialUserFireInspectionViewModel>();
            configurationExpression.CreateMap<SpecialUserFireInspectionViewModel, SpecialUserFireInspection>();

            configurationExpression.CreateMap<MedicalRecord, MedicalRecordViewModel>()
                .ForMember(nameof(MedicalRecordViewModel.DateOfLastExamination), opt => opt.MapFrom(x => GetLastDate(x).ToString("dd.MM.yyyy")));

            configurationExpression.CreateMap<MedicalRecordDetail, MedicalRecordDetailViewModel>()
                .ForMember(nameof(MedicalRecordDetailViewModel.DateOfExamination), opt => opt.MapFrom(x => x.DateOfExamination.ToString("dd.MM.yyyy")));

            configurationExpression.CreateMap<MedicalRecordDetailViewModel, MedicalRecordDetail>();

            configurationExpression.CreateMap<Notification, NotificationViewModel>();
            configurationExpression.CreateMap<NotificationViewModel, Notification>();

            configurationExpression.CreateMap<SpecialUser, UserShortViewModel>()
                .ForMember(nameof(UserViewModel.UserName), opt => opt.MapFrom(x => x.Name));

            var config = new MapperConfiguration(configurationExpression);
            var mapper = new Mapper(config);

            services.AddScoped<IMapper>(x => mapper);
        }


        private BuildingTypeSafetyAssessment GetBuildingTypeSafetyAssessment(FireInspectionBuildingViewModel model)
        {
            return new BuildingTypeSafetyAssessment()
            {
                NameOfTypeSafetyAssessment = model.NameOfTypeSafetyAssessment
            };
        }

        private BuildingTypeSafetyAssessment GetBuildingTypeSafetyAssessment(FireInspectionBuildingAddOrEditViewModel model)
        {
            return new BuildingTypeSafetyAssessment()
            {
                Id = model.BuildingTypeSafetyAssessmentId,
                NameOfTypeSafetyAssessment = model.NameOfTypeSafetyAssessment
            };
        }

        private List<OrganizationPositionViewModel> GetOrganizationPositionViewModel(Position position)
        {
            var result = new List<OrganizationPositionViewModel>();

            foreach (var organizationPosition in position.OrganizationPositions)
            {
                var organizationViewModel = new OrganizationViewModel()
                {
                    Id = organizationPosition.Organization.Id,
                    Name = organizationPosition.Organization.Name,
                    SalaryDate = organizationPosition.Organization.SalaryDate
                };


                var organizationPositionViewModel = new OrganizationPositionViewModel()
                {
                    Id = organizationPosition.Id,
                    Organization = organizationViewModel,
                    Position = new PositionViewModel()
                };

                result.Add(organizationPositionViewModel);
            }


            return result;
        }

        private List<OrganizationPositionViewModel> GetOrganizationPositionViewModel(Organization organization)
        {
            var result = new List<OrganizationPositionViewModel>();

            foreach (var organizationPosition in organization.OrganizationPositions)
            {
                var positionViewModel = new PositionViewModel()
                {
                    Id = organizationPosition.Position.Id,
                    Name = organizationPosition.Position.Name,
                    Salary = organizationPosition.Position.Salary
                };

                var organizationPositionViewModel = new OrganizationPositionViewModel()
                {
                    Id = organizationPosition.Id,
                    Organization = new OrganizationViewModel(),
                    Position = positionViewModel
                };

                result.Add(organizationPositionViewModel);
            }

            return result;
        }

        private OrganizationPositionViewModel GetOrganizationPositionViewModel(SpecialUser user)
        {
            var result = new OrganizationPositionViewModel()
            {
                Id = user.CurrentWork.Id,
                Organization = GetOrganizationViewModel(user.CurrentWork),
                Position = GetPositionViewModel(user.CurrentWork)
            };

            return result;
        }

        private PositionViewModel GetPositionViewModel(OrganizationPosition organizationPosition)
        {
            var result = new PositionViewModel()
            {
                Id = organizationPosition.Position.Id,
                Name = organizationPosition.Position.Name,
                Salary = organizationPosition.Position.Salary,
            };

            return result;
        }

        private OrganizationViewModel GetOrganizationViewModel(OrganizationPosition organizationPosition)
        {
            var result = new OrganizationViewModel()
            {
                Id = organizationPosition.Organization.Id,
                Name = organizationPosition.Organization.Name,
                SalaryDate = organizationPosition.Organization.SalaryDate,
            };

            return result;
        }

        private OrganizationPositionViewModel GetOrganizationPosition(OrganizationPosition organizationPosition)
        {
            var result = new OrganizationPositionViewModel()
            {
                Id = organizationPosition.Id,
                Organization = GetOrganizationViewModel(organizationPosition),
                Position = GetPositionViewModel(organizationPosition),
            };

            return result;
        }

        private List<Dish> GetDishes(Order x)
        {
            var dishes = new List<Dish>();
            foreach (var dish in x.Dishes)
            {
                dishes.Add(dish.Dish);
            }
            return dishes;
        }

        private DateTime GetLastDate(MedicalRecord x)
        {
            return x.Examinations.OrderByDescending(y => y.DateOfExamination).FirstOrDefault().DateOfExamination.Date;
        }

        private float GetTotalCost(Order order)
        {
            float result = 0;

            foreach (var dish in order.Dishes)
            {
                result += dish.Dish.Price;
            }

            return result;
        }

        private DateTime GetDateTimeFromModel(CalendarEventViewModel calendarEvent)
        {
            return calendarEvent.DateEvent.Date + calendarEvent.TimeEvent.TimeOfDay;
        }
        private DateTime GetDateTimeFromModel(FireInspectionBuildingAddOrEditViewModel fireInspection)
        {
            return fireInspection.DateInspection.Date + fireInspection.TimeInspection.TimeOfDay;
        }
        private DateTime GetDateTimeFromModel(FireInspectionScheduleAddOrEditViewModel fireInspection)
        {
            return fireInspection.DateInspectionSchedule.Date + fireInspection.TimeInspectionSchedule.TimeOfDay;
        }
        private void RegisterPresentation(IServiceCollection services)
        {
            services.AddScoped(
                container => new HomePresentation(
                    container.GetService<MazeGenerator>(),
                    container.GetService<CalcPresentation>()
                    ));

            services.AddScoped(
                container => new UserPresentation(
                    container.GetService<ISpecialUserRepository>(),
                    container.GetService<IUserService>(),
                    container.GetService<IAdressRepository>(),
                    container.GetService<IMapper>(),
                    container.GetService<ITagRepository>(),
                    container.GetService<ISpecialUserTagRepository>(),
                    container.GetService<FileProfileService>(),
                    container.GetService<OpenXmlProfileService>(),
                    container.GetService<IWebHostEnvironment>(),
                    container.GetService<IOrganizationPositionRepository>(),
                    container.GetService<JobPresentation>(),
                    container.GetService<ISpecialUserAddressRepository>(),
                    container.GetService<AddressPresentation>(),
                    container.GetService<IMarriageRepository>(),
                    container.GetService<INotificationRepository>()
                    ));

            services.AddScoped(
                container => new PolicePresentation(
                    container.GetService<ISpecialUserRepository>(),
                    container.GetService<IMapper>()
                    ));

            services.AddScoped(
                container => new CalcPresentation(
                    container.GetService<ICalcHistoryRepository>(),
                    container.GetService<IMapper>()
                    ));

            services.AddScoped(
                container => new ReflectionPresentation());

            services.AddScoped(
                container => new AddressPresentation(
                    container.GetService<IAdressRepository>(),
                    container.GetService<IMapper>(),
                    container.GetService<ISpecialUserAddressRepository>()
                    ));

            services.AddScoped(
                container => new QuestionnairePresentation(
                    container.GetService<IQuestionnaireModelRepository>(),
                    container.GetService<IQuestionnaireRegistrationRepository>(),
                    container.GetService<IQuestionnaireResultRepository>(),
                    container.GetService<IQuestionnaireResultDetailRepository>(),
                    container.GetService<IQuestionRepository>(),
                    container.GetService<IAnswerRepository>(),
                    container.GetService<IQuestionAnswerRepository>(),
                    container.GetService<IUserService>()
                    ));

            services.AddScoped(
                container => new JobPresentation(
                    container.GetService<IOrganizationRepository>(),
                    container.GetService<IPositionRepository>(),
                    container.GetService<IOrganizationPositionRepository>(),
                    container.GetService<IOrganizationPositionCandidateRepository>(),
                    container.GetService<ISpecialUserRepository>(),
                    container.GetService<IUserService>(),
                    container.GetService<IMapper>(),
                    container.GetService<IWebHostEnvironment>(),
                    container.GetService<IOfficeRepository>(), 
                    container.GetService<AddressPresentation>(), 
                    container.GetService<IAdressRepository>()
                    ));

            services.AddScoped(
                container => new KeyClassesPresentation(
                    container.GetService<IKeyClassesPresentationHelper>()
                    ));

            services.AddScoped(
                container => new RestaurantPresentation(
                    container.GetService<IMapper>(),
                    container.GetService<IUserService>(),
                    container.GetService<IDishRepository>(),
                    container.GetService<IOrderRepository>(),
                    container.GetService<IRestaurantRepository>(),
                    container.GetService<IOrderDishRepository>()
                    ));

            services.AddScoped<IKeyClassesPresentationHelper>(
                x => new KeyClassesPresentationHelper());

            services.AddScoped(
                container => new CalendarEventPresentation(
                    container.GetService<ICalendarEventRepository>(),
                    container.GetService<ISpecialUserCalendarEventRepository>(),
                    container.GetService<ICalendarTypeEventRepository>(),
                    container.GetService<IUserService>(),
                    container.GetService<IMapper>()
                    ));

            services.AddScoped(
                container => new HotelsPresentation(
                    container.GetService<IHotelRepository>(),
                    container.GetService<IMapper>(),
                    container.GetService<ISpecialUserRepository>(),
                    container.GetService<IHotelRoomRepository>(),
                    container.GetService<IUserService>(),
                    container.GetService<IHotelRoomBookingRepository>(),
                    container.GetService<ICalendarEventRepository>(),
                    container.GetService<ISpecialUserCalendarEventRepository>(),
                    container.GetService<ICalendarTypeEventRepository>()
                    ));

            services.AddScoped(
                container => new MayoraltyPresentation(
                    container.GetService<IOrganizationPositionRepository>(),
                    container.GetService<IOrganizationRepository>(),
                    container.GetService<IPositionRepository>(),
                    container.GetService<IMapper>(),
                    container.GetService<ISpecialUserRepository>()
                    ));

            services.AddScoped(
                container => new HospitalPresentation(
                    container.GetService<IMedicalRecordRepository>(),
                    container.GetService<IMedicalRecordDetailRepository>(),
                    container.GetService<IMapper>(),
                    container.GetService<ISpecialUserRepository>(),
                    container.GetService<IUserService>()
                    ));

            services.AddScoped(
                container => new FirefightersPresentation(
                    container.GetService<IFireInspectionScheduleRepository>(),
                    container.GetService<IFireInspectionBuildingRepository>(),
                    container.GetService<IBuildingTypeSafetyAssessmentRepository>(),
                    container.GetService<IAdressRepository>(),
                    container.GetService<ISpecialUserRepository>(),
                    container.GetService<IUserService>(),
                    container.GetService<IMapper>()
                    ));
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(
                container => new FileProfileService(
                        container.GetService<IWebHostEnvironment>()
                    ));
            services.AddScoped(
                container => new OpenXmlProfileService(
                        container.GetService<IWebHostEnvironment>()
                    ));
            services.AddScoped(
                container => new FiletoPDF(
                         container.GetService<IWebHostEnvironment>()
                    ));

            services.AddScoped<IUserService>(
                container => new UserService(
                        container.GetService<ISpecialUserRepository>(),
                        container.GetService<IHttpContextAccessor>(),
                        container.GetService<IOrganizationRepository>()
                    ));

            services.AddScoped<IOrganizationService>(
                container => new OrganizationService(
                        container.GetService<IOrganizationRepository>()
                    ));
        }
        private void RegisterRepository(IServiceCollection services)
        {
            //Всех наследников от BaseRepository<>
            foreach (var type in Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.BaseType?.IsGenericType == true
                    && x.BaseType.GetGenericTypeDefinition() == typeof(BaseRepository<>)))
            {
                var interfaces = type.GetInterfaces();
                var theInterface = interfaces
                    .FirstOrDefault(x =>
                        x.GetInterfaces()
                            .Any(i => i.GetGenericTypeDefinition() == typeof(IBaseRepository<>)));
                services.AddScoped(theInterface, serviceProvider =>
                {
                    // Вызваем метод консруктора
                    var constructor = type.GetConstructors().Single();

                    //var expectedParams = constructor.GetParameters();
                    //var paramForConstructor = new object[expectedParams.Length];
                    //for (int i = 0; i < expectedParams.Length; i++)
                    //{
                    //    var oneParamExpected = expectedParams[i];
                    //    var oneParamActual = serviceProvider.GetService(oneParamExpected.ParameterType);
                    //    paramForConstructor[i] = oneParamActual;
                    //}

                    var paramForConstructor =
                        constructor.GetParameters()
                            .Select(x => serviceProvider.GetService(x.ParameterType))
                            .ToArray();

                    return constructor.Invoke(paramForConstructor);
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //Кто ты?
            app.UseAuthentication();

            //Куда у тебя есть доступ?
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
