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
    public class CrudService<T> : ICrudService<T> where T : Entity
    {
        protected HttpClient _client;
        protected string RoutePrefix { get; }
        protected ICollection<MediaTypeFormatter> MediaTypeFormatters { get; } = new List<MediaTypeFormatter>();
        protected JsonMediaTypeFormatter JsonMediaTypeFormatter { get; }

        public CrudService(string address, string routePrefix)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(address),
                
            };
            RoutePrefix = routePrefix;
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

        public async Task<T> CreateAsync(T entity)
        {
            //var response = await _client.PostAsJsonAsync(ROUTE_PREFIX, entity);
            var response = await _client.PostAsync(RoutePrefix, entity, JsonMediaTypeFormatter);
            return response.IsSuccessStatusCode ? 
                await response.Content.ReadAsAsync<T>(MediaTypeFormatters) : 
                null;
        }

        public async Task<T> ReadAsync(int id)
        {
            var response = await _client.GetAsync(RoutePrefix + $"/{id}");
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadAsAsync<T>(MediaTypeFormatters);
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            var response = await _client.GetAsync(RoutePrefix);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<T>>(MediaTypeFormatters);
            }
            else
                return null;

            //response.EnsureSuccessStatusCode();
            //return await response.Content.ReadAsAsync<IEnumerable<Teacher>>();
        }
        
        public async Task UpdateAsync(int id, T entity)
        {
            //var response = await _client.PutAsJsonAsync(ROUTE_PREFIX + $"/{id}", entity);
            var response = await _client.PutAsync(RoutePrefix + $"/{id}", entity, JsonMediaTypeFormatter);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync(RoutePrefix + $"/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}
