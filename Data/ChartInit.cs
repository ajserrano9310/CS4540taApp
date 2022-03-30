using PS4_TAApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
 * Initializes database with corresponding CSV. 
 *  
 */
namespace PS4_TAApplication.Data
{
    public class ChartInit
    {
        public static void Initialize(CourseEnrollContext context)
        {
            context.Database.EnsureCreated();

            if (context.CourseEnrollments.Any())
            {
                return;
            }

            List<CourseEnrollment> courseEnrollments = new List<CourseEnrollment>();
            List<Enrollment> enrollments = new List<Enrollment>();
            string filename = "temp.csv";
            string path = Path.Combine(Environment.CurrentDirectory, @"Data", filename);
            DateTime[] dates = new DateTime[29]; 

            string[] lines = System.IO.File.ReadAllLines(path);

            int courseID = 1;
            int dateIndex = 0; 

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');

                if (columns[0].Equals("Course"))
                {

                    DateTime current = DateTime.Parse("2021-11-01");
                    int j = 0;
                    dates[j] = current;
                    for (int i = 2; i <= columns.Length - 1; i++)
                    {
                        j++; 
                        current = current.AddDays(1.0);
                        dates[j] = current;
                    }
                    continue; 
                }
                
                CourseEnrollment course = new CourseEnrollment();
                course.CourseName = columns[0];
                courseEnrollments.Add(course);

                for(int i = 1; i < columns.Length; i++)
                {
                    Enrollment e = new Enrollment();
                    e.CourseID = courseID;
                    e.EnrollmentData = dates[dateIndex];
                    e.EnrollmentQuantity = Int32.Parse(columns[i]);

                    enrollments.Add(e);
                    dateIndex++; 
                }
                dateIndex = 0;
                courseID++; 
            }
         
            foreach (CourseEnrollment course in courseEnrollments)
            {
                context.CourseEnrollments.Add(course);
            }
            context.SaveChanges();
            
            foreach(Enrollment enrollment in enrollments)
            {
                context.Enrollments.Add(enrollment);
            }          
            context.SaveChanges();


        }
    }
}
