using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Display(Name = "Apartment No.")]
        public string Apartment { get; set; }
        [Display(Name = "Building No.")]
        public string Building { get; set; }
        [Display(Name = "Street Name")]
        public string Street { get; set; }
        [Display(Name = "District Name")]
        public string District { get; set; }

    }
}