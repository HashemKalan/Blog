using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DomainService
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate = null);
        TEntity GetFirst(Expression<Func<TEntity, bool>> predicate = null, List<string> includePaths = null);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void Save();
    }
}
