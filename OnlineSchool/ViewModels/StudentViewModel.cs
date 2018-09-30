using OnlineSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSchool.ViewModels
{
    public class StudentViewModel
    {
        
        //public IEnumerable<ApplicationUser> User { get; set; }

        public Student Student { get; set; }
        public IEnumerable<Priest> Priests { get; set; }
        public IEnumerable<Church> Churches { get; set; }
        public DeaconshipHistory DeaconshipHistory { get; set; }

    }
}