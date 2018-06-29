using System.Collections.Generic;
using System.Data;

namespace WHEDU_OA_COMMONS
{
    public interface ICreateParametersFromProperties
    {
        /// <summary>
        /// 创建parameter参数接口
        /// </summary>
        /// <param name="procedure">参数对象 </param>
        /// <param name="direction">表示参数是输入参数还是输出参数</param>
        /// <returns></returns>
        List<IDbDataParameter> CreateParameters(IStoredProcedure procedureIn, IStoredProcedure procedureOut, bool hasCursor = true);
    }
}
