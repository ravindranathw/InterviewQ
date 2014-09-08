using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InterviewQ.Resources.EF.Entities;

namespace InterviewQ.Resources.Data.RepositoryContracts
{
    public interface ITestRepository
    {
        TestModel GetById(Guid id);

        TestModel GetGeneratedTest(int numberOfQuestions, Category category, DifficultyLevelEnum difficultyLevel);

        Task<TestModel> GetByIdAsync(Guid id);
        IList<TestModel> Get(Expression<Func<Test, bool>> predicate = null);
        Task<IList<TestModel>> GetAsync(Expression<Func<Test, bool>> predicate = null);

    }
}
