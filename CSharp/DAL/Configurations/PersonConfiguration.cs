using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class PersonConfiguration<T> : EntityTypeConfiguration<T> where T : Person
    {
        public PersonConfiguration()
        {
            Property(x => x.FirstName).IsRequired();
            Property(x => x.LastName).IsRequired();
        }
    }
}
