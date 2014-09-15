using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using InterviewQ.Business;
using InterviewQ.MVC.Models;

namespace InterviewQ.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var testBusinessEngine = new TestBusinessEngine();
            var homeViewModel = new HomeViewModel()
            {
                CategoryModels = testBusinessEngine.GetCategories(),
                TestDifficultyLevelsLevels = testBusinessEngine.GetTestDifficultyLevels()
            };

            return View(homeViewModel);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel model)
        {
            if (TryValidateModel(model))
            {
                var testEngine = new TestBusinessEngine();
                testEngine.GetGeneratedTest(model.NumberOfQuestions, model.SelectedCatagoryID, model.SelectedDifficultyLevelID);
                return View();
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}