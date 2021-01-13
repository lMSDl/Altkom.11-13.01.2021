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
    public class DbCrudService<T> : ICrudService<T> where T : Entity
    {
        public async Task<T> CreateAsync(T entity)
        {
            using (var context = new Context())
            {
                entity = context.Set<T>().Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new Context())
            {
                var entity = await context.Set<T>().FindAsync(id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<T> ReadAsync(int id)
        {
            using (var context = new Context())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            using (var context = new Context())
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        public async Task UpdateAsync(int id, T entity)
        {
            entity.Id = id;
            using (var context = new Context())
            {
                context.Set<T>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
