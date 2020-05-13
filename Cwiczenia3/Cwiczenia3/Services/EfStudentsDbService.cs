using Cwiczenia3.DTO.Requests;
using Cwiczenia3.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia3.Services
{
    public class EfStudentsDbService : IStudentDbService
    {
        public bool CheckCredential(string login, string password)
        {
            throw new NotImplementedException();
        }

        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest student)
        {
            throw new NotImplementedException();
        }

        public PromoteStudentResponse PromoteStudent(PromoteStudentRequest promotion)
        {
            throw new NotImplementedException();
        }
    }
}
