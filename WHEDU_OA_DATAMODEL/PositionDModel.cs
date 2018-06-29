using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHEDU_OA_DATAMODEL
{
    public class PositionDModel
    {
        public string Position_id { get; set; }

        public string Position_name { get; set; }

        public string Orgnazation_id { get; set; }

        public string Remark { get; set; }

        public string Creator { get; set; }

        public DateTime Create_Time { get; set; }

        public string Modifier { get; set; }

        public DateTime Modify_Time { get; set; }
    }
}
