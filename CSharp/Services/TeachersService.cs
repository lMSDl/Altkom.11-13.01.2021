using Models;
using Newtonsoft.Json;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TeachersService : CrudService<Teacher>, ITeachersService
    {
        public TeachersService(string address) : base(address, "/api/Teachers")
        {
        }

        public async Task<IEnumerable<Teacher>> ReadBySpecializationAsync(string specialization)
        {
            var response = await _client.GetAsync(RoutePrefix + $"?{nameof(specialization)}={specialization}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<Teacher>>(MediaTypeFormatters);
            }
            else
                return null;
        }
    }
}
