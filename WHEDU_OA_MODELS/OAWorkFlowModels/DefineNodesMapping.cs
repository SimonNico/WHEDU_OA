using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHEDU_OA_COMMONS;
using System.ComponentModel.Composition;

namespace WHEDU_OA_MODELS
{
    [Export("WHEDUOA", typeof(IMapping))]
    public  class DefineNodesMapping: MappingBase<DefineNodes>
    {
    }
}
