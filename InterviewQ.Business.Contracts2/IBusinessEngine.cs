using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewQ.Business.Models;
using InterviewQ.Resources.EF.Entities;

namespace InterviewQ.Business.Contracts
{
    public interface ITestBusinessEngine
    {
        TestModel GetGeneratedTest(int numberOfQuestions, CategoryModel category,
            TestDifficultyLevel difficultyLevel);

        IList<CategoryModel> GetCategories();

        IList<DifficultyLevelModel> GetDifficultyLevelModels();
    }
}
