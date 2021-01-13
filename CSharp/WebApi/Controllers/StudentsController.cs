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
    public class StudentsController : BaseApiController<Student, ICrudService<Student>>
    {
        protected override ICrudService<Student> Service { get; } = new DbCrudService<Student>();
    }
}
