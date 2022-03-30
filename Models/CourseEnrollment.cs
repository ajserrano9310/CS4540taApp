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
 * Model for the course enrollment. Holds id of the course and it's name and list
 * of Enrollments (see enrollment.cs)
 *  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS4_TAApplication.Models
{
    public class CourseEnrollment
    {
        public int ID { get; set; }
        public string CourseName { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
