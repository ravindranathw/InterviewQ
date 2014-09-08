using System;
using System.Collections.Generic;

namespace InterviewQ.Resources.EF.Entities
{
    public class TestModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<TestQuestionModel> Questions { get; set; } 
    }

    public class TestQuestionsModel
    {
        public Guid TestID { get; set; }
        public Guid TestQuestionID { get; set; }
    }
}
