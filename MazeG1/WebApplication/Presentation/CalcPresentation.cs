using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;
using WebApplication.Models;

namespace WebApplication.Presentation
{
    public class CalcPresentation
    {
        private ICalcHistoryRepository _repository;
        private IMapper _mapper;

        public CalcPresentation(ICalcHistoryRepository calcHistoryRepository,
            IMapper mapper)
        {
            _repository = calcHistoryRepository;
            _mapper = mapper;
        }

        public List<CalcHistoryViewModel> GetAllCalcHistory()
        {
            var history = _repository.GetAll();
            return _mapper.Map<List<CalcHistoryViewModel>>(history.ToList());
        }

        public void Save(CalcHistory calcHistory)
        {
            _repository.Save(calcHistory);
        }

        public void Clear()
        {
            _repository.Clear();
        }

        public CalcViewModel GetCalcViewModel()
        {
            var model = new CalcViewModel();
            model.CalcHistory = GetAllCalcHistory();
            return model;
        }

        public CalcViewModel GetCalcViewModel(CalcViewModel calcViewModel)
        {
            calcViewModel.Answer = GetResult(calcViewModel);
            var newCalcHistory = GetCalcHistoryByCalcViewModel(calcViewModel);
            Save(newCalcHistory);

            calcViewModel.CalcHistory = GetAllCalcHistory();
            return calcViewModel;
        }

        protected float GetResult(CalcViewModel calcViewModel)
        {
            switch (calcViewModel.Operation)
            {
                case Oper.Division:
                    return calcViewModel.Number1 / calcViewModel.Number2;
                case Oper.Multiplication:
                    return calcViewModel.Number1 * calcViewModel.Number2;
                case Oper.Addition:
                    return calcViewModel.Number1 + calcViewModel.Number2;
                case Oper.Subtraction:
                    return calcViewModel.Number1 - calcViewModel.Number2;
                default:
                    throw new Exception("Неизвестная операция!");
            }
        }

        public CalcHistoryViewModel GetCalcHistory(int num1, int num2, int operation)
        {
            var model = new CalcViewModel()
            {
                Number1 = num1,
                Number2 = num2,
                Operation = (Oper)operation
            };
            model.Answer = GetResult(model);

            var newCalcHistory = GetCalcHistoryByCalcViewModel(model);
            Save(newCalcHistory);
            var modelCalcHistory = _mapper.Map<CalcHistoryViewModel>(newCalcHistory);
            return modelCalcHistory;
        }

        public CalcViewModel GetViewModelForPDF()
        {
            var model = new CalcViewModel();
            model.CalcHistory = GetAllCalcHistory();
            return model;
        }

        protected CalcHistory GetCalcHistoryByCalcViewModel(CalcViewModel model)
        {
            var calcHistory = _mapper.Map<CalcHistory>(model);
            return calcHistory;
        }
    }
}
