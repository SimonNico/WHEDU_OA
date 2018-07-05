using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHEDU_WF_ENGINE.Interfaces;
using AopFrameWork;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mehdime.Entity;
using WHEDU_OA_COMMONS;
using WHEDU_WF_ENGINE.Models;


namespace WHEDU_WF_ENGINE.Repository
{
    [LogBeforeAdvice]
    [LogAfterAdvice]
    [AuditMehodInterceptor]
    public class WFDefineRepository : IWFDefineRepository
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        public int AddDefineModelNode(DefineBindingModel dbmodel, string userid)
        {
            if (dbmodel==null || string.IsNullOrEmpty(userid)) throw new ArgumentNullException("jsondata or modelname");
            try
            {
                var jdata = JArray.Parse(dbmodel.Model_Json);
                DefineNodes dnode = new DefineNodes();
                DefineModels dmodel = new DefineModels();
                using (var dbcontextscope = _dbContextScopeFactory.Create())
                {
                    var db = dbcontextscope.DbContexts.Get<OADbContext>();
                    var lastmodel= db.Set<DefineModels>().Where(p => p.MODEL_NAME.Equals(dbmodel.Model_Name)).OrderByDescending(m => m.VERSION_NO).FirstOrDefault();
                    if(lastmodel ==null)
                    {
                        dmodel.MODEL_ID = Guid.NewGuid().ToString();
                        dmodel.MODEL_NAME = dbmodel.Model_Name;
                        dmodel.VERSION_NO = 1;
                        dmodel.IS_ABLE = Enums.isAble.Yes.ToString();
                        dmodel.META_INFO =dbmodel.Model_Json;
                        dmodel.MODIFIER = userid;
                        dmodel.CREATOR = userid;
                        dmodel.CREATE_TIME = DateTime.Now;
                        dmodel.LAST_UPDATE_TIME = DateTime.Now;
                    }
                    else
                    {
                        dmodel.MODEL_ID = Guid.NewGuid().ToString();
                        dmodel.MODEL_NAME = dbmodel.Model_Name;
                        dmodel.VERSION_NO += 1;
                        dmodel.IS_ABLE = Enums.isAble.Yes.ToString();
                        dmodel.META_INFO = dbmodel.Model_Json;
                        dmodel.MODIFIER = userid;
                        dmodel.CREATOR = userid;
                        dmodel.CREATE_TIME = DateTime.Now;
                        dmodel.LAST_UPDATE_TIME = DateTime.Now;
                    }
                    var model = db.Set<DefineModels>();
                    model.Add(dmodel);

                    foreach(var item in jdata)
                    {
                        dnode.BACK_NODE_ID = Guid.NewGuid().ToString();
                        dnode.CREATER = userid;
                        dnode.CREATE_TIME = DateTime.Now;
                        dnode.IS_ABLE = Enums.isAble.Yes.ToString();
                        dnode.MODEL_ID = dmodel.MODEL_ID;
                        dnode.MODIFIER = userid;
                        dnode.LAST_UPDATE_TIME = DateTime.Now;
                        dnode.NODE_CONDITON = string.Empty;
                        dnode.NODE_ID = Guid.NewGuid().ToString();
                        

                    }
                    return db.SaveChanges();
                }
            }
           catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
