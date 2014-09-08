using System;
using System.Collections.Generic;

namespace InterviewQ.Resources.EF.Entities
{
    public partial class DifficultyLevel
    {
        public DifficultyLevel()
        {
            this.Questions = new List<TestQuestion>();
        }

        public Guid Id { get; set; }
        public string Difficulty { get; set; }
        public virtual ICollection<TestQuestion> Questions { get; set; }
    }
}
