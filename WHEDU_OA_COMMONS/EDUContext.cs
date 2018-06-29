using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.IO;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Configuration;
using MySql.Data.Entity;
using System.Reflection;


namespace WHEDU_OA_COMMONS
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class EDUContext:DbContext
    {
        public EDUContext() : base("WHEDU")
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(EDUContext)));
        }
    }
}
