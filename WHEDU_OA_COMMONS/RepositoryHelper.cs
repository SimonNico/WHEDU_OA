using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace WHEDU_OA_COMMONS
{
    public sealed class RepositoryHelper : IRepository
    {
        public RepositoryHelper()
        {
        }
        public int Add<T>(DbContext db, T entity) where T : class
        {
            try
            {
                var model = db.Set<T>();
                model.Add(entity);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Add<T>(DbContext db, List<T> entities) where T : class
        {
            try
            {
                var model = db.Set<T>();
                foreach (var entity in entities)
                    model.Add(entity);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update<T>(DbContext db, T entity) where T : class
        {
            try
            {
                var model = db.Set<T>();
                model.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update<T>(DbContext db, List<T> entities) where T : class
        {
            try
            {
                var model = db.Set<T>();
                foreach (var entity in entities)
                {
                    model.Attach(entity);
                    db.Entry(entity).State = EntityState.Modified;
                }
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update<T>(DbContext db, T entity, List<string> updateFileds) where T : class
        {
            try
            {
                var model = db.Set<T>();
                model.Attach(entity);
                var obj = (db as IObjectContextAdapter).ObjectContext;
                var stateEntiy = obj.ObjectStateManager.GetObjectStateEntry(entity);
                foreach (var item in updateFileds)
                {
                    stateEntiy.SetModifiedProperty(item);
                }
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update<T>(DbContext db, List<T> entities, List<string> updateFileds) where T : class
        {
            try
            {
                var model = db.Set<T>();
                var obj = (db as IObjectContextAdapter).ObjectContext;
                foreach (var entity in entities)
                {
                    model.Attach(entity);
                    var stateEntiy = obj.ObjectStateManager.GetObjectStateEntry(entity);
                    foreach (var item in updateFileds)
                    {
                        stateEntiy.SetModifiedProperty(item);
                    }
                }
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete<T>(DbContext db, T entity) where T : class
        {
            try
            {
                var model = db.Set<T>();
                model.Attach(entity);
                db.Entry(entity).State = EntityState.Deleted;
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete<T>(DbContext db, List<T> entities) where T : class
        {
            try
            {
                var model = db.Set<T>();
                foreach (var entity in entities)
                {
                    model.Attach(entity);
                    db.Entry(entity).State = EntityState.Deleted;
                }
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete<T>(DbContext db, Expression<Func<T, bool>> where) where T : class
        {
            try
            {
                var model = db.Set<T>();
                IEnumerable<T> objects = model.Where<T>(where).AsEnumerable();
                foreach (T obj in objects)
                    model.Remove(obj);
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Get<T>(DbContext db, Expression<Func<T, bool>> where) where T : class
        {
            try
            {
                var model = db.Set<T>();
                return model.Where(where).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetAll<T>(DbContext db) where T : class
        {
            try
            {
                var model = db.Set<T>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetMany<T>(DbContext db, Expression<Func<T, bool>> where) where T : class
        {
            try
            {
                var model = db.Set<T>();
                return model.Where(where).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
