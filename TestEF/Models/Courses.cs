using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestEF.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
    }
}
