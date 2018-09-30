using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using OnlineSchool.ValidationAttributes;

namespace OnlineSchool.Models
{
    public class Servant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Card Code")]
        [ServantCodeCheck]
        public string Code { get; set; }
        
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public virtual Class Class { get; set; }
        

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}