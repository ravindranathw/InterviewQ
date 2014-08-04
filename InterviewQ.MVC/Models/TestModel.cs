using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewQ.MVC.Models
{
    [Serializable]
    public class TestModel
    {
        public int TestID { get; set; }
        public string TestName { get; set; }

        public string Instructions { get; set; }

        public double TestTime { get; set; }

        public int CurrentQuestionID { get; set; }

        public List<QuestionModel> Questions { get; set; }
    }

    public class QuestionModel
    {
        public int QuestionID { get; set; }
        public string Question { get; set; }
    }
}