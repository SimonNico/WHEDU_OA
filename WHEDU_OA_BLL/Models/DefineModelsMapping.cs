using System.ComponentModel.Composition;
using WHEDU_OA_COMMONS;

namespace WHEDU_WF_ENGINE.Models
{
    [Export("WHEDUOA",typeof(IMapping))]
    public class DefineModelsMapping:MappingBase<DefineModels>
    {
    }
}
