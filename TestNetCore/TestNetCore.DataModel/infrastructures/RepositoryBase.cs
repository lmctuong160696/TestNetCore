using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TestNetCore.DataAccessLayer.infrastructures
{
    public abstract class RepositoryBase<T> : IGenericRepository<T> where T : class
    {
        #region property

        private TestAzureContext _dBContext;
        private readonly DbSet<T> dbSet;

        protected IDBFactory _dBFactory
        {
            get;
            private set;
        }

        protected TestAzureContext dBContext
        {
            get
            {
                return _dBContext ?? (_dBContext = _dBFactory.Intialize());
            }
        }

        public RepositoryBase(IDBFactory dBFactory)
        {
            this._dBFactory = dBFactory;
            dbSet = dBContext.Set<T>();
        }

        #endregion property

        #region implement interface
        public virtual T Add(T entity)
        {
            return dbSet.Add(entity).Entity;
        }

        public void Update(T entity)
        {
            ///https://stackoverflow.com/questions/30987806/dbset-attachentity-vs-dbcontext-entryentity-state-entitystate-modified
            dbSet.Attach(entity);
            dBContext.Entry(entity).State = EntityState.Modified;
        }

        public T Delete(int id)
        {
            var entity = dbSet.Find(id);

            return dbSet.Remove(entity).Entity;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T GetSingleById(int id)
        {
            return dbSet.Find(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="includes">mapping relationship child</param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(string[] includes = null)
        {
            
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dBContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }

            return dBContext.Set<T>().AsQueryable();
        }

        /// <summary>
        /// GetAll condition use lambda expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }
        #endregion implement interface
    }
}