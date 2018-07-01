using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHEDU_OA_MODELS;
using AopProxy;
using AopFrameWork;
using Unity.Attributes;
using WHEDU_OA_COMMONS;
using Mehdime.Entity;

namespace WHEDU_OA_DAL
{
    [LogBeforeAdvice]
    [LogAfterAdvice]
    [ExceptionAdvice]
    public class DefineNodesRepository : IDefineNodesRepository
    {
        [Dependency]
        public IRepository Repository { get; set; }

        private readonly IDbContextScopeFactory _dbContextScopeFactory;

        public DefineNodesRepository(IDbContextScopeFactory DbContextScopFactory)
        {
            if (DbContextScopFactory == null) throw new ArgumentNullException("DbContextScopFactory");
            _dbContextScopeFactory = DbContextScopFactory;
        }
        /// <summary>
        /// 失效节点
        /// </summary>
        /// <param name="dNode">节点信息</param>
        /// <returns>返回处理结果1成功，0失败</returns>
        public int AbateNodelModel(DefineNodes dNode)
        {
            if (dNode == null) throw new ArgumentNullException("DNode");
            using(var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscope.DbContexts.Get<OADbContext>();
                List<string> collist = new List<string>();
                collist.Add("IS_ABLE");
                dNode.IS_ABLE = isAble.No.ToString();
                return Repository.Update<DefineNodes>(db, dNode, collist);

            }
        }
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="dNode">节点信息</param>
        /// <returns>0：fail 1:success</returns>

        public int AddNodeModel(DefineNodes dNode)
        {
            if (dNode == null) throw new ArgumentNullException("dNode");
            using (var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscope.DbContexts.Get<OADbContext>();
                return Repository.Add<DefineNodes>(db, dNode);
            }
        }
        /// <summary>
        /// 获取节点信息
        /// </summary>
        /// <param name="nodeid">节点ID</param>
        /// <returns>节点信息</returns>
        public DefineNodes GetNodesById(string nodeid)
        {
            if (string.IsNullOrEmpty(nodeid)) throw new ArgumentNullException("nodeid");
            using (var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscope.DbContexts.Get<OADbContext>();
                return Repository.Get<DefineNodes>(db, p => p.NODE_ID.Equals(nodeid));
            }
        }
        /// <summary>
        /// 更新节点信息
        /// </summary>
        /// <param name="dNode">节点信息</param>
        /// <returns>0：fail 1:success</returns>
        public int UpdateNodeModel(DefineNodes dNode)
        {
            if (dNode == null) throw new ArgumentNullException("dNode");
            using(var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var db = dbcontextscope.DbContexts.Get<OADbContext>();
                return Repository.Update<DefineNodes>(db, dNode);
            }
        }
        private enum isAble
        {
            No,
            Yes
        }
    }
}
