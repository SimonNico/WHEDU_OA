using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHEDU_OA_MODELS;

namespace WHEDU_OA_DAL
{
    interface IDefineNodesRepository
    {
        DefineNodes GetNodesById(string nodeid);

        int AddNodeModel(DefineNodes dNode);

        int UpdateNodeModel(DefineNodes dNode);

        int AbateNodelModel(DefineNodes dNode);

    }
}
