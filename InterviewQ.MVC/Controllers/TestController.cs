using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using InterviewQ.Business.Entities;
using InterviewQ.MVC.Models;
using Microsoft.Owin.Security.Provider;

namespace InterviewQ.MVC.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index(int id)
        {
            var model = _testColletion.FirstOrDefault(r => r.TestID == id);
            return View(model);
        }

        [ChildActionOnly]
        [HttpGet]
        public ActionResult Questions(int testID)
        {
            var testModel = _testColletion.Single(r => r.TestID == testID);
            return PartialView("_Start", testModel);
        }

        [HttpPost]
        public ActionResult Questions(int testID, FormCollection formCollection, int questionID=0)
        {
            var q = formCollection.Count >2 ?  formCollection.GetValues(1):null;
            var testModel = _testColletion.FirstOrDefault(r => r.TestID == testID);
           
            if (questionID == 0)
            {
                testModel.CurrentQuestionID = 1;
            }
            else if (!string.IsNullOrWhiteSpace(Request["next"]))
            {
                testModel.CurrentQuestionID++;
            }
            else if (!string.IsNullOrWhiteSpace(Request["prev"]))
            {
                testModel.CurrentQuestionID--;
            }

            return PartialView("_Question", testModel);
        }
        private static List<TestModel> _testColletion = new List<TestModel>()
        {
            new TestModel()
            {
                TestID = 1,
                TestName = "ASP.NET",
                Instructions = "Please choose from appropriate options",
                TestTime = 2.40,
                 Questions = new List<QuestionModel>()
                {
                    new QuestionModel(){QuestionID = 1, Question = "Question 1"}
                }
                
            },
            new TestModel()
            {
                TestID = 2,
                TestName = "ASP.NET MVC",
                Instructions = "Please choose from appropriate options",
                TestTime = 1.00,
                Questions = new List<QuestionModel>()
                {
                    new QuestionModel(){QuestionID = 1, HasMultipleAnswers=true, Question = "Question 1", PossibleAnswers = new List<PossibleAnswerModel>()
                    {
                        new PossibleAnswerModel(){DisplayText = "Possible Answer 1"},
                        new PossibleAnswerModel(){DisplayText = "Possible Answer 2"},                   
                        new PossibleAnswerModel(){DisplayText = "Possible Answer 3"},   
                        new PossibleAnswerModel(){DisplayText = "Possible Answer 4"},   
                    }},
                    new QuestionModel(){QuestionID = 2, HasMultipleAnswers=true, Question = "Question 2"},
                    new QuestionModel(){QuestionID = 3, HasMultipleAnswers=true, Question = "Question 3"},
                    new QuestionModel(){QuestionID = 4, HasMultipleAnswers=true, Question = "Question 4"},
                    new QuestionModel(){QuestionID = 5, HasMultipleAnswers=true, Question = "Question 5"},
                }
            },
            new TestModel()
            {
                TestID = 3,
                TestName = "ASP.NET Spring",
                Instructions = "Please choose from appropriate options",
                TestTime = 1.00,
                 Questions = new List<QuestionModel>()
                {
                    new QuestionModel(){QuestionID = 1, Question = "Question 1"},
                    new QuestionModel(){QuestionID = 2, Question = "Question 2"},
                    new QuestionModel(){QuestionID = 3, Question = "Question 3"},
                    new QuestionModel(){QuestionID = 4, Question = "Question 4"},
                }
            },
            new TestModel()
            {
                TestID = 4,
                TestName = ".NET C#",
                Instructions = "Please choose from appropriate options",
                TestTime = 4.40,
                 Questions = new List<QuestionModel>()
                {
                    new QuestionModel(){QuestionID = 1, Question = "Question 1"},
                    new QuestionModel(){QuestionID = 2, Question = "Question 2"}
                }
            }
        };
    }
}