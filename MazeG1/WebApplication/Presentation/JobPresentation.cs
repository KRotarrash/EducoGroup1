using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Model.Job;
using WebApplication.DbStuff.Repository;
using WebApplication.DbStuff.Repository.IRepository.IJob;
using WebApplication.Models;
using WebApplication.Models.Users;
using WebApplication.Service;
using Position = WebApplication.DbStuff.Model.Job.Position;
using System.IO;
using WebApplication.DbStuff.Institutions;
using WebApplication.Models.Job;

namespace WebApplication.Presentation
{
    public class JobPresentation
    {
        private IOrganizationRepository _organizationRepository;
        private IPositionRepository _positionRepository;
        private IOrganizationPositionRepository _organizationPositionRepository;
        private IOrganizationPositionCandidateRepository _organizationPositionCandidateRepository;
        private ISpecialUserRepository _specialUserRepository;
        private IUserService _userService;
        private IMapper _mapper;
        private IWebHostEnvironment _hostingEnvironment;
        private IOfficeRepository _officeRepository;
        private AddressPresentation _addressPresentation;
        private IAdressRepository _adressRepository;

        public JobPresentation(IOrganizationRepository organizationRepository,
            IPositionRepository positionRepository,
            IOrganizationPositionRepository organizationPositionRepository,
            IOrganizationPositionCandidateRepository organizationPositionCandidateRepository,
            ISpecialUserRepository specialUserRepository,
            IUserService userService,
            IMapper mapper,
            IWebHostEnvironment hostingEnvironment,
            IOfficeRepository officeRepository,
            AddressPresentation addressPresentation, 
            IAdressRepository adressRepository)
        {
            _organizationRepository = organizationRepository;
            _positionRepository = positionRepository;
            _organizationPositionRepository = organizationPositionRepository;
            _organizationPositionCandidateRepository = organizationPositionCandidateRepository;
            _specialUserRepository = specialUserRepository;
            _userService = userService;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            _officeRepository = officeRepository;
            _addressPresentation = addressPresentation;
            _adressRepository = adressRepository;
        }

        public List<OrganizationViewModel> GetAllOrganizationViewModels()
        {
            var organizationDBModel = _organizationRepository.GetAll().ToList();
            var viewModels = new List<OrganizationViewModel>();
            foreach (var viewOrg in organizationDBModel)
            {
                viewModels.Add(GetOrganizationViewModel(viewOrg.Id));
            }
            return viewModels;
        }

        public OrganizationViewModel GetOrganizationViewModel(long id)
        {
            if (id > 0)
            {
                var organizationDBModel = _organizationRepository.Get(id);

                var viewModel = new OrganizationViewModel()
                {
                    Id = organizationDBModel.Id,
                    Name = organizationDBModel.Name,
                    SalaryDate = organizationDBModel.SalaryDate,
                    OrganizationType = organizationDBModel.OrganizationType,
                    OwnerId = (organizationDBModel.Owner == null ? 0 : organizationDBModel.Owner.Id),
                    StartWork = organizationDBModel.StartWork,
                    EndWork = organizationDBModel.EndWork,
                    Users = _mapper.Map<List<UserViewModel>>(_specialUserRepository.GetAll().ToList()),                    
                };

                return viewModel;
            }

            return new OrganizationViewModel();
                        
        }

        public OrganizationOfficesManagerViewModel GetOrganizationOfficesManagerViewModel(long organizationId)
        {
            var organizationDB = _organizationRepository.Get(organizationId);
            var viewModel = _mapper.Map<OrganizationOfficesManagerViewModel>(organizationDB);

            viewModel.FreeOffices = _mapper.Map<List<OfficeViewModel>>(_officeRepository.GetFreeOffices());
            viewModel.MainOffice = _mapper.Map<OfficeViewModel>(_officeRepository.GetMainOffice(organizationId));

            return viewModel;
        }

        public long GetPositionId(SpecialUser user)
        {
            return _organizationPositionRepository
                        .Get(user.CurrentWork.Id)
                        .Position.Id;
        }
        public long GetOrganizationId(SpecialUser user)
        {
            return _organizationPositionRepository
                        .Get(user.CurrentWork.Id)
                        .Organization.Id;
        }

