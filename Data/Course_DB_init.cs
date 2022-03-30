using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS4_TAApplication.Models;

namespace PS4_TAApplication.Data
{
    public class Course_DB_init
    {
        public static void Initialize(Course_DB context)
        {
            context.Database.EnsureCreated();

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
                Note = "",
                CourseDescription ="This course is an introduction to the engineering and mathematical skills required to effectively program computers and is designed for students with no prior programming experience."
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
                Note = "",
                CourseDescription = "Introduction to propositional logic, predicate logic, formal logical arguments, finite sets, functions, relations, inductive proofs, recurrence relations, graphs, probability, and their applications to Computer Science"
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
                Note = "",
                CourseDescription = "This course provides an introduction to the problem of engineering computational efficiency into programs. Students will learn about classical algorithms (including sorting, searching, and graph traversal), data structures (including stacks, queues, linked lists, trees, hash tables, and graphs), and analysis of program space and time requirements. Students will complete extensive programming exercises that require the application of elementary techniques from software engineering."
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
                Note = "",
                CourseDescription = "Practical exposure to the process of creating large software systems, including requirements specifications, design, implementation, testing, and maintenance. Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), software engineering techniques (time management, code, and documentation standards, source code management, object-oriented analysis and design), and team development practice. Much of the work will be in groups and will involve modifying preexisting software systems."
         
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
                Note = "",
                CourseDescription ="Introduction to computer systems from a programmer's point of view. Machine level representations of programs, optimizing program performance, memory hierarchy, linking, exceptional control flow, measuring program performance, virtual memory, concurrent programming with threads, network programming."
            },
           };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();
        }
    }
}
