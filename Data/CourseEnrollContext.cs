
/**
 * Author:    Alejandro Serrano
 * Partner:   None
 * Date:      12/9/2021
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Alejandro Serrano - This work may not be copied for use in Academic Coursework.
 *
 * I, Alejandro Serrano, certify that I wrote this code from scratch and did
 * not copy it in part or whole from another source.  Any references used
 * in the completion of the assignment are cited in my README file and in
 * the appropriate method header.
 *
 * File Contents
 * Course enrollment context for database. 
 *  
 */using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PS4_TAApplication.Models;

namespace PS4_TAApplication.Data
{
    public class CourseEnrollContext: DbContext
    {
        public CourseEnrollContext(DbContextOptions<CourseEnrollContext> 
            options) :base(options)
        {

        }

        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseEnrollment>().ToTable("CourseEnrollment");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        }
    }
}
