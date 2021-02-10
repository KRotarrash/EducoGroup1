using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questionnaire.Generator;
using WebApplication.DbStuff;
using WebApplication.DbStuff.Model.Questionnaire;
using WebApplication.DbStuff.Repository.Questionnaire;
using WebApplication.Models;
using WebApplication.Presentation.Questionnaire;

namespace WebApplication.Controllers
{
    [Authorize]
    public class QuestionnaireController : Controller
    {
        QuestionnairePresentation _presentation;

        public QuestionnaireController(QuestionnairePresentation questionnairePresentation)
                                       
        {
            _presentation = questionnairePresentation;           
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _presentation.GetManageQuestionnairesViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult Questionnaire(long id)
        {
            var model = _presentation.GetQuestionnaireViewModel(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveQuestionnaire(QuestionnaireViewModel model)
        {
            _presentation.SaveQuestionnaire(model);
            return RedirectToAction("Results", "Questionnaire");
        }

        [HttpGet]
        public IActionResult NewQuestionnaire()
        {
            var model = new AddQuestionnaireViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult NewQuestionnaireSave(AddQuestionnaireViewModel model)
        {
            _presentation.NewQuestionnaireSave(model);
            return RedirectToAction("Index", "Questionnaire");
        }

        public IActionResult Results()
        {
            var model = _presentation.GetResultViewModel();
            return View(model);
        }
    }
}
