using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using StarSecurityServices.Helpers;
using StarSecurityServices.Models;

namespace StarSecurityServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
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

            var f_password = GetMD5(password);
            var data = _db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
            if (data.Count() > 0)
            {
                  
                Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                Session["Email"] = data.FirstOrDefault().Email;
                Session["idUser"] = data.FirstOrDefault().idUser;
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
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }


    }
}
