using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models
{
    public class DeaconshipHistory
    {
        public int Id { get; set; }

        [Display(Name ="Rotba")]
        public string Rank { get; set; }
        [Display(Name = "El esm fi el reshama")]
        public string AssignName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Tare5 el reshama")]
        public DateTime? AssignTime { get; set; }

        [Display(Name = "Makan el reshama")]
        public string AssignPlace { get; set; }

        public string Bishop { get; set; }

        public string UserCode { get; set; } //Use this to link to Student/Servant

    }
}