        public PositionViewModel GetPositionViewModel(long id)
        {
            var positionDBModel = _positionRepository.Get(id);
            var positionViewModel = new PositionViewModel()
            {
                Id = positionDBModel.Id,
                Name = positionDBModel.Name,
                Salary = positionDBModel.Salary
            };
            return positionViewModel;
        }

        public JobViewModel GetJobViewModel(long id)
        {
            var jobDB = _organizationPositionRepository.Get(id);
            var organizationViewModel = GetOrganizationViewModel(jobDB.Organization.Id);
            var positionViewModel = GetPositionViewModel(jobDB.Position.Id);
            var user = _specialUserRepository.GetUserOnOrganizationPosition(jobDB.Id);
            var viewModel = new JobViewModel()
            {
                Id = jobDB.Id,
                Organization = organizationViewModel,
                Position = positionViewModel,
                User = _mapper.Map<UserViewModel>(user),
            };
            return viewModel;
        }

        public List<JobViewModel> GetAllJobViewModel()
        {
            var jobDBModels = _organizationPositionRepository.GetAll()
                .ToList()
                .Where(x => x.Organization.Name != HostSeed.OrganizationDefault)
                .OrderBy(x => x.Organization.Id);
            var viewModels = new List<JobViewModel>();
            foreach (var jobDB in jobDBModels)
            {
                viewModels.Add(GetJobViewModel(jobDB.Id));
            }
            return viewModels;

        }
        public async void MainPosterForOrgnization(IFormFile mainImgUrl, OrganizationViewModel model)
        {
            var wwwRootPath = _hostingEnvironment.WebRootPath;
            var currentOrganizationId = model.Id;

            var fileName = $"organization-{currentOrganizationId}.jpg";
            var path = Path.Combine(wwwRootPath, "organization", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await mainImgUrl.CopyToAsync(fileStream);
            }
        }

        public OfficeViewModel EditOffice(long id)
        {
            if (id <= 0)
            {
                return new OfficeViewModel()
                {
                    IsAnyAddress = _adressRepository.IsAny(),
                };
            }
            var dbOffice = _officeRepository.Get(id);
            var model = _mapper.Map<OfficeViewModel>(dbOffice);

            model.CurrentAdressId = dbOffice.Adress.Id;
            model.CurrentOrganizationId = dbOffice.Organization.Id;
            model.Addresses = _addressPresentation.GetAddressesViewModel();
            model.Organizations = GetAllOrganizationViewModels();
            model.IsAnyAddress = _adressRepository.IsAny();

            return model;
        }

        public void UpdateOffice(OfficeViewModel model)
        {
            var office = _officeRepository.Get(model.Id);

            office.Name = model.Name;
            office.Adress = _adressRepository.Get(model.CurrentAdressId);
            office.Organization = _organizationRepository.Get(model.CurrentOrganizationId);

            _officeRepository.Save(office);
        }

        public void AddOffice(OfficeViewModel model)
        {
            var result = _mapper.Map<Office>(model);
            var organizationFree = _organizationRepository.GetOrganizationByName(HostSeed.OrganizationDefault);
            result.Adress = _adressRepository.Get(model.CurrentAdressId);
            result.Organization = _organizationRepository.Get(model.CurrentOrganizationId);

            if (result.Organization.Name == HostSeed.OrganizationDefault)
            {
                result.Organization = organizationFree;
            }

            _officeRepository.Save(result);
        }

        public void RemoveOffice(long id)
        {
            _officeRepository.Remove(id);
        }

        public OfficeViewModel AddOffice()
        {
            return new OfficeViewModel()
            {
                Address = new AdressViewModel(),
                Addresses = _addressPresentation.GetAddressesViewModel(),
                Organizations = GetAllOrganizationViewModels(),
                OfficeType = OfficeType.Branch,
                IsAnyAddress = _adressRepository.IsAny()
            };
        }

