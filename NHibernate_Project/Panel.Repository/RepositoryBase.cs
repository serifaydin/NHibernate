using NHibernate;
using Panel.NHibernateDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Panel.Repository
{
    public class RepositoryBase<T> : ICrudRepository<T> where T : class
    {
        public RepositoryBase()
        {

        }

        public void Insert(T entities)
        {
            using (ISession _session = NHibernateSQLContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Save(entities);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                            _transaction.Rollback();
                        throw new Exception("Insert Hata : " + ex.Message);
                    }
                }
            }
        }

        public void Update(T entities)
        {
            using (ISession _session = NHibernateSQLContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Update(entities);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                            _transaction.Rollback();
                        throw new Exception("Update Hata : " + ex.Message);
                    }
                }
            }
        }

        public void Delete(T entities)
        {
            using (ISession _session = NHibernateSQLContext.SessionOpen())
            {
                using (ITransaction _transaction = _session.BeginTransaction())
                {
                    try
                    {
                        _session.Delete(entities);
                        _transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!_transaction.WasCommitted)
                            _transaction.Rollback();
                        throw new Exception("Delete Hata : " + ex.Message);
                    }
                }
            }
        }

        public T GetById(int id)
        {
            using (ISession _session = NHibernateSQLContext.SessionOpen())
            {
                return _session.Get<T>(id);
            }
        }

        public IList<T> GetList()
        {
            using (ISession _session = NHibernateSQLContext.SessionOpen())
            {
                return _session.Query<T>().ToList();
            }
        }
    }
}