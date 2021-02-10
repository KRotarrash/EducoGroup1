using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;
using WebApplication.DbStuff.Repository.IRepository.IJob;
using WebApplication.Models;

namespace WebApplication.Presentation
{
    public class MayoraltyPresentation
    {
        private IOrganizationPositionRepository _organizationPositionRepository;
        private IOrganizationRepository _organizationRepository;
        private IPositionRepository _positionRepository;
        private IMapper _mapper;
        private ISpecialUserRepository _specialUserRepository;

        public MayoraltyPresentation(
            IOrganizationPositionRepository organizationPositionRepository,
            IOrganizationRepository organizationRepository,
            IPositionRepository positionRepository,
            IMapper mapper,
            ISpecialUserRepository specialUserRepository)
        {
            _organizationPositionRepository = organizationPositionRepository;
            _organizationRepository = organizationRepository;
            _positionRepository = positionRepository;
            _specialUserRepository = specialUserRepository;
            _mapper = mapper;
        }

        public OrganizationViewModel GetOrganizationViewModel(string organizationName)
        {
            var organization = _organizationRepository.GetOrganizationByName(organizationName);

            if (organization == null)
            {
                return new OrganizationViewModel();
            }

            var viewModel = new OrganizationViewModel()
            {
                Id = organization.Id,
                Name = organization.Name,
                OrganizationType = organization.OrganizationType,
                OwnerId = organization.Owner?.Id ?? 0,
                Users = _mapper.Map<List<UserViewModel>>(_specialUserRepository.GetAll().ToList())
            };

            return viewModel;
        }

        public void UpdateOrganizationForUserViewModel(OrganizationViewModel model, string positionName)
        {
            var organization = _organizationRepository.Get(model.Id);            
            var position = _positionRepository.GetPositionByName(positionName);
            var organizationPosition = _organizationPositionRepository.GetOrganizationPositionDefault(organization, position);

            var specialUser = _specialUserRepository.Get(model.OwnerId);
            specialUser.CurrentWork = organizationPosition;
            _specialUserRepository.Save(specialUser);
        }

        public void SaveUser(UserViewModel model)
        {
            var newUser = new SpecialUser()
            {
                Name = model.UserName,
                Age = model.Age,
                Password = model.Password,
                WebRole = WebRole.User,
                Height = model.Height
            };
            _specialUserRepository.Save(newUser);
        }
    }
}
