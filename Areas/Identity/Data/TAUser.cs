using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PS4_TAApplication.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the TAUser class
    public class TAUser : IdentityUser
    {

        
        public string Name { get; set; }
        public string uNumber { get; set; }
        public double GPA { get; set; }
        public string CurrentDegree { get; set; }
        public int WorkHours { get; set; }
        public string Fluency { get; set; }
        public int Semesters { get; set; }
        public string Linkedin { get; set; }
        public string Address { get; set; }
        public bool ApplicationCompleted { get; set; }
    }
}
