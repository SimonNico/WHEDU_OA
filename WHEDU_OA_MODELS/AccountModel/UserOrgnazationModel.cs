using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WHEDU_OA_MODELS
{
    [Table("t_sys_re_user_orgnazation")]
    public class UserOrgnazationModel
    {
        public string id_ { get; set; }

        public string userid { get; set; }

        public string orgnazation_id { get; set; }
    }
    [Table("t_sys_re_orgnazation")]
    public class OrgnazationModel
    {
        public string Orgnazation_id { get; set; }

        public string Orgnazation_name { get; set; }

        public string Remark { get; set; }

        public string Is_Available { get; set; }
    }
}
