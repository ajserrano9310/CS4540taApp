using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PS4_TAApplication.Data;

/*
 * <!--
  Author:    Alejandro Serrano
  Partner:   None
  Date:      10/11/2021
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540 and Alejandro Serrano - This work may not be copied for use in Academic Coursework.

  I, Alejandro Serrano, certify that I used external resources for this portion of the assignment.  
  Any references used in the completion of the assignment are cited in my README file.

  File Contents

  The current file seeds the information to the database
-->
 */
namespace PS4_TAApplication.Areas.Identity.Data
{
    public class SeedUsersRolesDB
    {
        public static async Task Seed(UserManager<TAUser> um,
            RoleManager<IdentityRole> rm,
            TAUsersRolesDB context)
        {
            await context.Database.EnsureCreatedAsync();
            await SeedRole(rm);
            await SeedUser(um);
        }

        private static async Task SeedUser(UserManager<TAUser> userManager)
        {

            if (await userManager.FindByEmailAsync("luisa@utah.edu") == null)
            {
                TAUser user = new TAUser();

                user.UserName = "luisa@utah.edu";
                user.Email = "luisa@utah.edu";
                user.EmailConfirmed = true;

                var x = userManager.CreateAsync(user, "123ABC!@#def");

                x.Wait();

                await userManager.AddToRoleAsync(user, "Administrator");


            }

            if (await userManager.FindByEmailAsync("carlos@utah.edu") == null)
            {
                TAUser user = new TAUser();
                user.UserName = "carlos@utah.edu";
                user.Email = "carlos@utah.edu";
                user.EmailConfirmed = true;


                var x = userManager.CreateAsync(user, "123ABC!@#def");
                x.Wait();
                await userManager.AddToRoleAsync(user, "Professor");


            }

            if (await userManager.FindByEmailAsync("kimjunggi@utah.edu") == null)
            {
                TAUser user = new TAUser();
                user.UserName = "kimjunggi@utah.edu";
                user.Email = "kimjunggi@utah.edu";
                user.EmailConfirmed = true;
                user.Name = "Kim Jung Gi";
                user.Linkedin = "linkedin/kim";
                user.PhoneNumber = "123 555 3232";
                user.WorkHours = 10;
                user.GPA = 3.8;
                user.Fluency = "Fluent";
                user.Semesters = 8;
                user.Address = "University Street";
                user.CurrentDegree = "CS";
                user.uNumber = "u0000000";
                user.ApplicationCompleted = true;

                var x = userManager.CreateAsync(user, "123ABC!@#def");
                x.Wait();
                await userManager.AddToRoleAsync(user, "Applicant");
            }

            if (await userManager.FindByEmailAsync("juan@utah.edu") == null)
            {
                TAUser user = new TAUser();
                user.UserName = "juan@utah.edu";
                user.Email = "juan@utah.edu";
                user.EmailConfirmed = true;
                user.ApplicationCompleted = false;

                var x = userManager.CreateAsync(user, "123ABC!@#def");
                x.Wait();
                await userManager.AddToRoleAsync(user, "Applicant");
            }

        }

        private static async Task SeedRole(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Applicant").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Applicant";
                await roleManager.CreateAsync(role);

            }
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                await roleManager.CreateAsync(role);

            }
            if (!roleManager.RoleExistsAsync("Professor").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Professor";
                await roleManager.CreateAsync(role);

            }
        }


    }



        
}


