using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_Management_System.Models
{
    [Table("tb_User")]
    public class User : BaseModel
    {
        [Key]
        public int ID { get; set; }
        public int CoreID { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Person ID")]
        public string AutoGenarateID { get; set; }
        [Required(ErrorMessage = "Name is Mandatory Field")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is Mandatory Field")]
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please Select a Gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name = "National ID No.")]
        [Remote("IsUniqueName", "User", ErrorMessage = "National ID No. already exists!")]
        public long NationalID { get; set; }
        [Required(ErrorMessage = "Address is Mandatory Field")]
        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "User-Name is Mandatory Field")]
        [Display(Name = "User Name")]
        [Remote("IsUniqueName", "User", ErrorMessage = "User Name already exists!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Mandatory Field")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Phone Number is Mandatory Field")]
        [Display(Name = "Phone")]
        [Remote("IsUniqueName", "User", ErrorMessage = "Phone Number already exists!")]
        public string Phone { get; set; }
        [Display(Name = "User Type")]
        public int UserType { get; set; }
    }

}