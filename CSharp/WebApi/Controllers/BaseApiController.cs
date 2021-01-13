using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public abstract class BaseApiController<T, TService> : ApiController where T : Entity where TService : ICrudService<T>
    {
        protected abstract TService Service { get; }

        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<T> entities = await Service.ReadAsync();
            return Ok(entities);
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var entity = await Service.ReadAsync(id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }
        
        public async Task<IHttpActionResult> Post(T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            entity = await Service.CreateAsync(entity);
            return CreatedAtRoute("DefaultApi", new { controller = ControllerContext.ControllerDescriptor.ControllerName, id = entity.Id }, entity);
        }

        public async Task<IHttpActionResult> Put(int id, T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Service.UpdateAsync(id, entity);
            return StatusCode(HttpStatusCode.NoContent);
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            //var teacher = await Service.ReadAsync(id);
            //if (teacher == null)
            //    return NotFound();
            if (await Service.DeleteAsync(id))
                return StatusCode(HttpStatusCode.NoContent);
            else
                return NotFound();
        }
    }
}
