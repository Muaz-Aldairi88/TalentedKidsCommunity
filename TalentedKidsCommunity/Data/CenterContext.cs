using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentedKidsCommunity.Models;

namespace TalentedKidsCommunity.Data
{
    public class CenterContext : DbContext
    {
        public CenterContext (DbContextOptions<CenterContext> options)
            : base(options)
        {
        }

        public DbSet<Kid> Kids { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CenterAssignment> CenterAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //using the fluent API to configure EF Core behavior (only for database mapping that can't be done with attributes)
            modelBuilder.Entity<Course>().ToTable(nameof(Course))
                .HasMany(c => c.Instructors)
                .WithMany(i => i.Courses);
            modelBuilder.Entity<Kid>().ToTable(nameof(Kid));
            modelBuilder.Entity<Instructor>().ToTable(nameof(Instructor));
        }
    }
}
