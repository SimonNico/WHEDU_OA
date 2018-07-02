using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WHEDU_OA_MODELS
{
    [Table("t_wf_re_model")]
   public class DefineModels
    {
        public string MODEL_ID { get; set; }

        public int VERSION_NO { get; set; }

        public string MODEL_NAME { get; set; }

        public string META_INFO { get; set; }

        public string DEPLOYEMENT_ID { get; set; }

        public string CREATOR { get; set; }

        public DateTime CREATE_TIME { get; set; }

        public string MODIFIER { get; set; }

        public DateTime LAST_UPDATE_TIME { get; set; }

        public string IS_ABLE { get; set; }
    }
}
