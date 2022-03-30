
/**
 * Author:    Alejandro Serrano
 * Partner:   None
 * Date:      11/21/2021
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
 * Initializes the data base with dummy information for testing purposes. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PS4_TAApplication.Models;

namespace PS4_TAApplication.Data
{
    public class AvailInit
    {
        public static void Initialize(Avail_DB context)
        {
            context.Database.EnsureCreated();

            if (context.Availabilities.Any())
            {
                return;
            }

            var availabilities = new Availability[]
           {
            new Availability{ Date="Monday 10:15", UniversityNumber="u0000000"}
           };
            foreach (Availability a in availabilities )
            {
                context.Availabilities.Add(a);
            }
            context.SaveChanges();
        }
    }
}
