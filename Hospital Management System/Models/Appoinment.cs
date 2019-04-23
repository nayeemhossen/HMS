using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    [Table("tb_Appoinment")]
    public class Appoinment : BaseModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Must be select one")]
        [Display(Name = "Patient's Name")]
        public int PatientID { get; set; }
        [Required(ErrorMessage = "Please Select a Doctors")]
        [Display(Name = "Doctor's Name")]
        public int DoctorID { get; set; }
        public virtual User User { get; set; }

        [Display(Name = "Appoinment Date")]
        public DateTime AppoinmentDate { get; set; }
    }
}