using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        [Display(Name = "Class Name")]
        public string Name { get; set; }

        public virtual List<Lesson> Lessons { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<Servant> Servants { get; set; }
    }
}