        public ManagerOfficeViewModel GetManagerOfficeViewModel()
        {
            var model = new ManagerOfficeViewModel();
            model.Offices = _mapper.Map<List<OfficeViewModel>>(_officeRepository.GetAll().ToList());
            model.IsAnyAddress = _adressRepository.IsAny();

            return model;
        }

        public void AddOfficeToOrganization(OrganizationOfficesManagerViewModel viewModel)
        {
            if (viewModel.AddedOfficeId <= 0)
            {
                return;
            }
            var organizationDb = _organizationRepository.Get(viewModel.Id);
            var officeDb = _officeRepository.Get(viewModel.AddedOfficeId);
            organizationDb.Offices.Add(officeDb);
            _organizationRepository.Save(organizationDb);
            officeDb.Organization = organizationDb;
            officeDb.OfficeType = OfficeType.Branch;
            _officeRepository.Save(officeDb);
        }

        public void ExcludeOfficeFromOrganization(long officeId)
        {           
            var officeDb = _officeRepository.Get(officeId);
            officeDb.Organization = _organizationRepository.GetOrganizationByName(HostSeed.OrganizationDefault);
            officeDb.OfficeType = OfficeType.Branch;
            _officeRepository.Save(officeDb);
        }

        public void ChangeMainOffice(long officeId)
        {
            var newMainOffice = _officeRepository.Get(officeId);
            newMainOffice.OfficeType = OfficeType.Main;

            var oldMainOffice = _officeRepository.GetMainOffice(newMainOffice.Organization.Id);
            if (oldMainOffice != null)
            {
                oldMainOffice.OfficeType = OfficeType.Branch;
                _officeRepository.Save(oldMainOffice);
            }          

            _officeRepository.Save(newMainOffice);
            
        }

        public void SaveJob(JobViewModel job)
        {
            if(_organizationPositionRepository.IsPositionNameInOrganizationUnique(job.Organization.Id, job.Position.Name))
            { 
                var organization = _organizationRepository.Get(job.Organization.Id);
                var position = new Position()
                {
                    OrganizationPositions = new List<OrganizationPosition>(),
                    Name = job.Position.Name,
                    Salary = job.Position.Salary
                };

                var organizationPosition = new OrganizationPosition()
                {
                    Organization = organization,
                    Position = position
                };
                position.OrganizationPositions.Add(organizationPosition);

                _positionRepository.Save(position);
            }
        }

        public void SaveNewOrganization(OrganizationViewModel model)
        {
            if(_organizationRepository.OrganizationNameIsUniq(model.Name))
            { 
                var mainOffice = _officeRepository.Get(model.MainOffice.Id);

                switch (model.OrganizationType)
                {
                    case OrganizationType.Undefined:
                        break;
                    case OrganizationType.Restaurant:
                        var restaurant = _mapper.Map<Restaurant>(model);
                        restaurant.Owner = _specialUserRepository.Get(model.OwnerId);
                        restaurant.Offices = new List<Office>() { mainOffice };
                        _organizationRepository.Save(restaurant);
                        break;
                    case OrganizationType.Shop:
                        break;
                    case OrganizationType.BusinessСenter:
                        break;
                    default:
                        var organization = _mapper.Map<Organization>(model);
                        organization.Owner = _specialUserRepository.Get(model.OwnerId);
                        organization.Offices = new List<Office>();
                        organization.Offices.Add(mainOffice);
                        _organizationRepository.Save(organization);
                        break;
                }

                mainOffice.OfficeType = OfficeType.Main;
            }
        }

        public bool OrganizationNameIsUniq(string organizationName)
        {
            return _organizationRepository.OrganizationNameIsUniq(organizationName);
        }

        public bool OrganizationPositionIsUniq(long organizationId, string positionName)
        {
            return _organizationPositionRepository.IsPositionNameInOrganizationUnique(organizationId, positionName);
        }

        public void UpdateJob(JobViewModel job)
        {
            var position = _positionRepository.Get(job.Position.Id);
            position.Name = job.Position.Name;
            position.Salary = job.Position.Salary;
            _positionRepository.Save(position);
        }

