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
 *
 * Handles the database information by returning a view with the list of courses and enrollments.  
 *  
 */

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS4_TAApplication.Data;
using PS4_TAApplication.Models;
using System.Collections;

namespace PS4_TAApplication.Controllers
{
    public class ChartController : Controller
    {

        private readonly CourseEnrollContext _context;

        public ChartController(CourseEnrollContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Considering this similar to what the enrollmentTrends method is described to do. 
        /// It returns the model of the database. 
        /// </summary>
        /// <returns></returns>
        public IActionResult Charts()
        {
            return View(_context.CourseEnrollments.ToList());
        }

        public IActionResult PieChart()
        {
            return View(_context.CourseEnrollments.ToList());
        }
        /// <summary>
        /// Returns a list of enrollments based on the start and end date
        /// </summary>
        /// <param name="course">query course</param>
        /// <param name="start">start date</param>
        /// <param name="end"> end date </param>
        /// <returns></returns>
        public ArrayList GetEnrollment(string course, int? start, int? end)
        {
            var courses = _context.CourseEnrollments.ToList();
           
            ArrayList q = new ArrayList();
            List<Enrollment> enrollmentOfOneCourse = new List<Enrollment>();
    
            CourseEnrollment c = null;
            foreach(var val in courses)
            {
                if (val.CourseName.Equals(course))
                {
                    c = val;
                    break;
                }
            }

            var enroll = _context.Enrollments.ToList();

            enroll.Sort((x,y) => x.CourseID.CompareTo(y.CourseID));
            
            foreach(var e in enroll)
            {
                if(c.ID == e.CourseID)
                {
                    enrollmentOfOneCourse.Add(e);
                }
            }

            enrollmentOfOneCourse.Sort((x, y) => x.EnrollmentData.CompareTo(y.EnrollmentData));

            foreach(Enrollment e in enrollmentOfOneCourse)
            {
                q.Add(e.EnrollmentQuantity);
            } 
            
            int sizeOfFinalArray = (int)(end - start);
            ArrayList f = new ArrayList();

            for(int i = (int)start; i <= (int)end; i ++ )
            {
                f.Add(q[i]);
            }

            return f;

        }

    }
}
