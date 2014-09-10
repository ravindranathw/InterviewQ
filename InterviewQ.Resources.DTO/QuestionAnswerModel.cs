using System;
using InterviewQ.Resources.EF.Entities;

namespace InterviewQ.Business.Models
{
    public partial class QuestionAnswerModel
    {
        public QuestionAnswerModel(QuestionAnswer questionAnswer)
        {
            QuestionID = questionAnswer.QuestionID;
            Answer = questionAnswer.Answer;
            TestQuestionModel = new TestQuestionModel(questionAnswer.TestQuestion);
        }
        public Guid QuestionID { get; set; }
        public string Answer { get; set; }
        public virtual TestQuestionModel TestQuestionModel { get; set; }
    }
}
