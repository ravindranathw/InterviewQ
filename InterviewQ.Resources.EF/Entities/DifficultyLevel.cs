using System;
using System.Collections.Generic;

namespace InterviewQ.Resources.EF.Entities
{
    public enum DifficultyLevelEnum
    {
        Easy=0,
        Medium=1,
        Hard=2,
        VeryHard=3,
    }

    public partial class DifficultyLevel
    {
        public DifficultyLevel()
        {
            this.Questions = new List<TestQuestion>();
        }

        public Guid Id { get; set; }
        public DifficultyLevelEnum Difficulty { get; set; }
        public virtual ICollection<TestQuestion> Questions { get; set; }
    }
}
