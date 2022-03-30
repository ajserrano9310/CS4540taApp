using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PS4_TAApplication.Models;


namespace PS4_TAApplication.Data
{
    public class Course_DB:DbContext
    {
        public Course_DB(DbContextOptions<Course_DB> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
        }

    }
}
