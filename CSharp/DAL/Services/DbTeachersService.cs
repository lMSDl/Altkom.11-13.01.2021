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
    public class DbTeachersService : ITeachersService
    {
        public async Task<Teacher> CreateAsync(Teacher entity)
        {
            using (var context = new Context())
            {
                entity = context.Set<Teacher>().Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new Context())
            {
                var entity = await context.Set<Teacher>().FindAsync(id);
                context.Set<Teacher>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Teacher> ReadAsync(int id)
        {
            using (var context = new Context())
            {
                return await context.Set<Teacher>().FindAsync(id);
            }
        }

        public async Task<IEnumerable<Teacher>> ReadAsync()
        {
            using (var context = new Context())
            {
                return await context.Set<Teacher>().ToListAsync();
            }
        }

        public async Task<IEnumerable<Teacher>> ReadBySpecializationAsync(string specialization)
        {
            using (var context = new Context())
            {
                return await context.Set<Teacher>().Where(x => x.Specialization == specialization).ToListAsync();
            }
        }

        public async Task UpdateAsync(int id, Teacher entity)
        {
            entity.Id = id;
            using (var context = new Context())
            {
                context.Set<Teacher>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
