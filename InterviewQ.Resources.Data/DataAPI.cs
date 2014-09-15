using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewQ.Resources.Data.Repositories;
using InterviewQ.Resources.Data.RepositoryContracts;
using InterviewQ.Resources.EF.Entities;
using InterviewQ.Resources.EF.Models;

namespace InterviewQ.Resources.Data
{
    public class DataApi
    {
        public DataApi()
        {
            var dbContext = new InterviewQContext();
            Tests = new TestRepository(dbContext);
            Questions = new QuestionRepository(dbContext);
            DifficultyLevels = new DifficultyLevelRepository(dbContext);
            Catagories = new CatagoryRepository(dbContext);

        }
        public ITestRepository Tests { get; private set; }
        public IQuestionRepository Questions { get; private set; }

        public IDifficultyLevelRepository DifficultyLevels { get; private set; }

        public ICatagoryRepository Catagories { get; private set; }
    }
}
