using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHEDU_OA_MODELS
{

    public class UserOrgnazationViewModel
    {
        public string Orgnazation_Id { get; set; }

        public string Orgnaztation_Name { get; set; }

        public IEnumerable<UserInfoViewModel>UserInfos{get;set;}
    }
    public  class OrgnazationViewModel
    {
        public string Orgnazation_Id { get; set; }

        public  string Orgnazation_Name { get; set; }
    }
    public class UserInfoViewModel
    {
        public string User_Id { get; set; }
        public string User_Name { get; set; }
    }
}
