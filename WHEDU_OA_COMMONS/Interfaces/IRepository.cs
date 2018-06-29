using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace WHEDU_OA_COMMONS
{
    public interface IRepository
    {
        int Add<T>(DbContext db, T entity) where T : class;
        int Add<T>(DbContext db, List<T> entity) where T : class;
        int Update<T>(DbContext db, T entity) where T : class;
        int Update<T>(DbContext db, T entity, List<string> updateFileds) where T : class;
        int Delete<T>(DbContext db, T entity) where T : class;
        int Delete<T>(DbContext db, Expression<Func<T, bool>> where) where T : class;
        T Get<T>(DbContext db, Expression<Func<T, bool>> where) where T : class;
        IEnumerable<T> GetAll<T>(DbContext db) where T : class;
        IEnumerable<T> GetMany<T>(DbContext db, Expression<Func<T, bool>> where) where T : class;
    }
}
