using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS4_TAApplication.Models;

namespace PS4_TAApplication.Data
{
    public class TA_DB_Initializer
    {
        public static void Initialize(TA_DB context)
        {
            context.Database.EnsureCreated();

            if (context.Applications.Any())
            {
                return;
            }

            var applications = new Applications[]
           {
                new Applications {LastName="Jung", FirstName="gi", uID="00000001", GPA = 3.8, CurrentDegree = "CS", WorkHours=10, Fluency = "Fluent",Semesters = 8, Linkedin = "linkedin.com/kimjungi", PhoneNumber = "123 555 3232", Address="University Street",ApplicationDate = DateTime.Parse("2021-09-20")},
                new Applications {LastName="stacy", FirstName="gwen", uID="00000002", GPA = 3.9, CurrentDegree = "CE", WorkHours=20,Fluency = "Fluent",Semesters = 9,Linkedin = "linkedin.com/name",PhoneNumber = "123 456 7892",Address="123 S 321 N", ApplicationDate = DateTime.Parse("2021-09-20")},
                new Applications {LastName="banner", FirstName="bruce",uID="00000003", GPA = 3.2, CurrentDegree = "ME", WorkHours=20,Fluency = "Fluent",Semesters = 9,Linkedin = "linkedin.com/name",PhoneNumber = "123 456 7893",Address="123 S 321 N", ApplicationDate= DateTime.Parse("2021-09-20")},
                new Applications {LastName="romanoff", FirstName="natasha", uID="00000004", GPA = 3.7, CurrentDegree = "CS", WorkHours=20, Fluency = "Fluent",Semesters = 9,Linkedin = "linkedin.com/name",PhoneNumber = "123 456 7894",Address="123 S 321 N", ApplicationDate = DateTime.Parse("2021-09-20")},
                new Applications {LastName="kyle", FirstName="selina", uID="00000005", GPA=3.6, CurrentDegree = "CS",  WorkHours=20,Fluency = "Fluent",Semesters = 9,Linkedin = "linkedin.com/name",PhoneNumber = "123 456 7895",Address="123 S 321 N", ApplicationDate = DateTime.Parse("2021-09-20")},
           };

            foreach (Applications a in applications)
            {
                context.Applications.Add(a);
            }
            context.SaveChanges();
            /*
            if (context.Courses.Any())
            {
                return;
            }
            
            var courses = new Course[]
           {
            new Course{
                SemestersOffered="S/F",
                YearsOffered = "2021",
                Title="Introduction to Object Oriented Programming",
                Department ="CS",
                CourseNumber ="1410",
                Section = 1,
                ProfName = "David Johnson",
                ProfUnid = "00000010",
                TimeDay ="M/W 11:20 - 12:10",
                Location ="GC 2323",
                CreditHours=4,
                Capacity = 200,
                Note = ""
            },
            new Course{
                SemestersOffered="S/F",
                YearsOffered = "2021",
                Title="Discrete Math",
                Department ="CS",
                CourseNumber ="2100",
                Section = 1,
                ProfName = "Bei Wang Phillips",
                ProfUnid = "00000011",
                TimeDay ="T/Th 10:20 - 11:50",
                Location ="WEB 1234",
                CreditHours=4,
                Capacity = 200,
                Note = ""
            },
            new Course{
                SemestersOffered="S/F",
                YearsOffered = "2021",
                Title="Data Structures and Algorithms",
                Department ="CS",
                CourseNumber ="2420",
                Section = 1,
                ProfName = "Erin Parker",
                ProfUnid = "00000012",
                TimeDay ="M/W 10:20 - 11:50",
                Location ="GC 1122",
                CreditHours=4,
                Capacity = 200,
                Note = ""
            },
            new Course{
                SemestersOffered="S/F",
                YearsOffered = "2021",
                Title="Software Practice I",
                Department ="CS",
                CourseNumber ="3500",
                Section = 1,
                ProfName = "James de St Germain",
                ProfUnid = "00000013",
                TimeDay ="M/W 3:45 - 5:05",
                Location ="WEB 558",
                CreditHours=4,
                Capacity = 200,
                Note = ""
            },
            new Course{
                SemestersOffered="S/F",
                YearsOffered = "2021",
                Title="Computer Systems",
                Department ="CS",
                CourseNumber ="4400",
                Section = 1,
                ProfName = "Mu Zhang",
                ProfUnid = "00000014",
                TimeDay ="M/W 11:50 - 13:10",
                Location ="WEB 558",
                CreditHours=4,
                Capacity = 200,
                Note = ""
            },
           };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();
            */
        }
    }
}
    

