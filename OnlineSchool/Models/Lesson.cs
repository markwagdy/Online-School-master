using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineSchool.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual LessonType Type { get; set; }
        public string Level { get; set; }
        public string Year { get; set; }
        public string Term { get; set; }

    }
}