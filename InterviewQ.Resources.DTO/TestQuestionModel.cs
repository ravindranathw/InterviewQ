using System;

namespace InterviewQ.Resources.EF.Entities
{
    public partial class TestQuestionModel
    {
        public TestQuestionModel(TestQuestion question)
        {
            this.Id = question.Id;
            CategoryID = question.CategoryID;
            Question = question.Question;
            DifficultyLevelID = question.DifficultyLevelID;
            QuestionAnswerModel = new QuestionAnswerModel(question.QuestionAnswer);
            CategoryModel = new CategoryModel(question.Category);
            DifficultyLevelModel = new DifficultyLevelModel(question.DifficultyLevel);
        }
        public Guid Id { get; set; }
        public Guid CategoryID { get; set; }
        public string Question { get; set; }
        public Guid DifficultyLevelID { get; set; }
        public virtual QuestionAnswerModel QuestionAnswerModel { get; set; }
        public virtual CategoryModel CategoryModel { get; set; }
        public virtual DifficultyLevelModel DifficultyLevelModel { get; set; }
    }
}
