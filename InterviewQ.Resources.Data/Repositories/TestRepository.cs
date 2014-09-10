using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InterviewQ.Resources.Data.RepositoryContracts;
using InterviewQ.Resources.EF.Entities;
using InterviewQ.Resources.EF.Models;

namespace InterviewQ.Resources.Data.Repositories
{
    internal class TestRepository : BaseRepository<TestModel, Test>, ITestRepository
    {
        public TestRepository(InterviewQContext db)
            :base(db)
        {
            
        }

        #region Base class Implementations

        protected override Expression<Func<Test, bool>> Get(TestModel model)
        {
            return c => c.Id == model.Id;
        }

        protected override Expression<Func<Test, bool>> Get(Guid id)
        {
            return c => c.Id == id;
        }

        protected override IQueryable<Test> GetQuery(Expression<Func<Test, bool>> predicate = null)
        {
            return predicate != null ? 
                    uow.Tests.Where(predicate).OrderBy(c => c.Name) : 
                    uow.Tests.OrderBy(c => c.Name);
        }

        protected override void Remove(Test entity)
        {
            //TODO: Restrict to admin level
            throw new NotImplementedException();
        }

        protected override void Add(TestModel source, Test dest)
        {
            //TODO: Restrict to admin level
            throw new NotImplementedException();
        }

        #endregion
    }
}
