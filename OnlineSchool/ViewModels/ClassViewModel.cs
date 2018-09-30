using OnlineSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSchool.ViewModels
{
    public class ClassViewModel
    {
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }

        public IEnumerable<MultiSelectList> Lessons { get; set; }
        public IEnumerable<SelectListItem> Students { set; get; } 
        public string[] SelectedStudents { set; get; }
        public IEnumerable<MultiSelectList> Servants { get; set; }
    }
}