using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestEF.Models
{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
    }
}