        public void UpdateOrganization(OrganizationViewModel viewOrg)
        {
            var organization = _organizationRepository.Get(viewOrg.Id);
            organization.Name = viewOrg.Name;
            organization.SalaryDate = viewOrg.SalaryDate;
            organization.StartWork = viewOrg.StartWork;
            organization.EndWork = viewOrg.EndWork;
            organization.OrganizationType = viewOrg.OrganizationType;
            organization.Owner = _specialUserRepository.Get(viewOrg.OwnerId);
            _organizationRepository.Save(organization);
        }       

        public object GetPositions(long id)
        {
            var result = _organizationRepository
                .Get(id)
                .OrganizationPositions
                .Select(organizationPosition => new PositionViewModel()
                {
                    Id = organizationPosition.Position.Id,
                    Name = organizationPosition.Position.Name,
                }).ToList();

            return result;
        }

        public void ChangeOrganizationAdnPosition(SpecialUser user, UserViewModel model)
        {
            if (model.OrganizationId > 0 && model.PositionId > 0)
            {
                user.CurrentWork = _organizationPositionRepository
                    .GetByOrganizationAndPostionIds(model.OrganizationId, model.PositionId);
            }
        }

        public ManageVacancyViewModel GetAllVacancyViewModel(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            //var organizationPositionId = _specialUserRepository
            //    .GetUserOrganizationPositionIds();

            //var vacancies = _organizationPositionRepository
            //    .GetAll()
            //    .Where(x => !organizationPositionId.Contains(x.Id));

            var vacancies = _organizationPositionRepository.GetAvailableVacancy();

            //Если владелец организации то видит только вакансии своих организаций(ии)
            if (_userService.IsOwnerOrganization())
            {
                var vacanciesFilter = vacancies
                    .Where(x => x.Organization.Owner.Id == _userService.GetCurrentUser().Id);

                vacanciesFilter = SortJob(vacanciesFilter, sortColumn, sortDirection);
                vacanciesFilter = vacanciesFilter.Skip(page * pageSize).Take(pageSize);

                var viewModel2 = GetManageVacancyViewModel(vacanciesFilter, page, pageSize, sortColumn, sortDirection);
                return viewModel2;
            }

            //Выводит все вакансии, всех организаций
            vacancies = SortJob(vacancies, sortColumn, sortDirection);
            vacancies = vacancies.Skip(page * pageSize).Take(pageSize);

            var viewModel = GetManageVacancyViewModel(vacancies, page, pageSize, sortColumn, sortDirection);
            return viewModel;
        }

        public VacancyViewModel GetVacancyViewModel(long id)
        {
            var jobDB = _organizationPositionRepository.Get(id);
            var user = _userService.GetCurrentUser();
            var viewModel = new VacancyViewModel()
            {
                Id = jobDB.Id,
                User = _mapper.Map<UserViewModel>(user),
                OrganizationPosition = _mapper.Map<OrganizationPositionViewModel>(jobDB)
            };
            return viewModel;
        }
        public void UpdateVacancy(VacancyViewModel model)
        {
            var user = _specialUserRepository.Get(model.User.Id);
            var positionCandidate = new OrganizationPositionCandidate()
            {
                OrganizationPosition = _organizationPositionRepository.Get(model.OrganizationPosition.Id),
                User = user,
            };
            user.Vacancies.Add(positionCandidate);

            _organizationPositionCandidateRepository.Save(positionCandidate);
        }

        protected IQueryable<OrganizationPosition> SortJob(IQueryable<OrganizationPosition> vacancies,
            SortColumn sortColumn, SortDirection sortDirection)
        {
            var soreted = vacancies.OrderBy(user => user.Id);

            vacancies = sortColumn switch
            {
                SortColumn.OrganizationName => vacancies.OrderBy(s => s.Organization.Name),
                SortColumn.PositionName => vacancies.OrderBy(s => s.Position.Name),
                SortColumn.OrganizationSalaryDate => vacancies.OrderBy(s => s.Organization.SalaryDate),
                SortColumn.PositionSalary => vacancies.OrderBy(s => s.Position.Salary),
                _ => vacancies.OrderBy(s => s.Id),
            };
            if (sortDirection == SortDirection.DESC)
            {
                vacancies = vacancies.Reverse();
            }

            return vacancies;
        }

