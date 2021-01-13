using DAL.Services;
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
    [RoutePrefix("api/teachers")]
    public class TeachersController : ApiController
    {
        private ITeachersService Service { get; } = new DbTeachersService();

        public async Task<IHttpActionResult> Get([FromUri]string specialization = null)
        {
            IEnumerable<Teacher> teachers;
            if (specialization == null)
                teachers = await Service.ReadAsync();
            else
                teachers = await Service.ReadBySpecializationAsync(specialization);
            return Ok(teachers);
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var teacher = await Service.ReadAsync(id);
            if (teacher == null)
                return NotFound();
            return Ok(teacher);
        }

        [Route("{specialization:alpha}")]
        [HttpGet]
        public async Task<IHttpActionResult> ReadBySpecialization(string specialization)
        {
            var teachers = await Service.ReadBySpecializationAsync(specialization);
            return Ok(teachers);
        }

        public async Task<IHttpActionResult> Post(Teacher teacher)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            teacher = await Service.CreateAsync(teacher);
            return CreatedAtRoute("DefaultApi", new { controller = "teachers", id = teacher.Id }, teacher);
        }

        public async Task<IHttpActionResult> Put(int id, Teacher teacher)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await Service.UpdateAsync(id, teacher);
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
