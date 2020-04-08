using Cwiczenia3.DTO.Requests;
using Cwiczenia3.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cwiczenia3.DTO.Responses;

namespace Cwiczenia3.Services
{
    public class SqlServerStudentDbService : IStudentDbService
    {
        [HttpPost]
        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest student)
        {
            
            using (var connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18589;Integrated Security=true"))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                connection.Open();
                var transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                
                DateTime date = DateTime.Now;

                command.CommandText = "select IdStudy from studies where name=@name";
                command.Parameters.AddWithValue("firstname", student.FirstName);
                command.Parameters.AddWithValue("lastname", student.LastName);
                command.Parameters.AddWithValue("birthdate", student.BirthDate);
                command.Parameters.AddWithValue("name", student.Studies);
                command.Parameters.AddWithValue("indexnumber", student.IndexNumber);
                command.Parameters.AddWithValue("date", date);

                int idStudy;
                
                var dr = command.ExecuteReader();
                if (!dr.HasRows)
                {
                    transaction.Rollback();
                    throw new ArgumentException("Nie ma takich studiów");
                }
                dr.Read();
                idStudy = dr.GetInt32(0);

                command.Parameters.AddWithValue("idstudy", idStudy);
                dr.Close();
                
                command.CommandText = "select enrollment.semester, studies.name from enrollment inner join studies on enrollment.idstudy = studies.idstudy where enrollment.semester = 1 and studies.name = @name";
                var dr1 = command.ExecuteReader();

                if (!dr1.HasRows)
                {
                    command.CommandText = "insert into enrollment(semester,idstudy,startdate) values (1,@idstudy,@date)";
                    command.ExecuteNonQuery();
                }
                dr1.Close();
                
                command.CommandText = "select indexnumber from student where indexnumber = @indexnumber";
                var dr4 = command.ExecuteReader();
                
                if (dr4.HasRows)
                {
                    dr4.Close();
                    transaction.Rollback();
                    throw new ArgumentException("student o danym indeksie juz istnieje");
                }
                dr4.Close();

                command.CommandText = "select idenrollment from enrollment where idstudy = @idstudy and semester = 1";
                var dr5 = command.ExecuteReader();
                dr5.Read();
                int idenrollment = dr5.GetInt32(0);

                command.Parameters.AddWithValue("idenrollment", idenrollment);
                dr5.Close();
                command.CommandText = "insert into student(indexnumber,firstname,lastname,birthdate,idenrollment) values(@indexnumber,@firstname,@lastname,@birthdate,@idenrollment)";

                var dr6 = command.ExecuteReader();
                dr6.Close();

                transaction.Commit();
                
                connection.Close();
                return new EnrollStudentResponse
                {
                    StartDate = date,
                    IndexNumber = student.IndexNumber,
                    LastName = student.LastName
                };
            }
        }
    }
}
