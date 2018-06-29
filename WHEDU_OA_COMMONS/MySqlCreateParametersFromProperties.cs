using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace WHEDU_OA_COMMONS
{
    public class MySqlCreateParametersFromProperties : ICreateParametersFromProperties
    {
        public List<IDbDataParameter> CreateParameters(IStoredProcedure procedureIn, IStoredProcedure procedureOut, bool hasCursor = true)
        {
            List<IDbDataParameter> reParameters = new List<IDbDataParameter>();
            CreateParametersFromProperties(procedureIn, ParameterDirection.Input, reParameters);
            CreateParametersFromProperties(procedureOut, ParameterDirection.Output, reParameters);

            return reParameters;
        }
        public void CreateParametersFromProperties(IStoredProcedure procedure, ParameterDirection direction, List<IDbDataParameter> reParameters)
        {
            if (procedure == null) return;
            var procedureType = procedure.GetType();
            var propertiesOfProcedure = procedureType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var parameters =
                propertiesOfProcedure.Select(propertyInfo => new MySqlParameter(string.Format("{0}", (object)propertyInfo.Name),
                                                                              propertyInfo.GetValue(procedure, new object[] { })))
                    .ToList();

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    item.Direction = direction;
                    reParameters.Add(item);
                }

            }
        }
    }
}
