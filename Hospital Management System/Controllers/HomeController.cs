using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private HospitalManagementSystemDBContex db = new HospitalManagementSystemDBContex();

        public ActionResult Index()
        {
            //if (TempData["msg"] !=null) {
            //    string a = TempData["msg"].ToString();
            
            //var userList = db.Tests.OrderByDescending(p => p.ID).ToList();
            //return View();
            //}

            return View();
        }

        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(User user)
        {
            try
            {
                var userCheck = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
                if (userCheck != null)
                {
                    //TempData["msg"] = "Hello! "+ userCheck.Name;
                    HttpCookie cookie = new HttpCookie("UserInfo");
                    cookie.Values.Add("UserId", userCheck.ID.ToString());
                    cookie.Values.Add("UserName", userCheck.Name);
                    cookie.Values.Add("UserType", userCheck.UserType.ToString());
                    HttpContext.Response.Cookies.Add(cookie);
                    Response.Cookies["UserInfo"].Expires = DateTime.Now.AddHours(1);
                    //Response.Cookies["UserInfo"].Expires = DateTime.Now.AddDays(rememberme ? 30 : 1);
                    int id= userCheck.ID;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "UserName and Password Not Macthed. Try again.");
                }
            }

            catch (Exception)
            {
                return View();
            }
            return View();
        }
        public ActionResult About()
        {
            if (Request.Cookies["UserInfo"]?["UserId"] != null)
            {
                ViewBag.Message = "Your About page.";
                return View();
            }
            return RedirectToAction("UserLogin");
        }

        public ActionResult Contact()
        {
            if (Request.Cookies["UserInfo"]?["UserId"] != null)
            {
                ViewBag.Message = "Your contact page.";
                return View();
            }           
                return RedirectToAction("UserLogin");
        }

        public ActionResult Logout()
        {
            var logOut = new HttpCookie("UserInfo");
            logOut.Expires = DateTime.Now.AddHours(-1);
            Response.Cookies.Add(logOut);
            return RedirectToAction("UserLogin");
        }

    }
}