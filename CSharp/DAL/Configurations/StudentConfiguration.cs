using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class StudentConfiguration : PersonConfiguration<Student>
    {
        public StudentConfiguration()
        {
            Property(x => x.IndexNumber).IsRequired();
        }
    }
}
