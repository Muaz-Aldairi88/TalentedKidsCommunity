﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalentedKidsCommunity.Data;

#nullable disable

namespace TalentedKidsCommunity.Migrations
{
    [DbContext(typeof(CenterContext))]
    partial class CenterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.Property<int>("CoursesCourseID")
                        .HasColumnType("int");

                    b.Property<int>("InstructorsInstructorID")
                        .HasColumnType("int");

                    b.HasKey("CoursesCourseID", "InstructorsInstructorID");

                    b.HasIndex("InstructorsInstructorID");

                    b.ToTable("CourseInstructor");
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.CenterAssignment", b =>
                {
                    b.Property<int>("InstructorID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("InstructorID");

                    b.ToTable("CenterAssignments");
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("CourseDay")
                        .HasColumnType("int");

                    b.Property<decimal>("CourseFee")
                        .HasColumnType("money");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CourseID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("InstructorID")
                        .HasColumnType("int");

                    b.HasKey("DepartmentID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("KidID")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("KidID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructorID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Talend")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("InstructorID");

                    b.ToTable("Instructor", (string)null);
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.Kid", b =>
                {
                    b.Property<int>("KidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KidID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("KidID");

                    b.ToTable("Kid", (string)null);
                });

            modelBuilder.Entity("CourseInstructor", b =>
                {
                    b.HasOne("TalentedKidsCommunity.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TalentedKidsCommunity.Models.Instructor", null)
                        .WithMany()
                        .HasForeignKey("InstructorsInstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.CenterAssignment", b =>
                {
                    b.HasOne("TalentedKidsCommunity.Models.Instructor", "Instructor")
                        .WithOne("CenterAssignment")
                        .HasForeignKey("TalentedKidsCommunity.Models.CenterAssignment", "InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.Course", b =>
                {
                    b.HasOne("TalentedKidsCommunity.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.Department", b =>
                {
                    b.HasOne("TalentedKidsCommunity.Models.Instructor", "Administrator")
                        .WithMany()
                        .HasForeignKey("InstructorID");

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.Enrollment", b =>
                {
                    b.HasOne("TalentedKidsCommunity.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TalentedKidsCommunity.Models.Kid", "Kid")
                        .WithMany("Enrollments")
                        .HasForeignKey("KidID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Kid");
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.Department", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.Instructor", b =>
                {
                    b.Navigation("CenterAssignment");
                });

            modelBuilder.Entity("TalentedKidsCommunity.Models.Kid", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
