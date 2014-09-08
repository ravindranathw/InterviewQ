using System;
using System.Collections.Generic;

namespace InterviewQ.Resources.EF.Entities
{
    public partial class Category
    {
        public Category()
        {
            this.Questions = new List<TestQuestion>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TestQuestion> Questions { get; set; }
    }
}
