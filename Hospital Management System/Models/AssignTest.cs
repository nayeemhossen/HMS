using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    [Table("tb_AssignTest")]
    public class AssignTest : BaseModel
    {
        [Key]
        public int ID { get; set; }

        //[Required(ErrorMessage = "Please Select a Doctors")]
        //[Display(Name = "Doctors Name")]
        //public int UserID { get; set; }
        [Required(ErrorMessage = "Must be select one")]
        [Display(Name = "Name")]
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }



        [Required(ErrorMessage = "Please Select a Test")]
        [Display(Name = "Test Name")]
        public int TestID { get; set; }
        [ForeignKey("TestID")]
        public virtual Test Test { get; set; }
    }
}
