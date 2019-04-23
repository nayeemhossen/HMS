using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    [Table("tb_Test")]
    public class Test: BaseModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "Test Name is Mandatory Field")]
        [Display(Name = "Test Name")]
        public string TestName { get; set; }        
    }
    [Table("tb_TestCategory")]
    public class Category : BaseModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Category is Mandatory Field")]
        [Display(Name = "Test Category")]
        public string CategoryName { get; set; }
    }
}
