using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WHEDU_OA_MODELS
{
    [Table("t_wf_re_node_defined")]
    public class DefineNodes
    {
        public string NODE_ID { get; set; }

        public string NODE_NAME { get; set; }

        public string NODE_CONDITON { get; set; }

        public string PARENT_NODE_ID { get; set; }

        public string BACK_NODE_ID { get; set; }

        public string MODEL_ID { get; set; }

        public string IS_STARNODE { get; set; }

        public string IS_ENDNODE { get; set; }

        public string IS_ABLE { get; set; }

        public string IS_MULTIPLY { get; set; }

        public string CREATER { get; set; }

        public DateTime CREATE_TIME { get; set; }

        public string MODIFIER { get; set; }

        public DateTime LAST_UPDATE_TIME { get; set; }

        public string DEALER_SQL_EXC { get; set; }
    }
}
