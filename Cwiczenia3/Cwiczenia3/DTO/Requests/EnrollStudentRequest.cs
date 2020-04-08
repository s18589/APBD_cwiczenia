using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia3.DTO.Requests
{
    public class EnrollStudentRequest
    {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string IndexNumber { get; set; }
            public string Studies { get; set; }
            public DateTime BirthDate { get; set; }
        
    }
}
