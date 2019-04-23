using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class BaseModel
    {
        public int InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    //public class Person
    //{
    //    [Required]
    //    [Display(Name = "Full Name")]
    //    public string DoctorsFullName { get; set; }
    //    [Required]
    //    [Display(Name = "Gender")]
    //    public string Gender { get; set; }
    //    [Required]
    //    [Display(Name = "Age")]
    //    public int Age { get; set; }
    //    [Required]
    //    [Display(Name = "National ID No.")]
    //    public int NationalID { get; set; }
    //    [Required]
    //    [Display(Name = "Address")]
    //    public string Address { get; set; }
    //    [Required]
    //    [Display(Name = "Phone")]
    //    public int Phone { get; set; }
    //}
}