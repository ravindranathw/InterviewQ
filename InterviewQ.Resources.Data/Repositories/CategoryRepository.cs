using System;
using System.Linq;
using System.Linq.Expressions;
using InterviewQ.Business.Models;
using InterviewQ.Resources.Data.RepositoryContracts;
using InterviewQ.Resources.EF.Entities;
using InterviewQ.Resources.EF.Models;

namespace InterviewQ.Resources.Data.Repositories
{
    internal class CategoryRepository : BaseRepository<CategoryModel, Category>, ICatagoryRepository
    {
        public CategoryRepository(InterviewQContext db)
            :base(db)
        {

        }

        #region Base class Implementations

        protected override Expression<Func<Category, bool>> Get(CategoryModel model)
        {
            return c => c.Id == model.Id;
        }

        protected override Expression<Func<Category, bool>> Get(Guid id)
        {
            return c => c.Id == id;
        }

        protected override IQueryable<Category> GetQuery(Expression<Func<Category, bool>> predicate = null)
        {
            return predicate != null ?
                uow.Categories.Where(predicate).OrderBy(c => c.Name) :
                uow.Categories.OrderBy(c => c.Name);
        }

        protected override void Remove(Category entity)
        {
            //TODO: Restrict to admin level
            throw new NotImplementedException();
        }

        protected override void Add(CategoryModel source, Category dest)
        {
            //TODO: Restrict to admin level
            throw new NotImplementedException();
        }

        #endregion
    }
}