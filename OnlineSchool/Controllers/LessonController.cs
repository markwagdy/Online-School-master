using OnlineSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSchool.Controllers
{
    public class LessonController : Controller
    {
        private ApplicationDbContext _context;

        public LessonController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Lesson
        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            var lessons = _context.Lessons.ToList();
            return View("Index", lessons);

        }


        [Authorize(Roles = "Admins")]
        public ActionResult New()
        {

            var lesson = new Lesson();
            return View("New", lesson);
        }

    }
}