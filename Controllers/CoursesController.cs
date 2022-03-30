/*
< !--
    Author:    Alejandro Serrano
    Partner:   None
    Date:      10 / 25 / 2021
    Course: CS 4540, University of Utah, School of Computing
    Copyright: CS 4540 and Alejandro Serrano - This work may not be copied for use in Academic Coursework.

    I, Alejandro Serrano, certify that I scaffolded this code from scratch and did not copy it in part or whole from
    another source.  Any references used in the completion of the assignment are cited in my README file.

    File Contents

    Controller for Couses model
  -->
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PS4_TAApplication.Data;
using PS4_TAApplication.Models;

namespace PS4_TAApplication.Controllers
{
    public class CoursesController : Controller
    {
        private readonly Course_DB _context;

        public CoursesController(Course_DB context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrator, Applicant, Professor")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("ID,SemestersOffered,YearsOffered,Title,Department,CourseNumber,Section,ProfUnid,ProfName,TimeDay,Location,CreditHours,Capacity,Note")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SemestersOffered,YearsOffered,Title,Department,CourseNumber,Section,ProfUnid,ProfName,TimeDay,Location,CreditHours,Capacity,Note")] Course course)
        {
            if (id != course.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.ID))
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
            return View(course);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.ID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.ID == id);
        }

        /// <summary>
        /// Allows admin to add notes to courses. 
        /// </summary>
        /// <param name="note"> Note to add to course model</param>
        /// <param name="course_id">id of the course for updating</param>
        /// <returns>Returns view if course is retrieved succesfully, otherwise a bad request</returns>
        public async Task<IActionResult> SubmitNote(string note, int? course_id)
        {
            if(note == null)
            {
                return Ok(BadRequest("Note is null"));
            }
            
            if(course_id == null)
            {
                return Ok(BadRequest("Id is null"));
            }
            var course = await _context.Courses.FindAsync(course_id);
            

            if(course == null)
            {
                return Ok(BadRequest("Course is null"));
            }

            course.Note = note;
            _context.SaveChanges();
            

         

            return View(Index());
        }
    }
}
