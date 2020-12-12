﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestEF.DBContext;

namespace TestEF.Migrations
{
    [DbContext(typeof(AppsDBContext))]
    partial class AppsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("TestEF.Models.CourseStudent", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("TestEF.Models.Courses", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("StudentsStudentId")
                        .HasColumnType("integer");

                    b.HasKey("CourseId");

                    b.HasIndex("StudentsStudentId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("TestEF.Models.Students", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TestEF.Models.CourseStudent", b =>
                {
                    b.HasOne("TestEF.Models.Courses", "Courses")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestEF.Models.Students", "Students")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("TestEF.Models.Courses", b =>
                {
                    b.HasOne("TestEF.Models.Students", null)
                        .WithMany("Courses")
                        .HasForeignKey("StudentsStudentId");
                });

            modelBuilder.Entity("TestEF.Models.Courses", b =>
                {
                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("TestEF.Models.Students", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("CourseStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
