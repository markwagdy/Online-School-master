using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using OnlineSchool.ValidationAttributes;

namespace OnlineSchool.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        //Code to sync with cards;
        [Required]
        [StudentCodeCheck]
        [Display(Name = "Card Code")]
        public string Code { get; set; }

        //Personal info:
        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Image StudentCard { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of birth")]
        public DateTime BirtDate { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Academic Year")]
        public string AcademicYear { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required]
        [Display(Name = "Home Number")]
        public string HomeNumber { get; set; }

        [Required]
        public virtual Address Address { get; set; } //zay el software

        [Display(Name = "Marital Status")]
        [Required]
        public string MaritalStatus { get; set; }

        [Required]
        public string Job { get; set; }



        //Parents info:
        [Display(Name = "Father's Phone Number")]
        public string FatherPhone { get; set; }
        [Display(Name = "Mother's Phone Number")]
        public string MotherPhone { get; set; }

        [Display(Name = "Mother's Name")]
        public string MotherName { get; set; }

        //Church info:
        public int PriestId { get; set; }
        public Priest Priest { get; set; }
        public int ChurchId { get; set; }
        public Church Church { get; set; }

        [Display(Name = "Shamas")]
        public bool IsDeacon { get; set; }
        public List<DeaconshipHistory> DeaconshipHistories { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }



    }
}