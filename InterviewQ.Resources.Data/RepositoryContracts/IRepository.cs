using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InterviewQ.Resources.Data.RepositoryContracts
{
    public interface IRepository<TModel, TEntity> 
        where TModel : class
        where TEntity:class
    {
        TModel GetById(Guid id);
        Task<TModel> GetByIdAsync(Guid id);
        IList<TModel> Get(Expression<Func<TEntity, bool>> predicate = null);
        Task<IList<TModel>> GetAsync(Expression<Func<TEntity, bool>> predicate = null);

    }
}