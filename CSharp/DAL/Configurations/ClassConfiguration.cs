using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class ClassConfiguration : EntityTypeConfiguration<Class>
    {
        public ClassConfiguration()
        {
            HasRequired(x => x.Educator).WithMany().HasForeignKey(x => x.Educator_Id);
            HasMany(x => x.Students).WithOptional(x => x.Class).HasForeignKey(x => x.Class_Id);
        }
    }
}
