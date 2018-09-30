using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models
{
    public class Church
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Church Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Phone Number (1)")]
        public string PhoneNumber1 { get; set; }

        [Display(Name = "Phone Number (2)")]
        public string PhoneNumber2 { get; set; }

    }
}