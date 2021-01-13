using DAL.Configurations;
using DAL.Migrations;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Context : DbContext
    {
        public Context() : base("Server=(local); Initial Catalog=School; Integrated Security=true")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>(true));
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TeacherConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new ClassConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
