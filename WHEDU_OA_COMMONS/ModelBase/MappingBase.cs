using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace WHEDU_OA_COMMONS
{
    public class MappingBase<TEntity> : EntityTypeConfiguration<TEntity>, IMapping
         where TEntity : class
    {
        public MappingBase()
        {
            //兼容oracle数据库 表名需要增加表空间前缀
            //this.Map(m => m.ToTable(ConfigurationManager.AppSettings["SCHEMA"] + typeof(TEntity).Name));
        }

        public void RegistTo(ConfigurationRegistrar configurationRegistrar)
        {
            configurationRegistrar.Add(this);
        }
    }
}
