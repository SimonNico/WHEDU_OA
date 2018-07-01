using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHEDU_OA_MODELS;

namespace WHEDU_OA_DAL
{
    public interface IOrgnazationsRepository
    {
        int AddOrgnazation(OrgnazationModel omodel);
        int AddUserOrgnazation(UserOrgnazationModel uomodel);
        int UpdateOrgnazation(OrgnazationModel omodel);
        int UpdateUserOrgnaztion(UserOrgnazationModel uomodel);
        int DeleteOrgnazation(OrgnazationModel omodel);
        int DeleteUserOrgnazation(UserOrgnazationModel uomodel);
        OrgnazationModel GetOrgnazation(string orgnazation_id);
        UserOrgnazationModel GetUserOrgnazation(string user_id);
    }
}
