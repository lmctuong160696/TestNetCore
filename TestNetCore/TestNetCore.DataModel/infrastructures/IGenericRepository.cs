using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TestNetCore.DataAccessLayer.infrastructures
{
    internal interface IGenericRepository<T> where T : class
    {
        //Create item 

        T Add(T entity);

        void Update(T entity);

        // Delete by int id
        T Delete(int id);

        //Delete by Object
        void Delete(T entity);

        // Get an entity by int id
        T GetSingleById(int id);

        //Get All record return Enum
        IEnumerable<T> GetAll(string[] includes = null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

    }
}