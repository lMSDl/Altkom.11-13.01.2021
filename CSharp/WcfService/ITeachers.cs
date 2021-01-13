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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITeachers" in both code and config file together.
    [ServiceContract]
    public interface ITeachers
    {
        [OperationContract]
        Task<Teacher> CreateAsync(Teacher entity);
        [OperationContract]
        Task<Teacher> ReadByIdAsync(int id);
        [OperationContract]
        Task<IEnumerable<Teacher>> ReadAsync();
        [OperationContract]
        Task UpdateAsync(int id, Teacher entity);
        [OperationContract]
        Task<bool> DeleteAsync(int id);
    }
}
