using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia3.DAL;
using Cwiczenia3.DTO.Requests;
using Cwiczenia3.DTO.Responses;
using Cwiczenia3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia3.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentDbService _service;

        public EnrollmentsController(IStudentDbService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest student)
        {
            _service.EnrollStudent(student);
            var response = new EnrollStudentResponse();
            response.LastName = student.LastName;
            response.IndexNumber = student.IndexNumber;
            response.StartDate = new DateTime(2020, 08, 01);

            return Ok(response);
        }
    }
}