using System;
using System.Collections.Generic;
using System.Linq;
using InterviewQ.Resources.EF.Entities;

namespace InterviewQ.Business.Models
{
    public enum TestDifficultyLevel
    {
        Intern=1,
        Junior=2,
        Mid=3,
        Senior=4,
        Veterant=5,
    }
    public partial class CategoryModel
    {
        public CategoryModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
