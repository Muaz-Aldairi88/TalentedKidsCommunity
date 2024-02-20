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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Kid>().ToTable("Kid");
        }
    }
}
