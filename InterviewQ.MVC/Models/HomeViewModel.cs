using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewQ.Business.Contracts;
using InterviewQ.Business.Models;

namespace InterviewQ.MVC.Models
{
    public class HomeViewModel
    {
        internal protected IList<CategoryModel> CategoryModels { get; set; }

        internal protected IList<TestDifficultyLevelModel>  TestDifficultyLevelsLevels { get; set; } 

        [DisplayName("Catagory :")]
        public Guid SelectedCatagoryID { get; set; }

        public IEnumerable<SelectListItem> Catagories
        {
            get { return new SelectList(CategoryModels, "Id", "Name"); }
        }

        public int SelectedDifficultyLevelID { get; set; }

        public IEnumerable<SelectListItem> DifficultyLevels
        {
            get { return new SelectList(TestDifficultyLevelsLevels, "Id", "Difficulty"); }
        }
        public int NumberOfQuestions { get; set; }
    }
}