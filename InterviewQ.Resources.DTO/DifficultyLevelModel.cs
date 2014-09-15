using System;
using System.Collections.Generic;
using System.Linq;
using InterviewQ.Resources.EF.Entities;

namespace InterviewQ.Business.Models
{
    public partial class DifficultyLevelModel
    {
        public DifficultyLevelModel(DifficultyLevel difficultyLevel)
        {
            Id = difficultyLevel.Id;
            Difficulty = difficultyLevel.Difficulty.ToString();
        }

        public Guid Id { get; set; }
        public string Difficulty { get; set; }
        public virtual ICollection<TestQuestionModel> Questions { get; set; }
    }
}
