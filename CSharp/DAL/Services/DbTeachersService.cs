using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DbTeachersService : DbCrudService<Teacher>, ITeachersService
    {
        public async Task<IEnumerable<Teacher>> ReadBySpecializationAsync(string specialization)
        {
            using (var context = new Context())
            {
                return await context.Set<Teacher>().Where(x => x.Specialization == specialization).ToListAsync();
            }
        }
    }
}
