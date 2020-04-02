using Cwiczenia3.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia3.Services
{
    public interface IStudentDbService
    {
        bool EnrollStudent(EnrollStudentRequest student);
    }
}
