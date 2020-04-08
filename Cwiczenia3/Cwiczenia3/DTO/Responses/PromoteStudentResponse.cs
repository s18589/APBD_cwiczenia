using Cwiczenia3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia3.DTO.Responses
{
    public class PromoteStudentResponse
    {
        public int IdEnrollment { get; set; }
        public int IdStudy { get; set; }

        public int Semester { get; set; }
        public DateTime StartDate { get; set; }
    }
}
