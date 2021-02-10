using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebApplication.DbStuff;
using WebApplication.DbStuff.Model.Firefighters;
using WebApplication.DbStuff.Repository;
using WebApplication.DbStuff.Repository.IRepository.IFirefighters;
using WebApplication.Models;
using WebApplication.Models.Firefighters;
using WebApplication.Service;
using WebApplication.Const;

namespace WebApplication.Presentation
{
    public class FirefightersPresentation
    {
        private IFireInspectionScheduleRepository _fireInspectionScheduleRepository;
        private IFireInspectionBuildingRepository _fireInspectionBuildingRepository;
        private IBuildingTypeSafetyAssessmentRepository _buildingTypeSafetyAssessmentRepository;
        private IAdressRepository _adressRepository;
        private ISpecialUserRepository _specialUserRepository;
        private IUserService _userService;
        private IMapper _mapper;

        private const int _dayInspections = 30;
        private const int _scaleMaxCountInspections = 20;


        public FirefightersPresentation(
            IFireInspectionScheduleRepository fireInspectionScheduleRepository,
            IFireInspectionBuildingRepository fireInspectionBuildingRepository,
            IBuildingTypeSafetyAssessmentRepository buildingTypeSafetyAssessmentRepository,
            IAdressRepository adressRepository,
            ISpecialUserRepository specialUserRepository,
            IUserService userService,
            IMapper mapper)
        {
            _fireInspectionScheduleRepository = fireInspectionScheduleRepository;
            _fireInspectionBuildingRepository = fireInspectionBuildingRepository;
            _buildingTypeSafetyAssessmentRepository = buildingTypeSafetyAssessmentRepository;
            _adressRepository = adressRepository;
            _specialUserRepository = specialUserRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public ManageFireInspectionsViewModel GetViewModelIndex(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            var viewModel = new ManageFireInspectionsViewModel()
            {
                FireInspectionsBuilding = GetListFireInspectionBuildingViewModel(page, pageSize, sortColumn, sortDirection,
                         DateTime.Now.AddDays(-_dayInspections), DateTime.Now.AddDays(_dayInspections)),
                FireInspectionsSchedule = GetListFireInspectionScheduleViewModel(page, pageSize, sortColumn, sortDirection,
                         DateTime.MinValue, DateTime.MaxValue),
                FireInspectionYear = GetFireInspectionYears(),
            };

            return viewModel;
        }

        private FireInspectionBuildingViewModels GetListFireInspectionBuildingViewModel(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection,
            DateTime from, DateTime to)
        {
            var fireInspectionsBuilding = _fireInspectionBuildingRepository.GetByDateRange(from, to);
            var inspectionsTotalRecordCount = fireInspectionsBuilding.Count();
            fireInspectionsBuilding = SortAndTakePage(fireInspectionsBuilding, page, pageSize, sortColumn, sortDirection);

            var viewModel = new FireInspectionBuildingViewModels()
            {
                FireInspectionsBuilding = GetFireInspectionBuildingViewModels(fireInspectionsBuilding),
                CurrentUser = _userService.GetCurrentUser(),
                PaginatorInfo = GetPaginatorInfoViewModel(inspectionsTotalRecordCount, page, pageSize, sortColumn, sortDirection),
                SortViewModel = new SortViewModel(sortColumn, sortDirection)
            };
            return viewModel;
        }

        private FireInspectionScheduleViewModels GetListFireInspectionScheduleViewModel(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection,
            DateTime from, DateTime to)
        {
            var fireInspectionsSchedule = _fireInspectionScheduleRepository.GetByDateRange(from, to);
            var inspectionsTotalRecordCount = fireInspectionsSchedule.Count();
            fireInspectionsSchedule = SortAndTakePage(fireInspectionsSchedule, page, pageSize, sortColumn, sortDirection);

            var viewModel = new FireInspectionScheduleViewModels()
            {
                FireInspectionsSchedule = GetFireInspectionScheduleViewModels(fireInspectionsSchedule),
                PaginatorInfo = GetPaginatorInfoViewModel(inspectionsTotalRecordCount, page, pageSize, sortColumn, sortDirection),
                SortViewModel = new SortViewModel(sortColumn, sortDirection)
            };
            return viewModel;
        }

        private IQueryable<FireInspectionBuilding> SortAndTakePage(IQueryable<FireInspectionBuilding> fireInspectionsBuilding, 
            int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            fireInspectionsBuilding = Sort(fireInspectionsBuilding, sortColumn, sortDirection);
            fireInspectionsBuilding = fireInspectionsBuilding.Skip(page * pageSize)
                    .Take(pageSize);
            return fireInspectionsBuilding;
        }

        private IQueryable<FireInspectionSchedule> SortAndTakePage(IQueryable<FireInspectionSchedule> fireInspectionsSchedule, 
            int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            fireInspectionsSchedule = Sort(fireInspectionsSchedule, sortColumn, sortDirection);
            fireInspectionsSchedule = fireInspectionsSchedule.Skip(page * pageSize)
                    .Take(pageSize);
            return fireInspectionsSchedule;
        }

        private PaginatorInfoViewModel GetPaginatorInfoViewModel(int inspectionsTotalRecordCount,
              int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            return new PaginatorInfoViewModel()
            {
                Page = page,
                PageSize = pageSize,
                TotalRecordCount = inspectionsTotalRecordCount,
                SortColumn = sortColumn,
                SortDirection = sortDirection,
            };
        }

        protected IQueryable<FireInspectionBuilding> Sort(IQueryable<FireInspectionBuilding> fireInspectionsBuilding, 
            SortColumn sortColumn, SortDirection sortDirection)
        {
            Expression<Func<FireInspectionBuilding, object>> condition = sortColumn switch
            {
                SortColumn.Id => (s => s.Id),
                SortColumn.City => (s => s.BuildingAdress.City),
                SortColumn.Street => (s => s.BuildingAdress.Street),
                SortColumn.HouseNumber => (s => s.BuildingAdress.HouseNumber),
                SortColumn.NameOfTypeSafetyAssessment => (s => s.BuildingTypeSafetyAssessment.NameOfTypeSafetyAssessment),
                SortColumn.DateInspection => (s => s.DateInspection),
                SortColumn.FireInspectionPeriodicity => null,
            };

            if (sortDirection == SortDirection.DESC)
            {
                fireInspectionsBuilding = fireInspectionsBuilding.OrderByDescending(condition);
            }
            else
            {
                fireInspectionsBuilding = fireInspectionsBuilding.OrderBy(condition);
            }

            return fireInspectionsBuilding;
        }

        protected IQueryable<FireInspectionSchedule> Sort(IQueryable<FireInspectionSchedule> fireInspectionsSchedule, 
            SortColumn sortColumn, SortDirection sortDirection)
        {
            Expression<Func<FireInspectionSchedule, object>> condition = sortColumn switch
            {
                SortColumn.Id => (s => s.Id),
                SortColumn.City => (s => s.BuildingAdress.City),
                SortColumn.Street => (s => s.BuildingAdress.Street),
                SortColumn.HouseNumber => (s => s.BuildingAdress.HouseNumber),
                SortColumn.FireInspectionPeriodicity => (s => s.FireInspectionPeriodicity),
                SortColumn.DateInspectionSchedule => (s => s.DateInspectionSchedule),
                SortColumn.NameOfTypeSafetyAssessment => null,
            };

            if (sortDirection == SortDirection.DESC)
            {
                fireInspectionsSchedule = fireInspectionsSchedule.OrderByDescending(condition);
            }
            else
            {
                fireInspectionsSchedule = fireInspectionsSchedule.OrderBy(condition);
            }

            return fireInspectionsSchedule;
        }

        public void SaveFireInspectionBuilding(FireInspectionBuildingAddOrEditViewModel model)
        {
            var fireInspectionBuilding = _mapper.Map<FireInspectionBuilding>(model);
            fireInspectionBuilding.BuildingAdress = _adressRepository.Get(model.BuildingAdressId);
            fireInspectionBuilding.BuildingTypeSafetyAssessment = _buildingTypeSafetyAssessmentRepository
                .Get(model.BuildingTypeSafetyAssessmentId);
            fireInspectionBuilding.PerformedFireInspectionBuildingByUser = GetUserOfFireInspectionBuilding(model.OwnerId);
            _fireInspectionBuildingRepository.Save(fireInspectionBuilding);
        }

        public void SaveFireInspectionSchedule(FireInspectionScheduleAddOrEditViewModel model)
        {
            var fireInspectionSchedule = _mapper.Map<FireInspectionSchedule>(model);
            fireInspectionSchedule.BuildingAdress = _adressRepository.Get(model.BuildingAdressId);
            fireInspectionSchedule.FireInspectionPeriodicity = model.FireInspectionPeriodicity;
            _fireInspectionScheduleRepository.Save(fireInspectionSchedule);
        }

        public void RemoveFireInspectionBuilding(long Id)
        {
            _fireInspectionBuildingRepository.Remove(Id);
        }

        public void RemoveFireInspectionSchedule(long Id)
        {
            _fireInspectionScheduleRepository.Remove(Id);
        }

        private List<FireInspectionBuildingViewModel> GetFireInspectionBuildingViewModels(IQueryable<FireInspectionBuilding> fireInspectionsBuilding = null)
        {
            if (fireInspectionsBuilding == null)
            {
                fireInspectionsBuilding = _fireInspectionBuildingRepository.GetAll();
            }
            return _mapper.Map<List<FireInspectionBuildingViewModel>>(fireInspectionsBuilding.ToList());
        }

        private List<FireInspectionScheduleViewModel> GetFireInspectionScheduleViewModels(IQueryable<FireInspectionSchedule> fireInspectionsSchedule = null)
        {
            if (fireInspectionsSchedule == null)
            {
                fireInspectionsSchedule = _fireInspectionScheduleRepository.GetAll();
            }
            return _mapper.Map<List<FireInspectionScheduleViewModel>>(fireInspectionsSchedule.ToList());
        }

        public FireInspectionBuildingAddOrEditViewModel GetFireInspectionBuildingViewModelById(long id)
        {
            var viewModel = new FireInspectionBuildingAddOrEditViewModel();
            if (id > 0)
            {
                var fireInspectionBuilding = _fireInspectionBuildingRepository.Get(id);
                viewModel = _mapper.Map<FireInspectionBuildingAddOrEditViewModel>(fireInspectionBuilding);
            }
            else
            {
                viewModel.BuildingAdressId = GetBuildingAdressIdDefaultViewModel();
                viewModel.BuildingTypeSafetyAssessmentId = _buildingTypeSafetyAssessmentRepository
                            .GetById(HostSeed.idSafetyAssessmentSafe).Id;
                viewModel.NameOfTypeSafetyAssessment = HostSeed.SafetyAssessmentSafe;
            }
            viewModel.OwnerId = _userService.GetCurrentUser().Id;
            viewModel.BuildingAdresses = GetBuildingAdressesViewModel();
            viewModel.BuildingTypeSafetyAssessments = GetBuildingTypeSafetyAssessmentsViewModel();

            return viewModel;
        }

        public FireInspectionScheduleAddOrEditViewModel GetFireInspectionScheduleViewModelById(long id)
        {
            var viewModel = new FireInspectionScheduleAddOrEditViewModel();
            if (id > 0)
            {
                var fireInspectionSchedule = _fireInspectionScheduleRepository.Get(id);
                viewModel = _mapper.Map<FireInspectionScheduleAddOrEditViewModel>(fireInspectionSchedule);
            }
            else
            {
                viewModel.BuildingAdressId = GetBuildingAdressIdDefaultViewModel();
                viewModel.FireInspectionPeriodicity = HostSeed.PeriodicityDefault;

            }
            viewModel.BuildingAdresses = GetBuildingAdressesViewModel();

            return viewModel;
        }

        public List<AdressViewModel> GetBuildingAdressesViewModel()
        {
            return _mapper.Map<List<AdressViewModel>>(
                _adressRepository
                .GetAll()
                .ToList());
        }

        private long GetBuildingAdressIdDefaultViewModel()
        {
            return _adressRepository.GetAdressIdDefaultForFireInspection(HostSeed.AdressCityDefault,
                HostSeed.AdressStreetDefault, HostSeed.AdressHouseNumberDefault);
        }

        public List<BuildingTypeSafetyAssessmentViewModel> GetBuildingTypeSafetyAssessmentsViewModel(IQueryable<BuildingTypeSafetyAssessment> buildingTypeSafetyAssessments = null)
        {
            if (buildingTypeSafetyAssessments == null)
            {
                buildingTypeSafetyAssessments = _buildingTypeSafetyAssessmentRepository.GetAll();
            }
            return _mapper.Map<List<BuildingTypeSafetyAssessmentViewModel>>(buildingTypeSafetyAssessments.ToList());
        }

        public BuildingTypeSafetyAssessmentViewModel GetBuildingTypeSafetyAssessmentViewModelById(long id)
        {
            var viewModel = new BuildingTypeSafetyAssessmentViewModel();
            if (id != 0)
            {
                var buildingTypeSafetyAssessment = _buildingTypeSafetyAssessmentRepository.Get(id);
                viewModel = _mapper.Map<BuildingTypeSafetyAssessmentViewModel>(buildingTypeSafetyAssessment);
            }
            return viewModel;
        }

        private SpecialUserFireInspection GetUserOfFireInspectionBuilding(long id)
        {
            return new SpecialUserFireInspection
            {
                User = _specialUserRepository.Get(id)
            };
        }

        public void SaveBuildingTypeSafetyAssessment(BuildingTypeSafetyAssessmentViewModel model)
        {
            var buildingTypeSafetyAssessment = _mapper.Map<BuildingTypeSafetyAssessment>(model);
            _buildingTypeSafetyAssessmentRepository.Save(buildingTypeSafetyAssessment);
        }

        public FireInspectionBuildingChartDataViewModel GetChartData(int fireInspectionBuildingYear)
        {
            var countInspectionsByMonth = new List<int>();
            for (int i = 0; i < CustomConst.CountMonth; i++)
            {
                countInspectionsByMonth.Add(0);
            }

            _fireInspectionBuildingRepository
                 .GetByYear(fireInspectionBuildingYear)
                 .Select(x => x.DateInspection)
                 .ToList()
                 .ForEach(x => countInspectionsByMonth[x.Month - 1]++);

            var countInspectionsStep = GetInspectionsStep(countInspectionsByMonth);
            var countInspections = countInspectionsByMonth.Max(x => x);

            countInspections = countInspections % _scaleMaxCountInspections == 0 || countInspections < _scaleMaxCountInspections
                ? countInspections + countInspectionsStep
                : countInspections;

            return new FireInspectionBuildingChartDataViewModel
            {
                CountInspections = countInspections,
                CountInspectionsStep = countInspectionsStep,
                CountInspectionsByMonth = countInspectionsByMonth
            };
        }

        private int GetInspectionsStep(List<int> countInspectionsByMonth)
        {
            var maxCountInspectionsByMonth = countInspectionsByMonth.Max(x => x);
            double dMaxCountInspectionsByMonth = maxCountInspectionsByMonth;
            double step = (double)dMaxCountInspectionsByMonth / _scaleMaxCountInspections;

            return step < 1
                 ? 1
                 : maxCountInspectionsByMonth / _scaleMaxCountInspections + 1;
        }

        private FireInspectionYearViewModel GetFireInspectionYears()
        {
            var fireInspectionYears = _fireInspectionBuildingRepository
                 .GetUniqInspectionYears()
                 .ToList();

            return new FireInspectionYearViewModel
            {
                Years = fireInspectionYears
            };
        }
    }
}
