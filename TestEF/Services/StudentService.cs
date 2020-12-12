using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEF.DBContext;
using TestEF.DTO;
using TestEF.Interfaces;
using TestEF.Models;

namespace TestEF.Services
{
    public class StudentService : IStudents
    {
        private readonly AppsDBContext _context;
        public StudentService(AppsDBContext context)
        {
            this._context = context;
        }
        public API_ErrorModel AddStudent(Students students)
        {
            try
            {
                _context.Students.Add(students);
                _context.SaveChanges();
                var model = new API_ErrorModel("Thành Công", "Thêm thành công");
                return model;
            }
            catch
            {
                var model = new API_ErrorModel("Thất Bại", "Thêm thất bại");
                return model;
            }
        }

        public API_ErrorModel DeleteStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(p => p.StudentId == id);
            if (student == null)
            {
                var model = new API_ErrorModel("Thất bại", "Không tìm thấy Student");
                return model;
            }
            _context.Students.Attach(student);
            _context.Students.Remove(student);
            try
            {
                _context.SaveChanges();
                var model = new API_ErrorModel("Thành công","Xóa thành công");
                return model;
            }
            catch
            {
                var model = new API_ErrorModel("Thất bại", "Xóa thất bại");
                return model;
            }
        }
        public ActionResult<IEnumerable<CourseDTO>> GetCoursesbyStudentID(int Id)
        {
            return _context.Students.Where(p => p.StudentId == Id).SelectMany(p => p.CourseStudents).Select(p => new CourseDTO { 
                CourseID = p.CourseId,CourseName = p.Courses.Name
            }).ToList();
        }

        public ActionResult<IEnumerable<StudentDTO>> GetListStudents()
        {
            return _context.Students.Select(o => new StudentDTO {
                StudentID = o.StudentId,StudentName = o.Name
            }).ToList();
        }

        public Students GetStudentsByID(int id)
        {
            return _context.Students.SingleOrDefault(p => p.StudentId == id);
        }

        public API_ErrorModel UpdateStudent(int id, Students students)
        {
            var student = _context.Students.SingleOrDefault(p => p.StudentId == id);
            if (student == null)
            {
                var model = new API_ErrorModel("Thất bại", "Không tìm thấy Student");
                return model;
            }
            _context.Students.Update(student);
            try
            {
                _context.SaveChanges();
                var model = new API_ErrorModel("Thành công", "Cập nhật thành công");
                return model;
            }
            catch
            {
                var model = new API_ErrorModel("Thất bại", "Cập nhật thất bại");
                return model;
            }
        }
    }
}
