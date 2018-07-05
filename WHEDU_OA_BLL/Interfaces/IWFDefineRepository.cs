using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHEDU_WF_ENGINE.Interfaces
{
    public interface IWFDefineRepository
    {
        int AddDefineModelNode(string jsondata, string modelname);
    }
}
