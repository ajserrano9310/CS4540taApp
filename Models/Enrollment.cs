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
 * Enrollment class that holds the date and the amount that was enrolled that day. 
 * Has foreign key to the CourseEnrollment model. 
 *  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS4_TAApplication.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public DateTime EnrollmentData { get; set; }
        public int EnrollmentQuantity { get; set; }

        public CourseEnrollment CourseEnrollment { get; set; }
    }
}
