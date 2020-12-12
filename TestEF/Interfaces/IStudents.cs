using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEF.DBContext;
using TestEF.DTO;
using TestEF.Models;

namespace TestEF.Interfaces
{
    public interface IStudents
    {
        public ActionResult<IEnumerable<StudentDTO>> GetListStudents();
        public Students GetStudentsByID(int id);
        public API_ErrorModel AddStudent(Students students);
        public API_ErrorModel UpdateStudent(int id,Students students);
        public API_ErrorModel DeleteStudent(int id);
        public ActionResult<IEnumerable<CourseDTO>> GetCoursesbyStudentID(int Id);
    }
}
