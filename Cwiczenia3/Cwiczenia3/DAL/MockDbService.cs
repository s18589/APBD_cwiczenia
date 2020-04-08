using Cwiczenia3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia3.DAL
{
    public class MockDbService : IDbService
    {
        private static List<Student> _students;
        static MockDbService() {
            _students = new List<Student>();
            using (var client = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18589;Integrated Security=true"))
            using (var command = new SqlCommand())
            {
                string StudentNumber = "1";
                command.Connection = client;
                command.CommandText = "select student.firstname, student.lastname,student.birthdate,enrollment.semester, studies.name from student inner join enrollment on student.idenrollment=enrollment.idenrollment inner join studies on studies.idstudy = enrollment.idstudy where student.indexnumber=@id";
                command.Parameters.AddWithValue("id", StudentNumber);
                client.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var Student = new Student();
                    Student.FirstName = reader["firstname"].ToString();
                    Student.LastName = reader["lastname"].ToString();
                    Student.BirthDate = reader["birthdate"].ToString();
                    Student.Semester = reader["semester"].ToString();
                    Student.StudiesName = reader["name"].ToString();
                    _students.Add(Student);
                }
                reader.Close();
                client.Dispose();
                client.Close();
            }
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
