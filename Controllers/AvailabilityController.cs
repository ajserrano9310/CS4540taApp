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
 * Controller that handles the Availability view. Saves the new schedule after receiving a post from
 * JavaScript code. 
 */


using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PS4_TAApplication.Data;
using PS4_TAApplication.Models;

namespace PS4_TAApplication.Controllers
{
    public class AvailabilityController : Controller
    {
        private readonly Avail_DB _context;
        public AvailabilityController(Avail_DB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Avail()
        {
            return View(await _context.Availabilities.ToListAsync());
        }
        /// <summary>
        /// Saves the new schedule entered by the user in the application. 
        /// </summary>
        /// <param name="sch">schedule to be saved</param>
        /// <param name="id">id of the user</param>
        /// <returns></returns>
        public async Task<IActionResult> SaveSchedule(string sch, int? id)
        {
            if (sch == null){
                return Ok(BadRequest("Schedule is NULL"));
            }
            if (id == null){
                return Ok(BadRequest("Id is null"));
            }
            var userAvailability = await _context.Availabilities.FindAsync(id);
            if (userAvailability == null){
                return Ok(BadRequest("Availability is null"));
            }

            userAvailability.Date = sch;
            _context.SaveChanges();
            return View(Avail());
        }
    }

    
}
