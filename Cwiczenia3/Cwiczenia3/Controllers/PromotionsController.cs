using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenia3.DTO.Requests;
using Cwiczenia3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia3.Controllers
{
    [Route("api/enrollments/promotions")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private IStudentDbService _service;
        public PromotionsController(IStudentDbService service)
        {
            _service = service;
        }
        [HttpPost]
        [Authorize(Roles ="employee")]
        public IActionResult PromoteStudent(PromoteStudentRequest promotion)
        {
            var response = _service.PromoteStudent(promotion);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
    }
}