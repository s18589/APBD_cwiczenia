using Cwiczenia3.DTO.Requests;
using Cwiczenia3.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia3.Services
{
    public class SqlServerStudentDbService : IStudentDbService
    {
        [HttpPost]
        public bool EnrollStudent(EnrollStudentRequest student)
        {
            var st = new Student();
            st.FirstName = student.FirstName;
            st.LastName = student.LastName;
            st.IndexNumber = student.IndexNumber;
            st.StudiesName = student.Studies;
            st.BirthDate = student.BirthDate;
            st.Semester = "1";

            using (var connection = new SqlConnection(""))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                connection.Open();
                var transaction = connection.BeginTransaction();

                command.CommandText = "select IdStudies from studies where name=@name";
                command.Parameters.AddWithValue("name", student.Studies);

                var dr = command.ExecuteReader();
                if (!dr.Read())
                {
                    transaction.Rollback();
                    return false;
                }
                command.CommandText = "select enrollment.semester, studies.name from enrollment inner join studies on enrollment.idstudy = studies.idstudy where enrollment.semester = 1 and studies.name = @name";

                dr = command.ExecuteReader();
                if (!dr.Read())
                {
                    
                }
                connection.Close();
            }
            return true;
        }
    }
}
