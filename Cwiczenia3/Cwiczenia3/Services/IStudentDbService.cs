using Cwiczenia3.DTO.Requests;
using Cwiczenia3.DTO.Responses;
using Cwiczenia3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia3.Services
{
    public interface IStudentDbService
    {
        EnrollStudentResponse EnrollStudent(EnrollStudentRequest student);
        PromoteStudentResponse PromoteStudent(PromoteStudentRequest promotion);
    }
}
