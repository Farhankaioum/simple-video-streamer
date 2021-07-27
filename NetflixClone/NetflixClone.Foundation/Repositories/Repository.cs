using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NetflixClone.Foundation.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
    {
        private readonly ISessionFactory _sessionFactory;

        public Repository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IList<TEntity> GetList()
        {
            using var session = _sessionFactory.OpenSession();
            return session.Query<TEntity>().ToList();
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null)
        {
            using var session = _sessionFactory.OpenSession();

            var listOfData = session.Query<TEntity>()
                .Where(predicate)
                .ToList();

            return listOfData;
        }

        public TEntity GetById(TKey id)
        {
            using var session = _sessionFactory.OpenSession();
            return session.Get<TEntity>(id);
        }

        public int GetCount(Expression<Func<TEntity, bool>> predicate = null)
        {
            using var session = _sessionFactory.OpenSession();

            var count = session.Query<TEntity>()
                .Where(predicate)
                .Count();

            return count;
        }

        public void Insert(TEntity entity)
        {
            using var session = _sessionFactory.OpenSession();
            using var txn = session.BeginTransaction();
            try
            {
                session.Save(entity);
                txn.Commit();
            }
            catch
            {
                txn.Rollback();
                throw;
            }
        }

        public void Update(TEntity entity)
        {
            using var session = _sessionFactory.OpenSession();
            using var txn = session.BeginTransaction();
            try
            {
                session.Update(entity);
                txn.Commit();
            }
            catch
            {
                txn.Rollback();
                throw;
            }
        }

        public void Delete(TEntity entity)
        {
            using var session = _sessionFactory.OpenSession();
            using var txn = session.BeginTransaction();
            try
            {
                session.Delete(entity);
                txn.Commit();
            }
            catch
            {
                txn.Rollback();
                throw;
            }
        }
    }
}
