using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PS4_TAApplication;
using PS4_TAApplication.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using PS4_TAApplication.Areas.Identity.Data;

/*< !--
    Author: Alejandro Serrano
Partner: None
Date: 10 / 11 / 2021
Course: CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Alejandro Serrano - This work may not be copied for use in Academic Coursework.

I, Alejandro Serrano, certify that I edited this code from what was provided.Any references used in the completion of the assignment are cited in my README file.

File Contents

Modified constructor in order to be able to acces the user manager. 
Added appropriate authorizations for different views. 
Modified "Edit" and "Details" methods so that it can utilize user manager. 
-->*/

namespace PS4_TAApplication.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly TA_DB _context;
        private readonly UserManager<TAUser> userManager;

        public ApplicationsController(TA_DB context, UserManager<TAUser> _userManager)
        {
            _context = context;
            userManager = _userManager;
        }

        // GET: Applications
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> List()
        {
            return View(await _context.Applications.ToListAsync());
        }

        // GET: Applications/Details/5
        [Authorize(Roles = "Applicant")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userManager.FindByIdAsync(id);

            var applications = await _context.Applications
                .FirstOrDefaultAsync(m => m.uID == user.uNumber);
            if (applications == null)
            {
                return NotFound();
            }

            return View(applications);
        }

        // GET: Applications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstName,uID,GPA,CurrentDegree,WorkHours,Fluency,Semesters,Linkedin,PhoneNumber,Address,ApplicationDate")] Applications applications)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applications);
        }

        // GET: Applications/Edit/5
        [Authorize(Roles = "Applicant")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userManager.FindByIdAsync(id);
            var applications = await _context.Applications
                .FirstOrDefaultAsync(m => m.uID == user.uNumber);

            if (applications == null)
            {
                return NotFound();
            }
            return View(applications);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Applicant")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstName,uID,GPA,CurrentDegree,WorkHours,Fluency,Semesters,Linkedin,PhoneNumber,Address,ApplicationDate")] Applications applications)
        {
            if (id != applications.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applications);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationsExists(applications.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applications);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applications = await _context.Applications
                .FirstOrDefaultAsync(m => m.ID == id);
            if (applications == null)
            {
                return NotFound();
            }

            return View(applications);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applications = await _context.Applications.FindAsync(id);
            _context.Applications.Remove(applications);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationsExists(int id)
        {
            return _context.Applications.Any(e => e.ID == id);
        }
    }
}
