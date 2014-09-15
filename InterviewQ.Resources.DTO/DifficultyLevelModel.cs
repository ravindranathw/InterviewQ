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

    public class TestDifficultyLevelModel
    {
        public TestDifficultyLevelModel(TestDifficultyLevel level)
        {
            this.Data = level;
            Id = Convert.ToInt32(level);
            Difficulty = level.ToString();
        }

        public TestDifficultyLevel Data { get; private set; }
        public int Id { get; private set; }
        public string Difficulty { get; private set; }
    }
}
