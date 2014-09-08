using System;

namespace InterviewQ.Resources.EF.Entities
{
    public class Test
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

    }

    public class TestQuestions
    {
        public Guid TestID { get; set; }
        public Guid TestQuestionID { get; set; }
    }
}
