using Blog.DataAccess.Interface;
using Blog.Domain;
using Blog.DomainService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DomainService
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IDbSet<TEntity> _entities;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _entities = _uow.DbSet<TEntity>();
        }
        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _uow.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public virtual TEntity GetFirst(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate = null, List<string> includePaths = null)
        {
            var query = _entities.AsNoTracking();
            if (includePaths != null)
            {
                foreach (var path in includePaths)
                {
                    query = query.Include(path);
                }
            }
            return predicate == null ? query.First() : query.Where(predicate).First();
        }

        public virtual void Save()
        {
            _uow.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Attach(entity);
            _uow.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public virtual IQueryable<TEntity> Where(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null ? _entities : _entities.Where(predicate);
        }
    }
}
