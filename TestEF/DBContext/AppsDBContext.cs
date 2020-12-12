using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEF.Models;

namespace TestEF.DBContext
{
    public class AppsDBContext:DbContext
    {
        public AppsDBContext(DbContextOptions<AppsDBContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>().HasKey(e => new { e.CourseId, e.StudentId });
            modelBuilder.Entity<CourseStudent>().HasOne<Students>(st => st.Students).WithMany(p => p.CourseStudents);
            modelBuilder.Entity<CourseStudent>().HasOne<Courses>(c => c.Courses).WithMany(p => p.CourseStudents);
        }
        public DbSet<Students> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<TestEF.Models.CourseStudent> CourseStudent { get; set; }
    }
}
