using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHEDU_OA_MODELS;
using WHEDU_OA_DAL;
using Unity.Attributes;

namespace WHEDU_OA_BLL
{
    public class WF_Define : IWF_Define
    {
        [Dependency]
        private IDefineModelRepository DefineModelRepository { get; set; }
        [Dependency]
        private IDefineNodesRepository DefineNodelRepository { get; set; }

        public int DefineModelAndNodes(DefineBindingModel dmodel, string userid)
        {
            DefineModels model = DefineModelRepository.GetLastDefineModelByName(dmodel.Model_Name);
            if (model == null)
            {
                model = new DefineModels
                {
                    MODEL_ID = Guid.NewGuid().ToString(),
                    MODEL_NAME = dmodel.Model_Name,
                    VERSION_NO = 1,
                    IS_ABLE = "1",
                    META_INFO = dmodel.Model_Json,
                    CREATOR = userid,
                    CREATE_TIME = DateTime.Now,
                    MODIFIER = userid,
                    LAST_UPDATE_TIME = DateTime.Now
                };
            }
            else
            {
                model.MODIFIER = userid;
                model.LAST_UPDATE_TIME = DateTime.Now;
                model.VERSION_NO += 1;
                model.META_INFO = dmodel.Model_Json;
                model.IS_ABLE = "1";
            }
            return DefineModelRepository.AddDefineModel(model);
        }
    }
}
