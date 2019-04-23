using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital_Management_System;
using Hospital_Management_System.Models;
using Hospital_Management_System.Customize_Function;

namespace Hospital_Management_System.Controllers
{
    public class UsersController : Controller
    {
        private HospitalManagementSystemDBContex db = new HospitalManagementSystemDBContex();
        // GET: Users
        public ActionResult Index()
        {
            //var users = db.Users.Include(u => u.Gender);
            return View(db.Users.OrderByDescending(p => p.ID).ToList());
        }
        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        // GET: Users/Create/Management
        public ActionResult Management()
        {            
            ViewBag.Gender = new SelectList(DropDownHelper.GetGenders(), "Value", "Text");
            return View();
        }
        // POST: Users/Create/Management
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Management(User user)
        {
            if (ModelState.IsValid)
            {
                int userType = 1;
                AutoIdentity identity = new AutoIdentity();

                user.CoreID = identity.LastId(2);
                user.Date = DateTime.Today;
                user.AutoGenarateID = "E/" + identity.AutoIdGenerator(1);
                user.UserType = userType;
                user.UpdateDate = DateTime.Now;
                user.InsertDate = user.Date;

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gender = new SelectList(DropDownHelper.GetGenders(), "Value", "Text");
            return View(user);
        }
        // GET: Users/Create/Doctor
        public ActionResult Doctor()
        {
            ViewBag.Gender = new SelectList(DropDownHelper.GetGenders(), "Value", "Text");
            return View();
        }
        // POST: Users/Create/Doctor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Doctor(User user)
        {
            if (ModelState.IsValid)
            {
                int userType = 2;
                user.Name ="Dr. "+user.Name;
                AutoIdentity identity = new AutoIdentity();
                user.CoreID = identity.LastId(2);
                user.Date = DateTime.Today;
                user.AutoGenarateID = "D/" + identity.AutoIdGenerator(2);
                user.UserType = userType;
                user.UpdateDate = DateTime.Now;
                user.InsertDate = user.Date;

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gender = new SelectList(DropDownHelper.GetGenders(), "Value", "Text");
            return View(user);
        }
        // GET: Users/Create/Patient
        public ActionResult Patient()
        {
            ViewBag.Gender = new SelectList(DropDownHelper.GetGenders(), "Value", "Text");
            return View();
        }
        // POST: Users/Create/Patient
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Patient(User user)
        {
            if (ModelState.IsValid)
            {
                int userType = 3;               
                AutoIdentity identity = new AutoIdentity();
                user.CoreID = identity.LastId(3);
                user.Date = DateTime.Today;
                user.AutoGenarateID = "P/"+identity.AutoIdGenerator(3);
                user.UserType = userType;
                user.UpdateDate = DateTime.Now;
                user.InsertDate = user.Date;

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gender = new SelectList(DropDownHelper.GetGenders(), "Value", "Text");
            return View(user);
        }
        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.Gender = new SelectList(DropDownHelper.GetGenders(), "Value", "Text", user.Gender);
            return View(user);
        }
        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                //article.UpdatedBy = MyHelpers.SessionBag.Current.SamAccountName;
                user.UpdateDate = DateTime.Now;                 
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gender = new SelectList(DropDownHelper.GetGenders(), "Value", "Text", user.Gender);
            return View(user);
        }
        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]//Why we use ActionName??
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        // GET: Patient's/Details/7        
        public ActionResult PatientDetails()
        {
            //Catch UserId From Cookie
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie = HttpContext.Request.Cookies.Get("UserId");
            if (cookie == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(cookie);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }
}
