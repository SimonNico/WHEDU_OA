using System.Collections.Generic;
using WHEDU_WF_ENGINE.Models;


namespace WHEDU_WF_ENGINE.Interface
{
    public interface IDefineNodesRepository
    {
        DefineNodes GetNodesById(string nodeid);

        int AddNodeModel(DefineNodes dNode);

        int UpdateNodeModel(DefineNodes dNode);

        int AbateNodelModel(DefineNodes dNode);

        int AddNondeModelList(List<DefineNodes> definemodellist);

    }
}
