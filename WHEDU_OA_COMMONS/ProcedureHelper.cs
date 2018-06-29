using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Configuration;
using System.ComponentModel.Composition.Hosting;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Reflection;
using System.Data.Entity;

namespace WHEDU_OA_COMMONS
{
   public class ProcedureHelper
    {
        ICreateParametersFromProperties _CreateParametersFromProperties = null;

        public ProcedureHelper()
        {
            if (_CreateParametersFromProperties == null)
            {
                _CreateParametersFromProperties = new MySqlCreateParametersFromProperties();
            }
        }

        /// <summary>
        /// 调用sql语句返回结果集合
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public List<TResult> ExcuteSql<TResult>(DbContext db, string sqlStr)
        {
            IStoredProcedure procedureOut = null;
            return ExcuteProce<TResult>(db, sqlStr, null, ref procedureOut, CommandType.Text);
        }
        /// <summary>
        /// 调用存储过程，返回结果集
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="procName"></param>
        /// <returns></returns>
        public List<TResult> ExcuteProce<TResult>(DbContext db, string procName)
        {
            IStoredProcedure procedureOut = null;
            return ExcuteProce<TResult>(db, procName, null, ref procedureOut);
        }
        /// <summary>
        /// 执行存储过程，返回结果集。不带返回参数
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="procName"></param>
        /// <param name="procedureIn"></param>
        /// <returns></returns>
        public List<TResult> ExcuteProce<TResult>(DbContext db, string procName, IStoredProcedure procedureIn)
        {
            IStoredProcedure procedureOut = null;
            return ExcuteProce<TResult>(db, procName, procedureIn, ref procedureOut);
        }
        /// <summary>
        /// 执行存储过程，返回结果集,带返回参数
        /// </summary>
        /// <typeparam name="TResult">对象类型</typeparam>
        /// <param name="commanText">过程名称</param>
        /// <param name="procedure">参数</param>
        /// <param name="commandType">设置类型</param>
        /// <returns></returns>
        public List<TResult> ExcuteProce<TResult>(DbContext db, string procName, IStoredProcedure procedureIn, ref IStoredProcedure procedureOut, CommandType commandType = CommandType.StoredProcedure)
        {
            if (string.IsNullOrEmpty(procName))
            {
                return null;
            }

            List<TResult> ResultInfo = null;
            var cmd = db.Database.Connection.CreateCommand();
            cmd.CommandText = procName;
            cmd.CommandType = commandType;
            var parameters = _CreateParametersFromProperties.CreateParameters(procedureIn, procedureOut);

            if (parameters != null)
            {
                foreach (IDbDataParameter parm in parameters)
                    cmd.Parameters.Add(parm);
            }

            try
            {
                ((IObjectContextAdapter)db).ObjectContext.Connection.Open();
                var reader = cmd.ExecuteReader();

                ResultInfo = ((IObjectContextAdapter)db).ObjectContext.Translate<TResult>(reader).ToList();
                reader.Dispose();

                //获取返回参数值
                if (procedureOut != null)
                {
                    Set(procedureOut, parameters);
                }
            }
            catch (Exception ex)
            {
                //TODO:
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                //((IObjectContextAdapter)db).ObjectContext.Connection.Dispose();
            }

            return ResultInfo;
        }

        private void Set(IStoredProcedure procedure, List<IDbDataParameter> parametersOut)
        {
            var procedureType = procedure.GetType();
            var propertiesOfProcedure = procedureType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var item in parametersOut)
            {
                foreach (var item2 in propertiesOfProcedure)
                {
                    if (item.ParameterName == item2.Name && item.Direction == ParameterDirection.Output && item.Value != null)
                    {
                        item2.SetValue(procedure, item.Value, new object[] { });
                    }
                }
            }
        }

        /// <summary>
        /// 执行非查询的存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="procedureIn">输入对象</param>
        /// <param name="procedureOut">输出对象</param>
        /// <param name="commandType">类型</param>
        public void ExcuteProceNo(DbContext db, string procName, IStoredProcedure procedureIn, IStoredProcedure procedureOut, CommandType commandType = CommandType.StoredProcedure)
        {
            if (string.IsNullOrEmpty(procName))
            {
                return;
            }

            var cmd = db.Database.Connection.CreateCommand();
            cmd.CommandText = procName;
            cmd.CommandType = commandType;
            var parameters = _CreateParametersFromProperties.CreateParameters(procedureIn, procedureOut, false);

            if (parameters != null)
            {
                foreach (IDbDataParameter parm in parameters)
                    cmd.Parameters.Add(parm);
            }

            try
            {
                ((IObjectContextAdapter)db).ObjectContext.Connection.Open();
                cmd.ExecuteNonQuery();

                //获取返回参数值
                if (procedureOut != null)
                {
                    Set(procedureOut, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                //((IObjectContextAdapter)db).ObjectContext.Connection.Dispose();
            }
        }
    }
}
