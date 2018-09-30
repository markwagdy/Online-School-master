using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models
{
    public class Priest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Priest Name")]
        public string Name { get; set; }

        [Display(Name = "Office Number")]
        public string OfficeNumber { get; set; }
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        public virtual Church Church { get; set; }


    }
}