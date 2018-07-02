using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHEDU_OA_MODELS;


namespace WHEDU_OA_BLL
{
   public  interface IWF_Define
    {
        int DefineModelAndNodes(DefineBindingModel dmodel,string userid);
    }
}
