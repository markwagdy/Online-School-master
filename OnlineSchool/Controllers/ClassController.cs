using OnlineSchool.Models;
using OnlineSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSchool.Controllers
{
    public class ClassController : Controller
    {
        private ApplicationDbContext _context;

        public ClassController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Church
        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            var classes = _context.Classes.ToList();
            return View("Index", classes);

        }

        
        [Authorize(Roles = "Admins")]
        public ActionResult New()
        {

            var classViewModel = new ClassViewModel();

            var studentslist = _context.Students.Select(s => s.Name).ToList();
            classViewModel.Students = new SelectList(studentslist);
            return View("New", classViewModel);
        }



    }
}