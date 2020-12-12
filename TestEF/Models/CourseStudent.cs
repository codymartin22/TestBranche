using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestEF.Models
{
    public class CourseStudent
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Students Students { get; set; }
        [ForeignKey("CourseId")]
        public Courses Courses { get; set; }
    }
}
