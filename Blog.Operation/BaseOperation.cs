using System;
using System.Linq;
using System.Linq.Expressions;
using Blog.DomainService;

namespace Blog.Operation
{
    public abstract class BaseOperation<TEntity> : IBaseOperation<TEntity> where TEntity : class
    {
        protected readonly IBaseService<TEntity> _baseService;
        public BaseOperation(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        public TEntity Add(TEntity entity)
        {
            _baseService.Add(entity);
            _baseService.Save();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _baseService.Delete(entity);
            _baseService.Save();
        }

        public TEntity Update(TEntity entity)
        {
            _baseService.Update(entity);
            _baseService.Save();
            return entity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate = null)
        {
            return _baseService.Where(predicate);
        }

    }
}
