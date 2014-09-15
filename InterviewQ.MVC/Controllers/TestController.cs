using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InterviewQ.MVC.Models;

namespace InterviewQ.MVC.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index(int id)
        {
           
           var _model = _testColletion.FirstOrDefault(r => r.TestID == id);
           
            if (Session["CurrentTest"] == null)
                Session["CurrentTest"] = _model;
            
            return View(_model);
        }
        
        [HttpPost]
        public ActionResult Start(int testID)
        {
            var model = _testColletion.FirstOrDefault(r => r.TestID == testID);
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Index(TestModel test)
        {
            var model = _testColletion.FirstOrDefault(r => r.TestID == test.TestID);

            if (!string.IsNullOrWhiteSpace(Request["next"]))
            {
                if (test.CurrenQuestionModel != null)
                {
                    if (!TryUpdateModel(model))
                    {
                        return View(model);
                    }
                }
            }
            //else if (!string.IsNullOrWhiteSpace(Request["prev"]))
            //{
            //    var questionID = test.CurrenQuestionModel.QuestionID - 1;
            //    model.CurrenQuestionModel = model.Questions.FirstOrDefault(r => r.QuestionID == questionID);
            //    return View(model);
            //}
            
            return View(model);
        }

        [ChildActionOnly]
        [HttpGet]
        public ActionResult Questions(TestModel test)
        {
           // var testModel = _testColletion.Single(r => r.TestID == test.TestID);
            return PartialView("_Start", test);
        }

        [HttpPost]
        public ActionResult Questions(TestModel test, QuestionModel currentQuestionModel, FormCollection formCollection)
        {
            //var q = formCollection.Count >2 ?  formCollection.GetValues(1):null;
           
           
            //if (questionID == 0)
            //{
            //    testModel.CurrenQuestionModel = testModel.Questions.First();
            //}
            if (!string.IsNullOrWhiteSpace(Request["next"]))
            {
                var nextQuestionIndex =
                    test.Questions.FindIndex(r => r.QuestionID == test.CurrenQuestionModel.QuestionID) + 1;
                test.CurrenQuestionModel = test.Questions[nextQuestionIndex];
            }
            else if (!string.IsNullOrWhiteSpace(Request["prev"]))
            {
                var prevQuestionIndex =
                   test.Questions.FindIndex(r => r.QuestionID == test.CurrenQuestionModel.QuestionID) - 1;

                test.CurrenQuestionModel = test.Questions[prevQuestionIndex];
            }
            //else
            //{
            //   test = _testColletion.FirstOrDefault(r => r.TestID == test.TestID);
            //}
            return PartialView("_Question", test);
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
                   new QuestionModel(){QuestionID = 2, HasMultipleAnswers=true, Question = "Question 2", PossibleAnswers = new List<PossibleAnswerModel>()
                    {
                        new PossibleAnswerModel(){DisplayText = "Possible Answer 2-1"},
                        new PossibleAnswerModel(){DisplayText = "Possible Answer 2-2"},                   
                        new PossibleAnswerModel(){DisplayText = "Possible Answer 2-3"},   
                        new PossibleAnswerModel(){DisplayText = "Possible Answer 2-4"}, 
                    }},
                     new QuestionModel(){QuestionID = 3, HasMultipleAnswers=true, Question = "Question 3", PossibleAnswers = new List<PossibleAnswerModel>()
                    {
                        new PossibleAnswerModel(){DisplayText = "Possible Answer 3-1"},
                        new PossibleAnswerModel(){DisplayText = "Possible Answer 3-2"},                   
                        new PossibleAnswerModel(){DisplayText = "Possible Answer 3-3"},   
                        new PossibleAnswerModel(){DisplayText = "Possible Answer 3-4"}, 
                    }},
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