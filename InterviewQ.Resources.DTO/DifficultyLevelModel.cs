using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewQ.Resources.EF.Entities
{
    public partial class DifficultyLevelModel
    {
        public DifficultyLevelModel(DifficultyLevel difficultyLevel)
        {
            this.Questions = difficultyLevel.Questions.Select(q => new TestQuestionModel(q)).ToList();
        }

        public Guid Id { get; set; }
        public string Difficulty { get; set; }
        public virtual ICollection<TestQuestionModel> Questions { get; set; }
    }
}
