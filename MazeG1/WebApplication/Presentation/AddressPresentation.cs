using AutoMapper;
using DbFile.Model;
using MazeCore;
using MazeCore.CellStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;
using WebApplication.Models;
using WebApplication.Models.Address;
using WebApplication.Sevrice;

namespace WebApplication.Presentation
{
    public class AddressPresentation
    {
        private IAdressRepository _adressRepository;
        private IMapper _mapper;
        private ISpecialUserAddressRepository _specialUserAddressRepository;

        public AddressPresentation(IAdressRepository adressRepository,
           IMapper mapper, ISpecialUserAddressRepository specialUserAddressRepository)
        {
            _adressRepository = adressRepository;
            _mapper = mapper;
            _specialUserAddressRepository = specialUserAddressRepository;
        }

        public ManageAddressViewModel GetViewModelIndex(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            var adresses = _adressRepository
               .GetAll();
            adresses = Sort(adresses, sortColumn, sortDirection);

            adresses = adresses.Skip(page * pageSize)
                .Take(pageSize);

            var viewModel = new ManageAddressViewModel()
            {
                Addresses = GetUserViewModels(adresses),
                PaginatorInfo = new PaginatorInfoViewModel()
                {
                    Page = page,
                    PageSize = pageSize,
                    TotalRecordCount = _adressRepository.Count(),
                    SortColumn = sortColumn,
                    SortDirection = sortDirection,
                },
                SortViewModel = new SortViewModel(sortColumn, sortDirection)
            };

            return viewModel;
        }

        protected IQueryable<Adress> Sort(IQueryable<Adress> adresses,
            SortColumn sortColumn, SortDirection sortDirection)
        {
            var soreted = adresses.OrderBy(user => user.Id);

            adresses = sortColumn switch
            {
                SortColumn.Id => adresses.OrderBy(s => s.Id),
                SortColumn.Street => adresses.OrderBy(s => s.Street),
                SortColumn.City => adresses.OrderBy(s => s.City),
                SortColumn.HouseNumber => adresses.OrderBy(s => s.HouseNumber),
                SortColumn.FlatNumber => adresses.OrderBy(s => s.FlatNumber),
                SortColumn.Floor => adresses.OrderBy(s => s.Floor),
                _ => adresses.OrderBy(s => s.Id),
            };
            if (sortDirection == SortDirection.DESC)
            {
                adresses = adresses.Reverse();
            }
            return adresses;
        }

        public List<AdressViewModel> GetUserViewModels(IEnumerable<Adress> adresses = null)
        {
            if (adresses == null)
            {
                adresses = _adressRepository.GetAll();
            }
            return _mapper.Map<List<AdressViewModel>>(adresses.ToList());
        }

        public void AddNewAddress(AdressViewModel model)
        {
            var newUser = _mapper.Map<Adress>(model);
            _adressRepository.Save(newUser);
        }

        public AdressViewModel GetEditViewModel(long id)
        {
            var address = _adressRepository.Get(id);
            var model = _mapper.Map<AdressViewModel>(address);
            return model;
        }

        public void ChangeAddress(AdressViewModel model)
        {
            var address = _adressRepository.Get(model.Id);
            _adressRepository.Save(address);
        }
        public void ChangeAddress(long addressId, SpecialUser specialUser)
        {
            if (addressId <= 0)
            {
                return;
            }

            var address = _adressRepository.Get(addressId);

            if (_specialUserAddressRepository
                .GetAll()
                .ToList()
                .Count > 0)
            {
                var specialUserAddress =
                    _specialUserAddressRepository
                    .GetAll()
                    .FirstOrDefault(x => x.User.Id == specialUser.Id);

                specialUserAddress.Adress = address;
                _specialUserAddressRepository.Save(specialUserAddress);

                return;
            }

            var newSpecialUserAddress = new SpecialUserAddress() 
            {
                Adress = address,
                User = specialUser
            };

            _specialUserAddressRepository.Save(newSpecialUserAddress);
        }

        public List<AdressViewModel> GetAddressesViewModel()
        {
            return 
                _mapper.Map<List<AdressViewModel>>(_adressRepository.GetAll().ToList());
        }

        public AdressViewModel GetAddressViewModel(SpecialUser user)
        {
            if (user
                ?.Adresses
                .Count() > 0)
            {
                var address =
                    _specialUserAddressRepository
                    .GetAll()
                    .ToList()
                    .FirstOrDefault(x => x.User.Id == user.Id)
                    .Adress;

                return _mapper.Map<AdressViewModel>(address);
            }

            return new AdressViewModel();
        }

        public AddressChartDataViewModel GetChartData()
        {
            var adresses = _adressRepository.GetAll().ToList();
            var addressNames = adresses.Select(x => $"ул.{x.Street} д.{x.HouseNumber} кв.{x.FlatNumber}").ToList();
            var residents = adresses
                .Select(x => _specialUserAddressRepository.GetSpecialUserCountForAddress(x))
                .ToList();
            return new AddressChartDataViewModel
            {
                AddressNames = addressNames,
                Residents = residents
            };
        }
        
    }
}
