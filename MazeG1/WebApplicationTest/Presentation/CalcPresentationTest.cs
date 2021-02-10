using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;
using WebApplication.Models;
using WebApplication.Presentation;
using WebApplication.Sevrice;

namespace WebApplicationTest.Presentation
{
    public class CalcPresentationTest
    {
        private CalcPresentationPublic _calcPresentation;
        private Mock<ICalcHistoryRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<ICalcHistoryRepository>();
            _mapperMock = new Mock<IMapper>();
            _calcPresentation = new CalcPresentationPublic(_repositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public void GetAllCalcHistory()
        {
            var calcHistory = new List<CalcHistory>();
            _repositoryMock.Setup(x => x.GetAll()).Returns(calcHistory.AsQueryable());

            _calcPresentation.GetAllCalcHistory();

            _repositoryMock.Verify(x =>
                x.GetAll(),
                Times.Once);
            _mapperMock.Verify(x =>
                x.Map<List<CalcHistoryViewModel>>(It.IsAny<List<CalcHistory>>()),
                Times.Once);
        }

        [Test]
        public void Save()
        {
            var calcHistory = new CalcHistory();

            var calcHistoryList = new List<CalcHistory> { calcHistory };
            _repositoryMock.Setup(x => x.GetAll()).Returns((IQueryable<CalcHistory>)calcHistoryList);
            
            _calcPresentation.Save(calcHistory);

            _repositoryMock.Verify(x => x.Save(calcHistory), Times.Once);
        }

        [Test]
        public void Clear()
        {
            _calcPresentation.Clear();

            _repositoryMock.Verify(x => x.Clear(), Times.Once);
        }

        [Test]
        public void GetCalcViewModel()
        {
            var model = _calcPresentation.GetCalcViewModel();

            _repositoryMock.Verify(x =>
                x.GetAll(),
                Times.Once);
            _mapperMock.Verify(x =>
                x.Map<List<CalcHistoryViewModel>>(It.IsAny<List<CalcHistory>>()),
                Times.Once);
        }

        [Test]
        [TestCase(1, 2, Oper.Addition, 3)]
        public void GetCalcViewModel_withParam(float num1, float num2, Oper oper, float answer)
        {
            var calcViewModel = new CalcViewModel { 
                Number1 = num1, Number2 = num2,  Operation = oper };

            var model = _calcPresentation.GetCalcViewModel(calcViewModel);

            Assert.AreEqual(answer, model.Answer);

            _repositoryMock.Verify(x =>
                x.GetAll(),
                Times.Once);
            _mapperMock.Verify(x =>
                x.Map<List<CalcHistoryViewModel>>(It.IsAny<List<CalcHistory>>()),
                Times.Once);
        }

        [Test]
        [TestCase(1, 2, Oper.Addition, 3)]
        public void GetCalcHistory(int num1, int num2, Oper oper, float answer)
        {
            var calcHistory = new CalcHistory
            {
                Number1 = num1,
                Number2 = num2,
                Operation = oper
            };
            var calcHistoryViewModel = new CalcHistoryViewModel
            {
                Number1 = num1,
                Number2 = num2,
                Operation = oper,
                Answer = answer
            };
            _mapperMock.Setup(m => m.Map<CalcHistory>(It.IsAny<CalcViewModel>()))
                .Returns(calcHistory);
            _mapperMock.Setup(m => m.Map<CalcHistoryViewModel>(It.IsAny<CalcHistory>()))
                .Returns(calcHistoryViewModel);

            var modelCalcHistory = _calcPresentation.GetCalcHistory(num1, num2, (int)oper);

            Assert.AreEqual(answer, modelCalcHistory.Answer);
            _repositoryMock.Verify(x => x.Save(calcHistory), Times.Once);
            _mapperMock.Verify(x =>
                x.Map<CalcHistory>(It.IsAny<CalcViewModel>()), Times.Once);
            _mapperMock.Verify(x =>
                x.Map<CalcHistoryViewModel>(It.IsAny<CalcHistory>()), Times.Once);
        }

        [Test]
        public void GetViewModelForPDF()
        {
            var model = _calcPresentation.GetViewModelForPDF();

            _repositoryMock.Verify(x =>
                x.GetAll(),
                Times.Once);
            _mapperMock.Verify(x =>
                x.Map<List<CalcHistoryViewModel>>(It.IsAny<List<CalcHistory>>()),
                Times.Once);
        }

        [Test]
        public void GetCalcHistoryByCalcViewModel()
        {
            var model = new CalcViewModel();
            var calcHistory = _calcPresentation.GetCalcHistoryByCalcViewModelPublic(model);

            _mapperMock.Verify(x => x.Map<CalcHistory>(model), Times.Once);
        }

        [Test]
        [TestCase(Oper.Addition, 1, 2, 3)]
        [TestCase(Oper.Subtraction, 1, 2, -1)]
        [TestCase(Oper.Multiplication, 1, 2, 2)]
        [TestCase(Oper.Division, 1, 2, 0.5f)]
        public void GetResult(Oper operation, float number1, float number2, float answer)
        {
            var calcViewModel = new CalcViewModel { 
                Operation = operation, Number1 = number1, Number2 = number2 };

            var res = _calcPresentation.GetResultPublic(calcViewModel);

            Assert.AreEqual(answer, res);
        }

        private class CalcPresentationPublic : CalcPresentation
        {
            public CalcPresentationPublic(
                ICalcHistoryRepository calcHistoryRepository,
                IMapper mapper)
                : base(calcHistoryRepository, mapper)
            { }

            public float GetResultPublic(CalcViewModel calcViewModel)
            {
                return GetResult(calcViewModel);
            }
            public CalcHistory GetCalcHistoryByCalcViewModelPublic(CalcViewModel model)
            {
                return GetCalcHistoryByCalcViewModel(model);
            }
        }
    }
}
