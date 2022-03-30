using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
Author: Alejandro Serrano
Partner: None
Date:      10 / 25 / 2021
Course: CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Alejandro Serrano - This work may not be copied for use in Academic Coursework.

  I, Alejandro Serrano, certify that I wrote this code and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.

  File Contents:
  The required model for scaffolding and creating the DB
*/

namespace PS4_TAApplication.Models
{

    public class Course
    {
        public int ID { get; set; }
        public string SemestersOffered { get; set; }
        public string YearsOffered { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string CourseNumber { get; set; }
        public int Section { get; set; }
        public string ProfUnid { get; set; }
        public string ProfName { get; set; }
        public string TimeDay { get; set; }
        public string Location { get; set; }
        public int CreditHours { get; set; }
        public int Capacity { get; set; }
        public string Note { get; set; }
        public string CourseDescription { get; set; }
    }
}
