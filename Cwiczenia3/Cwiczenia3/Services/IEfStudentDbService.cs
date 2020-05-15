using Cwiczenia3.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia3.Services
{
    public interface IEfStudentDbService
    {
        public List<Student> GetStudents();
        public Student UpdateStudent(Student student);
        public Student DeleteStudent(Student student);
        public Student InsertStudent(Student student);
    }
}
