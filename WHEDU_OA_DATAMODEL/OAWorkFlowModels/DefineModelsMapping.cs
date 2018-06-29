using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using WHEDU_OA_COMMONS;

namespace WHEDU_OA_DATAMODEL
{
    [Export("WHEDUOA",typeof(IMapping))]
    public class DefineModelsMapping:MappingBase<DefineModels>
    {
    }
}
