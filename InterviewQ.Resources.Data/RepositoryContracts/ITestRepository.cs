using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InterviewQ.Business.Models;
using InterviewQ.Resources.EF.Entities;

namespace InterviewQ.Resources.Data.RepositoryContracts
{
    public interface ITestRepository: IRepository<TestModel, Test>
    {
        
    }

    public interface IDifficultyLevelRepository : IRepository<DifficultyLevelModel, DifficultyLevel>
    {
        
    }
    public interface IQuestionRepository : IRepository<TestQuestionModel, TestQuestion>
    {

        /// <summary>
        /// Gives randomly ordered question list with given predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        new IList<TestQuestionModel> Get(Expression<Func<TestQuestion, bool>> predicate = null);
    }
    public interface ICatagoryRepository : IRepository<CategoryModel, Category>
    {

    }
}
