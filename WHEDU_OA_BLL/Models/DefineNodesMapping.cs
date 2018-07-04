using WHEDU_OA_COMMONS;
using System.ComponentModel.Composition;

namespace WHEDU_WF_ENGINE.Models
{
    [Export("WHEDUOA", typeof(IMapping))]
    public  class DefineNodesMapping: MappingBase<DefineNodes>
    {
    }
}
