using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetflixClone.Foundation.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(TKey id);
        IList<TEntity> GetList();
        IList<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null);
        int GetCount(Expression<Func<TEntity, bool>> predicate = null);
    }
}
