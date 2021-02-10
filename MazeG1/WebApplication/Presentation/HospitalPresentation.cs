using AutoMapper;
using AutoMapper.Internal;
using DbFile.Model;
using MazeCore;
using MazeCore.CellStuff;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebApplication.DbStuff;
using WebApplication.DbStuff.Model.Hospital;
using WebApplication.DbStuff.Repository;
using WebApplication.DbStuff.Repository.IRepository.IJob;
using WebApplication.Models;
using WebApplication.Models.KeyClasses;
using WebApplication.Service;

namespace WebApplication.Presentation
{
    public class HospitalPresentation
    {
        private IMedicalRecordRepository _medicalRecordRepository;
        private IMedicalRecordDetailRepository _medicalRecordDetailRepository;
        private IMapper _mapper;
        private ISpecialUserRepository _specialUserRepository;
        private IUserService _userService;

        public HospitalPresentation(IMedicalRecordRepository medicalRecordRepository,
            IMedicalRecordDetailRepository medicalRecordDetailRepository,
            IMapper mapper,
            ISpecialUserRepository specialUserRepository,
            IUserService userService)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _medicalRecordDetailRepository = medicalRecordDetailRepository;
            _specialUserRepository = specialUserRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public ManagePatientsViewModel GetViewModelIndex(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            var records = _medicalRecordRepository
               .GetAll();
            records = Sort(records, sortColumn, sortDirection);

            records = records.Skip(page * pageSize)
                .Take(pageSize);

            var viewModel = GetManagePatientsViewModel(records, page, pageSize, sortColumn, sortDirection);
            return viewModel;
        }

        protected IQueryable<MedicalRecord> Sort(IQueryable<MedicalRecord> records,
            SortColumn sortColumn, SortDirection sortDirection)
        {
            var soreted = records.OrderBy(user => user.Id);

            records = sortColumn switch
            {
                SortColumn.Id => records.OrderBy(s => s.Id),
                SortColumn.Name => records.OrderBy(s => s.Patient.Name),
                SortColumn.DateEvent => records.OrderBy(s => s.Examinations.Last().DateOfExamination),
                _ => records.OrderBy(s => s.Id),
            };
            if (sortDirection == SortDirection.DESC)
            {
                records = records.Reverse();
            }

            return records;
        }

        private ManagePatientsViewModel GetManagePatientsViewModel(IEnumerable<MedicalRecord> records,
            int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            return new ManagePatientsViewModel()
            {
                Records = GetRecordsViewModels(records),
                PaginatorInfo = GetPaginatorInfoViewModel(page, pageSize, sortColumn, sortDirection),
                SortViewModel = new SortViewModel(sortColumn, sortDirection)
            };
        }

        public List<MedicalRecordViewModel> GetRecordsViewModels(IEnumerable<MedicalRecord> records = null)
        {
            if (records == null)
            {
                records = _medicalRecordRepository.GetAll();
            }

            return _mapper.Map<List<MedicalRecordViewModel>>(records.ToList());
        }

        private PaginatorInfoViewModel GetPaginatorInfoViewModel(int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            return new PaginatorInfoViewModel()
            {
                Page = page,
                PageSize = pageSize,
                TotalRecordCount = _medicalRecordRepository.Count(),
                SortColumn = sortColumn,
                SortDirection = sortDirection,
            };
        }

        public void SaveDetail(MedicalRecordDetailViewModel model)
        {
            var recordDetail = _mapper.Map<MedicalRecordDetail>(model);
            var patient = _specialUserRepository.Get(model.PatientId);

            recordDetail.Doctor = _userService.GetCurrentUser();

            var record = _medicalRecordRepository.GetMedicalRecordByPatientId(patient.Id);
            if (record == null)
            {
                // если первый осмотр, то создаем карточку пациента
                record = new MedicalRecord()
                {
                    Patient = patient
                };
            }
            recordDetail.MedicalRecord = record;

            _medicalRecordDetailRepository.Save(recordDetail);
        }

