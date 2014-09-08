using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewQ.Resources.EF.Entities
{
    public partial class CategoryModel
    {
        public CategoryModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
            this.Questions = category.Questions.Select(q => new TestQuestionModel(q)).ToList();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TestQuestionModel> Questions { get; set; }
    }
}
