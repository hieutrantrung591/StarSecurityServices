using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using StarSecurityServices.Extensions;
using StarSecurityServices.Helpers;
using StarSecurityServices.Models;

namespace StarSecurityServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly StarSecurityDBContext _context;

        public LoginController(StarSecurityDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = HashMD5.GetMD5(password);
                var data = _context.Employees.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    // Session["FullName"] = data.FirstOrDefault().Name;
                    // Session["Email"] = data.FirstOrDefault().Email;
                    // Session["idUser"] = data.FirstOrDefault().Id;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

 
        public ActionResult Logout()
        {
            // Session.Clear();//remove session
            return RedirectToAction("Login");
        }
    }
}
