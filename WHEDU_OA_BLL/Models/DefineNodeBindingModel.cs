using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHEDU_WF_ENGINE.Models
{
    public class DefineNodeBindingModel
    {
        /// <summary>
        /// 节点名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 标识符
        /// </summary>
        public string label { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 是否开始i节点
        /// </summary>
        public string isbeginnode { get; set; }
        /// <summary>
        /// 是否结束节点
        /// </summary>
        public  string isendnode { get; set; }
        /// <summary>
        /// 是否会签节点
        /// </summary>
        public string ismutiply { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string rolename { get; set; }
        /// <summary>
        /// 节点id
        /// </summary>
        public string node_id { get; set; }
        /// <summary>
        /// 上一节点id
        /// </summary>
        public string prenode_id { get; set; }
        /// <summary>
        /// 驳回返回id
        /// </summary>
        public string reject_node_id { get; set; }
        /// <summary>
        /// 节点对应的url
        /// </summary>
        public string url { get; set; }
    }
}
