using System;
using System.Linq;
using System.Linq.Expressions;

namespace Blog.Operation
{
    public interface IBaseOperation<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity Update(TEntity entity);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate = null);         
    }
}
