using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models
{
    public class LessonType
    {
        public int Id { get; set; }
        [Display(Name ="Type")]
        public string Name { get; set; }

    }
}