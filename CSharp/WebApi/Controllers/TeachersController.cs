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
    public class TeachersController : BaseApiController<Teacher, ITeachersService>
    {
        protected override ITeachersService Service { get; } = new DbTeachersService();

        public async Task<IHttpActionResult> Get([FromUri]string specialization)
        {
            IEnumerable<Teacher> teachers = await Service.ReadBySpecializationAsync(specialization);
            return Ok(teachers);
        }

        [Route("{specialization:alpha}")]
        [HttpGet]
        public async Task<IHttpActionResult> ReadBySpecialization(string specialization)
        {
            var teachers = await Service.ReadBySpecializationAsync(specialization);
            return Ok(teachers);
        }
    }
}
