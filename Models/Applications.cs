using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
Author: Alejandro Serrano
Partner: None
Date:      9 / 28 / 2021
Course: CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Alejandro Serrano - This work may not be copied for use in Academic Coursework.

  I, Alejandro Serrano, certify that I edited this code from what was provided by scaffolding or the Contoso University Tutorial and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.

  File Contents:
  The required model for scaffolding and creating the DB
*/
namespace PS4_TAApplication
{
    public class Applications
    {

        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string uID { get; set; }
        public double GPA { get; set; }
        public string CurrentDegree { get; set; }
        public int WorkHours { get; set; }
        public string Fluency { get; set; }
        public int Semesters { get; set; }
        public string Linkedin { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}