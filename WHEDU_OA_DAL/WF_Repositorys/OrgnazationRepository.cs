using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHEDU_OA_MODELS;
using Unity.Attributes;
using WHEDU_OA_COMMONS;
using Mehdime.Entity;
using AopFrameWork;

namespace WHEDU_OA_DAL
{
    [LogBeforeAdvice]
    [LogAfterAdvice]
    [AuditMehodInterceptor]
    public class OrgnazationRepository : IOrgnazationsRepository
    {
        [Dependency]
        public IRepository Repository { get; set; }

        private readonly IDbContextScopeFactory _dbContextScopeFactory;

        public OrgnazationRepository(IDbContextScopeFactory dbcontextscopefactory)
        {
            _dbContextScopeFactory = dbcontextscopefactory;
        }
        public int AddOrgnazation(OrgnazationModel omodel)
        {
            if (omodel == null) throw new ArgumentNullException("omodel");
            using (var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscope.DbContexts.Get<OADbContext>();
                return Repository.Add<OrgnazationModel>(db, omodel);
            }
        }

        public int AddUserOrgnazation(UserOrgnazationModel uomodel)
        {
            if (uomodel == null) throw new ArgumentNullException("uomodel");
            using (var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscope.DbContexts.Get<OADbContext>();
                return Repository.Add<UserOrgnazationModel>(db, uomodel);
            }
        }

        public int DeleteOrgnazation(OrgnazationModel omodel)
        {
            if (omodel == null) throw new ArgumentNullException("omodel");
            using (var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscope.DbContexts.Get<OADbContext>();
                return Repository.Delete<OrgnazationModel>(db, omodel);
            }
        }

        public int DeleteUserOrgnazation(UserOrgnazationModel uomodel)
        {
            if (uomodel == null) throw new AggregateException("uomodel");
            using (var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscope.DbContexts.Get<OADbContext>();
                return Repository.Delete<UserOrgnazationModel>(db, uomodel);
            }
        }

        public OrgnazationModel GetOrgnazation(string orgnazation_id)
        {
            if (string.IsNullOrEmpty(orgnazation_id)) throw new ArgumentNullException("orgnazation_id");
            using (var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscope.DbContexts.Get<OADbContext>();
                return Repository.Get<OrgnazationModel>(db, p => p.Orgnazation_id == orgnazation_id);
            }
        }

        public UserOrgnazationModel GetUserOrgnazation(string user_id)
        {
            if (string.IsNullOrEmpty(user_id)) throw new ArgumentNullException("user_id");
            using (var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscope.DbContexts.Get<OADbContext>();
                return Repository.Get<UserOrgnazationModel>(db,p=>p.userid==user_id);
            }
        }

        public int UpdateOrgnazation(OrgnazationModel omodel)
        {
            if (omodel == null) throw new ArgumentNullException("omodel");
            using (var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscope.DbContexts.Get<OADbContext>();
                return Repository.Update<OrgnazationModel>(db, omodel);
            }
        }

        public int UpdateUserOrgnaztion(UserOrgnazationModel uomodel)
        {
            if (uomodel == null) throw new AggregateException("uomodel");
            using (var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscope.DbContexts.Get<OADbContext>();
                return Repository.Update<UserOrgnazationModel>(db, uomodel);
            }
        }
    }
}
