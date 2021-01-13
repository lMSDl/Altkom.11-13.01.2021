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
    public class TeachersService : ITeachersService
    {
        private HttpClient _client;
        private const string ROUTE_PREFIX = "/api/Teachers";
        private ICollection<MediaTypeFormatter> MediaTypeFormatters { get; } = new List<MediaTypeFormatter>();
        private JsonMediaTypeFormatter JsonMediaTypeFormatter { get; }

        public TeachersService(string address)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(address),
                
            };
            JsonMediaTypeFormatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DateFormatString = "yyyy-MM-dd"
                }
            };
            MediaTypeFormatters.Add(JsonMediaTypeFormatter);
        }

        public async Task<Teacher> CreateAsync(Teacher entity)
        {
            //var response = await _client.PostAsJsonAsync(ROUTE_PREFIX, entity);
            var response = await _client.PostAsync(ROUTE_PREFIX, entity, JsonMediaTypeFormatter);
            return response.IsSuccessStatusCode ? 
                await response.Content.ReadAsAsync<Teacher>(MediaTypeFormatters) : 
                null;
        }

        public async Task<Teacher> ReadAsync(int id)
        {
            var response = await _client.GetAsync(ROUTE_PREFIX + $"/{id}");
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadAsAsync<Teacher>(MediaTypeFormatters);
        }

        public async Task<IEnumerable<Teacher>> ReadAsync()
        {
            var response = await _client.GetAsync(ROUTE_PREFIX);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<Teacher>>(MediaTypeFormatters);
            }
            else
                return null;

            //response.EnsureSuccessStatusCode();
            //return await response.Content.ReadAsAsync<IEnumerable<Teacher>>();
        }

        public async Task<IEnumerable<Teacher>> ReadBySpecializationAsync(string specialization)
        {
            var response = await _client.GetAsync(ROUTE_PREFIX + $"?{nameof(specialization)}={specialization}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<Teacher>>(MediaTypeFormatters);
            }
            else
                return null;
        }

        public async Task UpdateAsync(int id, Teacher entity)
        {
            //var response = await _client.PutAsJsonAsync(ROUTE_PREFIX + $"/{id}", entity);
            var response = await _client.PutAsync(ROUTE_PREFIX + $"/{id}", entity, JsonMediaTypeFormatter);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync(ROUTE_PREFIX + $"/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}
