using DAL.Services;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Teachers" in both code and config file together.
    public class Teachers : ITeachers
    {
        private ITeachersService Service = new DbTeachersService();

        public Task<Teacher> CreateAsync(Teacher entity)
        {
            return Service.CreateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return Service.DeleteAsync(id);
        }

        public Task<Teacher> ReadByIdAsync(int id)
        {
            return Service.ReadAsync(id);
        }

        public Task<IEnumerable<Teacher>> ReadAsync()
        {
            return Service.ReadAsync();
        }

        public Task UpdateAsync(int id, Teacher entity)
        {
            return Service.UpdateAsync(id, entity);
        }
    }
}
