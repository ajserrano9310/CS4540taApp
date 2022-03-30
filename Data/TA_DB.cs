using PS4_TAApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace PS4_TAApplication.Data
{
    public class TA_DB : DbContext
    {
        public TA_DB(DbContextOptions<TA_DB> options) : base(options)
        { } 

        public DbSet<Applications> Applications { get; set; }
        //public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applications>().ToTable("Applications");
            /*
            modelBuilder.Entity<Course>().ToTable("Course");
            */
        }
    } 
}
