using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital_Management_System;
using Hospital_Management_System.Customize_Function;

namespace Hospital_Management_System.Models
{
    public class TestsController : Controller
    {
        private HospitalManagementSystemDBContex db = new HospitalManagementSystemDBContex();
        // GET: Tests
        public ActionResult Index()
        {
            var tests = db.Tests.Include(t => t.Category);
            return View(tests.OrderByDescending(p => p.ID).ToList());
        }
        // GET: Tests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }
        // GET: Tests/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "CategoryName");
            return View();
        }
        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Test test)
        {
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "CategoryName", test.CategoryId);
            return View(test);
        }
        // GET: Tests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "CategoryName", test.CategoryId);
            return View(test);
        }
        // POST: Tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Test test)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "CategoryName", test.CategoryId);
            return View(test);
        }
        // GET: Tests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }
        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = db.Tests.Find(id);
            db.Tests.Remove(test);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // Category Information Here
        //Category List
        public ActionResult CategoryList()
        {
            return View(db.Categories.OrderByDescending(p => p.ID).ToList());
        }
        // Get:Save Category
        public ActionResult SaveCategory()
        {
            return View();
        }
        // POST:Save Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("CategoryList");
            }

            return View(category);
        }
        // Get: Edit Category
        public ActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        // POST: Edit Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory( Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CategoryList");
            }
            return View(category);
        }
        // GET: Category/Delete/
        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategoryConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }    
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult AppointmentRequest()
        {
            return View();
        }
        public ActionResult AddAppointment()
        {
            ViewBag.PatientName = new SelectList(DropDownHelper.GetPatientName(), "Value", "Text");
            //ViewBag.PatientName = new SelectList(db.Users.Where(x => x.UserType == 3).Select(x => x.Name));         
            ViewBag.DoctorName = new SelectList(DropDownHelper.GetDoctorName(), "Value", "Text");           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAppointment(Appoinment appoinment)
        {
            if (ModelState.IsValid)
            {
                //int patientID = ;
                //appoinment.DoctorID =patientID ;
                db.Appoinments.Add(appoinment);
                db.SaveChanges();
                return RedirectToAction("AppoinmentList");
            }
            ViewBag.PatientName = new SelectList(DropDownHelper.GetPatientName(), "Value", "Text");    
            ViewBag.DoctorName = new SelectList(DropDownHelper.GetDoctorName(), "Value", "Text");
            return View(appoinment);
        }
        public ActionResult AppoinmentList()
        {
            //var appoinmentList = db.Appoinments.Include(a=>a.User);
            return View(db.Appoinments.OrderByDescending(p => p.ID).ToList());
           // var tests = db.Tests.Include(t => t.Category);
           //return View(tests.OrderByDescending(p => p.ID).ToList());
        }
    }
}
