using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHEDU_OA_DATAMODEL
{
    public class UserDModel
    {
        public string User_Id { get; set; }

        public string User_Name { get; set; }

        public string PassWord { get; set; }

        public string EMail { get; set; }

        public string Orgnazation_id { get; set; }

        public string Orgnazation_name { get; set; }

        public string User_type { get; set; }

        public string Active_Date { get; set; }

        public string Disactive_Date { get; set; }

        public string Is_able { get; set; }

        public string Creator { get; set; }

        public DateTime Create_Time { get; set; }

        public string Modifier { get; set; }

        public DateTime Modify_Time { get; set; }
    }
}