        private ManageVacancyViewModel GetManageVacancyViewModel(IEnumerable<OrganizationPosition> vacancies,
            int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            return new ManageVacancyViewModel()
            {
                Vacancies = GetAllVacancies(vacancies),
                PaginatorInfo = GetPaginatorInfoViewModel(page, pageSize, sortColumn, sortDirection),
                SortViewModel = new SortViewModel(sortColumn, sortDirection)
            };
        }

        private PaginatorInfoViewModel GetPaginatorInfoViewModel(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            var organizationPositionId = _specialUserRepository
                    .GetUserOrganizationPositionIds();

            var vacancies = _organizationPositionRepository
                .GetAll()
                .Where(x => !organizationPositionId.Contains(x.Id));

            var vacanciesFilter = vacancies.ToList().Where(x => x.Organization.Owner == _userService.GetCurrentUser());

            if (_userService.IsOwnerOrganization())
            {
                return new PaginatorInfoViewModel()
                {
                    Page = page,
                    PageSize = pageSize,
                    TotalRecordCount = vacanciesFilter.Count(),
                    SortColumn = sortColumn,
                    SortDirection = sortDirection,
                };
            }

            return new PaginatorInfoViewModel()
            {
                Page = page,
                PageSize = pageSize,
                TotalRecordCount = vacancies.Count(),
                SortColumn = sortColumn,
                SortDirection = sortDirection,
            };
        }

        public List<VacancyViewModel> GetAllVacancies(IEnumerable<OrganizationPosition> vacancies = null)
        {
            if (vacancies == null)
            {
                vacancies = _organizationPositionRepository.GetAll();
            }

            return _mapper.Map<List<VacancyViewModel>>(vacancies.ToList());
        }

        public ManageCandidateViewModel GetViewModelCandidate(long jobId, int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            var organizationPosition = _organizationPositionRepository.Get(jobId);
            if (organizationPosition.Organization.Owner == null || _userService.GetCurrentUser().Id != organizationPosition.Organization.Owner.Id)
            {
                return null;
            }
            var candidates = _organizationPositionCandidateRepository.GetCandidatesForJob(jobId);
            candidates = SortCandidate(candidates, sortColumn, sortDirection);

            candidates = candidates.Skip(page * pageSize)
                .Take(pageSize);

            var viewModel = GetManageCandidateViewModel(jobId, candidates, page, pageSize, sortColumn, sortDirection);
            return viewModel;
        }

        private ManageCandidateViewModel GetManageCandidateViewModel(long jobId, IEnumerable<OrganizationPositionCandidate> candidates,
            int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            var vacancy = _organizationPositionRepository.Get(jobId);
            return new ManageCandidateViewModel()
            {
                Vacancy = _mapper.Map<VacancyViewModel>(vacancy),
                Candidates = GetAllCandidates(candidates),
                PaginatorInfo = GetPaginatorInfoViewModel(page, pageSize, sortColumn, sortDirection),
                SortViewModel = new SortViewModel(sortColumn, sortDirection)
            };
        }

        protected IEnumerable<OrganizationPositionCandidate> SortCandidate(IEnumerable<OrganizationPositionCandidate> candidates,
            SortColumn sortColumn, SortDirection sortDirection)
        {
            var soreted = candidates.OrderBy(user =>
            {
                user.GetType();
                return user.Id;
            });

            candidates = sortColumn switch
            {
                SortColumn.OrganizationName => candidates.OrderBy(s => s.OrganizationPosition.Organization.Name),
                SortColumn.PositionName => candidates.OrderBy(s => s.OrganizationPosition.Position.Name),
                SortColumn.Name => candidates.OrderBy(s => s.User.Name),
                SortColumn.Age => candidates.OrderBy(s => s.User.Age),
                _ => candidates.OrderBy(s => s.Id),
            };
            if (sortDirection == SortDirection.DESC)
            {
                candidates = candidates.Reverse();
            }

            return candidates;
        }

