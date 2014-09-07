using System;

namespace InterviewQ.Business.Entities
{
    public partial class TestQuestion
    {
        public Guid Id { get; set; }
        public Guid CategoryID { get; set; }
        public string Question { get; set; }
        public Guid DifficultyLevelID { get; set; }
        public virtual QuestionAnswer QuestionAnswer { get; set; }
        public virtual Category Category { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
    }
}
