using Cwiczenia3.DAL;
using Cwiczenia3.DTO.Requests;
using Cwiczenia3.Models;
using Cwiczenia3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cwiczenia3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentDbService _dbService;
        public IConfiguration Configuration { get; set; }

        public StudentsController(IStudentDbService dbService, IConfiguration configuration)
        {
            _dbService = dbService;
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }else if (id == 2)
            {
                return Ok("Malewski");
            }
            return NotFound("Nie znaleziono studenta");
        }
        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            var claims = new[]
{
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, "jan123"),
                new Claim(ClaimTypes.Role, "admin"),
                new Claim(ClaimTypes.Role, "student")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "Gakko",
                audience: "Students",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = Guid.NewGuid()
            });
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            return Ok(student);
        }

        [HttpDelete]
        public IActionResult DeleteStudent(string StudentId)
        {
            return Ok("Usuwanie ukończone");
        }

        [HttpPut]
        public IActionResult PutStudent(string StudentId)
        {
            return Ok("Wstawianie ukonczone");
        }
    }
}