        public List<OrganizationPositionCandidateViewModel> GetAllCandidates(IEnumerable<OrganizationPositionCandidate> candidates = null)
        {
            if (candidates == null)
            {
                candidates = _organizationPositionCandidateRepository.GetAll();
            }

            return _mapper.Map<List<OrganizationPositionCandidateViewModel>>(candidates.ToList());
        }

        public void ApproveCandidate(long userId, long jobId)
        {
            var user = _specialUserRepository.Get(userId);
            var vacancy = _organizationPositionRepository.Get(jobId);

            user.CurrentWork = vacancy;
            _specialUserRepository.Save(user);

            var oldCandidates = _organizationPositionCandidateRepository.GetCandidatesForJob(jobId).ToList();
            foreach (var candidate in oldCandidates)
            {
                _organizationPositionCandidateRepository.Remove(candidate.Id);
            }
        }

        public OrgJobChartDataViewModel GetChartData()
        {
            var orgs = _organizationRepository.GetAll().ToList();
            var organizationNames = orgs
                .Select(x => x.Name)
                .ToList();

            var organizationPositions = _organizationPositionRepository.GetAll().ToList();
            var countFreeJob = new List<int> { };
            var countOccupiedJob = new List<int> { };
            foreach (var org in orgs)
            {
                var countAllJob = organizationPositions.Where(x => x.Organization.Id == org.Id).Count();
                var countOccupied = _specialUserRepository.GetUserOrganizationPositionIdsByOrganization(org.Id).Count;
                countFreeJob.Add(countAllJob - countOccupied);
                countOccupiedJob.Add(countOccupied);
            }

            return new OrgJobChartDataViewModel
            {
                OrganizationNames = organizationNames,
                OccupiedJob = countOccupiedJob,
                FreeJob = countFreeJob
            };
        }

        public ManageOrganizationsViewModel GetViewModelOrganizations(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            var organizations = _organizationRepository.GetAll();
            organizations = SortOrganizations(organizations, sortColumn, sortDirection);

            organizations = organizations.Skip(page * pageSize)
                .Take(pageSize);

            var viewModel = GetManageOrganizationsViewModel(organizations, page, pageSize, sortColumn, sortDirection);
            return viewModel;
        }

        protected IQueryable<Organization> SortOrganizations(IQueryable<Organization> organizations,
            SortColumn sortColumn, SortDirection sortDirection)
        {
            var soreted = organizations.OrderBy(user => user.Id);

            organizations = sortColumn switch
            {
                SortColumn.OrganizationName => organizations.OrderBy(s => s.Name),
                SortColumn.Name => organizations.OrderBy(s => s.Owner.Name),
                _ => organizations.OrderBy(s => s.Id),
            };
            if (sortDirection == SortDirection.DESC)
            {
                organizations = organizations.Reverse();
            }

            return organizations;
        }

        private ManageOrganizationsViewModel GetManageOrganizationsViewModel(IEnumerable<Organization> organizations,
            int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            return new ManageOrganizationsViewModel()
            {
                Organizations = GetAllOrganizations(organizations),
                PaginatorInfo = GetPaginatorInfoViewModel(page, pageSize, sortColumn, sortDirection),
                SortViewModel = new SortViewModel(sortColumn, sortDirection)
            };
        }

        public List<OrganizationViewModel> GetAllOrganizations(IEnumerable<Organization> organizations = null)
        {
            if (organizations == null)
            {
                organizations = _organizationRepository.GetAll();
            }

            return _mapper.Map<List<OrganizationViewModel>>(organizations.ToList());
        }

        public OrganizationViewModel GetOrganizationViewModel()
        {
            return new OrganizationViewModel()
            {
                Users = GetUserViewModels(_specialUserRepository.GetAll()),
                FreeOffices = _mapper.Map<List<OfficeViewModel>>(_officeRepository.GetFreeOffices()),                
            };
        }

        public List<UserViewModel> GetUserViewModels(IEnumerable<SpecialUser> users = null)
        {
            if (users == null)
            {
                users = _specialUserRepository.GetAll();
            }

            return _mapper.Map<List<UserViewModel>>(users.ToList());
        }
    }
}
