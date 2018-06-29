using System.Collections.Generic;
using System.Data.Entity;
using MySql.Data.Entity;

namespace WHEDU_OA_COMMONS
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class OADbContext:DbContext
    {
        public OADbContext():base("WHEDU")
        {
        }

        IEnumerable<IMapping> m_Mappings = null;
        /// <summary>
        /// 在Context第一次初始化时执行此方法，此方法之后后数据会被EntityFramework缓存，
        /// 在后面Context初始化时不会再被执行
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<OADbContext>(new NullDatabaseInitializer<OADbContext>());
            m_Mappings = MappingContainer.GetInstance.GetExportedValues("WHEDUOA");

            if (m_Mappings != null)
            {
                //这里是关键
                foreach (var mapping in m_Mappings)
                {
                    mapping.RegistTo(modelBuilder.Configurations);
                }
            }
            base.OnModelCreating(modelBuilder);
        }
        protected override void Dispose(bool disposing)
        {
            var connection = this.Database.Connection;
            base.Dispose(disposing);
            connection.Dispose();
        }
    }
}
