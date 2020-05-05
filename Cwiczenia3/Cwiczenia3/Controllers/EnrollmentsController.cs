using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia3.DAL;
using Cwiczenia3.DTO.Requests;
using Cwiczenia3.DTO.Responses;
using Cwiczenia3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia3.Controllers
{
    [Route("api/enrollment")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentDbService _service;

        public EnrollmentsController(IStudentDbService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "employee")]
        public IActionResult EnrollStudent(EnrollStudentRequest student)
        {
            var response = _service.EnrollStudent(student);
            if(response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
    }
}