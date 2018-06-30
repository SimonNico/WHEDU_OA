using System;
using System.Collections.Generic;
using WHEDU_OA_MODELS;
using WHEDU_OA_COMMONS;
using Unity.Attributes;
using Mehdime.Entity;
using AopFrameWork;


namespace WHEDU_OA_DAL.WF_Repositorys
{
    [LogBeforeAdvice]
    [LogAfterAdvice]
    [AuditMehodInterceptor]
    [ExceptionAdvice]
    public class DefineModelRepository : IDefineModelRepository
    {
        [Dependency]
        public IRepository Repository { get; set; }

        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        public DefineModelRepository(IDbContextScopeFactory dbContextScopeFactory)
        {
            if (dbContextScopeFactory == null) throw new ArgumentNullException("dbContextScopeFactory");
            _dbContextScopeFactory = dbContextScopeFactory;
        }

        public int AbateDefineModel(DefineModels model)
        {
            if (model == null) throw new ArgumentNullException("model");
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                var dbContext = dbContextScope.DbContexts.Get<OADbContext>();
                List<string> collist = new List<string>();
                collist.Add("IS_ABLE");
                return Repository.Update<DefineModels>(dbContext, model, collist);

            }
        }

        public int AddDefineModel(DefineModels dmodel)
        {
            if (dmodel == null) throw new ArgumentNullException("dmodel");
            using (var dbContextScope = _dbContextScopeFactory.Create())
            {
                var db = dbContextScope.DbContexts.Get<OADbContext>();
                return Repository.Add<DefineModels>(db, dmodel);
            }
        }

        public DefineModels GetDefineModelByID(string m_id)
        {
            if (string.IsNullOrEmpty(m_id)) throw new ArgumentNullException("m_id");
            using (var dbcontextscop = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscop.DbContexts.Get<OADbContext>();
                return Repository.Get<DefineModels>(db, p => p.MODEL_ID == m_id);
            }
        }

        public int AbateDefineModelByID(string m_id)
        {
            if (string.IsNullOrEmpty(m_id)) throw new ArgumentNullException("m_id");
            using (var dbcontextscop = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscop.DbContexts.Get<OADbContext>();
                DefineModels dmodel= Repository.Get<DefineModels>(db, p => p.MODEL_ID == m_id);
                if (dmodel != null)
                {
                    dmodel.IS_ABLE = "0";
                    List<string> collist = new List<string>();
                    collist.Add("IS_ABLE");
                    return Repository.Update<DefineModels>(db, dmodel, collist);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
