using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace Hospital_Management_System.Customize_Function
{
    public class DropDownHelper
    {
        private HospitalManagementSystemDBContex db = new HospitalManagementSystemDBContex();
        public static IList<SelectListItem> GetGenders()
        {
            IList<SelectListItem> result = new List<SelectListItem>();
            result.Add(new SelectListItem { Value = "Male", Text = "Male" });
            result.Add(new SelectListItem { Value = "Female", Text = "Female" });
            result.Add(new SelectListItem { Value = "Other", Text = "Other" });
            return result;
        }
        //public static IList<SelectListItem> GetCategory()
        //{
        //    IList<SelectListItem> result = new List<SelectListItem>();
        //    result.Add(new SelectListItem { Value = "1", Text = "Blood Test" });
        //    result.Add(new SelectListItem { Value = "2", Text = "X-Ray" });
        //    result.Add(new SelectListItem { Value = "3", Text = "Other" });
        //    return result;
        //}
        public static IList<SelectListItem> GetPatientName()
        {
            IList<SelectListItem> result = new List<SelectListItem>();
            using (var db = new HospitalManagementSystemDBContex())
            {
                var patientName = db.Users.Where(x=>x.UserType==3).ToList();
                foreach (var patient in patientName)
                {
                    result.Add(new SelectListItem { Value = patient.ID.ToString(), Text = patient.Name });
                }
            }
            return result;
        }
        public static IList<SelectListItem> GetDoctorName()
        {
            IList<SelectListItem> result = new List<SelectListItem>();
            using (var db = new HospitalManagementSystemDBContex())
            {
                var doctorName = db.Users.Where(x => x.UserType == 2).ToList();
                foreach (var doctor in doctorName)
                {
                    result.Add(new SelectListItem { Value = doctor.ID.ToString(), Text = doctor.Name });
                }
            }
            return result;
        }
    }
}