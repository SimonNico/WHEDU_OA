using System.ComponentModel.Composition;
using WHEDU_OA_COMMONS;

namespace WHEDU_OA_MODELS
{
    [Export("WHEDUOA",typeof(IMapping))]
    public class DefineModelsMapping:MappingBase<DefineModels>
    {
    }
}
