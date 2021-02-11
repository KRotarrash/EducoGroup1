using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.DbStuff;
using WebApplication.DbStuff.Model;
using WebApplication.DbStuff.Repository;
using WebApplication.Models;
using WebApplication.Presentation;
using WebApplication.Service;

namespace WebApplication.Controllers
{
    public class CalcController : Controller
    {
        private CalcPresentation _calcPresentation;
        private FiletoPDF _filetoPDF;

        public CalcController(CalcPresentation calcPresentation,
            FiletoPDF filetoPDF)
        {
            _calcPresentation = calcPresentation;
            _filetoPDF = filetoPDF;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _calcPresentation.GetCalcViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CalcViewModel calcViewModel)
        {
            var model = _calcPresentation.GetCalcViewModel(calcViewModel);
            return View(model);
        }


        public IActionResult UserDoSome(int num1, int num2)
        {
            var model = new CalcViewModel() { 
                Answer = num1 + num2
            };

            return Json(model);
        }

        public IActionResult Calculate(int num1, int num2, int operation)
        {
            var model = _calcPresentation.GetCalcHistory(num1, num2, operation);
            return Json(model);
        }

        public ActionResult DeleteTableHist()
        {
            _calcPresentation.Clear();
            return Redirect("~/Calc/Index");
        }

        public ActionResult DownloadPDF()
        {
            //сохранение существующего файла с компьютера
            var path = _filetoPDF.GetDefaultFile();

            return PhysicalFile(path,
               "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
               $"FilePDF.pdf"); //почему название файла не берется? :(
        }
   

       public ActionResult TableToPDF()
       {
            //сохранение таблицы в файл
            var model = _calcPresentation.GetViewModelForPDF();
            var path = _filetoPDF.GenerateHistory(model);

       return PhysicalFile(path,
           "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
           $"CalcHistory.docx");
        }

    }
}
