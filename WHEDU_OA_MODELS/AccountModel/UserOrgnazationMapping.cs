using System.ComponentModel.Composition;
using WHEDU_OA_COMMONS;

namespace WHEDU_OA_MODELS.AccountModel
{
    [Export("WHEDUOA", typeof(IMapping))]
   public  class UserOrgnazationMapping:MappingBase<UserOrgnazationModel>
    {
    }
    [Export("WHEDUOA", typeof(IMapping))]
    public class OrgnazationMapping:MappingBase<OrgnazationModel>
    {

    }
}