        public MedicalRecordDetailViewModel GetRecordViewModel(long Id)
        {
            var model = new MedicalRecordDetailViewModel();
            var users = _specialUserRepository.GetAll();

            if (Id == 0)
            {
                model.PatientId = 0;
                model.DateOfExamination = DateTime.Now.Date;
                model.Users = _mapper.Map<List<UserViewModel>>(users.ToList());
            }
            else
            {
                var detail = _medicalRecordDetailRepository.Get(Id);
                model = _mapper.Map<MedicalRecordDetailViewModel>(detail);
                model.PatientId = detail.MedicalRecord.PatientId;
                model.Users = _mapper.Map<List<UserViewModel>>(users.ToList());
            }

            return model;
        }

        public ManageMedicalRecordDetailViewModel GetViewRecordViewModel(long recordId, int page, int pageSize, SortColumn sortColumn, SortDirection sortDirection)
        {
            var record = _medicalRecordRepository.Get(recordId);
            var details = _medicalRecordDetailRepository.GetMedicalRecordDetailsForRecord(recordId);
            details = Sort(details, sortColumn, sortDirection);
            details = details.Skip(page * pageSize)
                .Take(pageSize);

            var model = new ManageMedicalRecordDetailViewModel()
            {
                MedicalRecordId = recordId,
                PatientId = record.PatientId,
                PatientName = record.Patient.Name,
                Details = _mapper.Map<List<MedicalRecordDetailViewModel>>(details.ToList()),
                PaginatorInfo = GetPaginatorInfoViewModel(page, pageSize, sortColumn, sortDirection),
                SortViewModel = new SortViewModel(sortColumn, sortDirection),
            };

            return model;
        }

        protected IQueryable<MedicalRecordDetail> Sort(IQueryable<MedicalRecordDetail> details,
            SortColumn sortColumn, SortDirection sortDirection)
        {
            var soreted = details.OrderBy(user => user.Id);

            details = sortColumn switch
            {
                SortColumn.Id => details.OrderBy(s => s.Id),
                SortColumn.Name => details.OrderBy(s => s.Doctor.Name),
                SortColumn.DateEvent => details.OrderBy(s => s.DateOfExamination),
                _ => details.OrderBy(s => s.Id),
            };
            if (sortDirection == SortDirection.DESC)
            {
                details = details.Reverse();
            }

            return details;
        }

        public void RemoveRecord(long Id)
        {
            var details = _medicalRecordDetailRepository.GetMedicalRecordDetailsForRecord(Id);
            foreach (var detail in details)
            {
                _medicalRecordDetailRepository.Remove(detail.Id);
            }
            _medicalRecordRepository.Remove(Id);
        }

        public void RemoveDetail(long Id)
        {
            _medicalRecordDetailRepository.Remove(Id);
        }

        public PatientChartDataViewModel GetChartData(long patientId)
        {
            var record = _medicalRecordRepository.GetMedicalRecordByPatientId(patientId);
            var details = _medicalRecordDetailRepository.GetMedicalRecordDetailsForRecord(record.Id)
                .Where(x => x.DateOfExamination.Year == DateTime.Now.Year);

            CultureInfo ci = new CultureInfo("ru-RU");
            DateTimeFormatInfo dtfi = ci.DateTimeFormat;
            var months = dtfi.AbbreviatedMonthGenitiveNames;
            months = months.Take(months.Length - 1).ToArray();

            var countDetail = new List<int> { };
            for (int i = 0; i < HostSeed.CountMonth; i++)
            {
                countDetail.Add(details
                    .Where(x => x.DateOfExamination.Month == (i + 1))
                    .Count());
            }

            return new PatientChartDataViewModel
            {
                Months = months.ToList(),
                CountDetail = countDetail,
            };
        }
    }
}
