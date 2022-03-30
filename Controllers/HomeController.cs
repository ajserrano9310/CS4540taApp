using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PS4_TAApplication.Areas.Identity.Data;
using PS4_TAApplication.Data;
using PS4_TAApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

/*
 * <!--
    Author:    Alejandro Serrano
    Partner:   None
    Date:      10/11/2021
    Course:    CS 4540, University of Utah, School of Computing
    Copyright: CS 4540 and Alejandro Serrano - This work may not be copied for use in Academic Coursework.

    I, Alejandro Serrano, certify that I edited this coded and did not copy it in part or whole from
    another source.  Any references used in the completion of the assignment are cited in my README file.

    File Contents

    Modified with Change_Role method and the Admin view
  -->
 **/

namespace PS4_TAApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<TAUser> _um;
        private readonly RoleManager<IdentityRole> _rm;
        private readonly TAUsersRolesDB dB;

        public HomeController(ILogger<HomeController> logger,
            UserManager<TAUser> um,
            RoleManager<IdentityRole> rm,
            TAUsersRolesDB context)
        {
            _logger = logger;
            _um = um;
            _rm = rm;
            dB = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult HW1_Application()
        {
            return View();
        }
        public IActionResult HW2_Edit()
        {
            return View();
        }
        public IActionResult HW2_Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Admin()
        {

            
            return View(_um.Users);
        }

        public async Task<IActionResult> ChangeRole(string userid, string role, bool enable_disable)
        {
            var user = await _um.FindByIdAsync(userid);

            

            if (user == null)
            {
                return Ok(BadRequest("Could not find user"));
            }

            await _um.AddToRoleAsync(user, role);
            dB.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;


            return View(Admin());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
