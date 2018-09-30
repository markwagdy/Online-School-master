using OnlineSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSchool.Controllers
{
    public class ChurchController : Controller
    {
        private ApplicationDbContext _context;

        public ChurchController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Church
        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            var churches = _context.Churches.ToList();
            return View("Index", churches);

        }

        [Authorize(Roles = "Admins")]
        public ActionResult New()
        {

            var church = new Church();
            return View("New", church);
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult Save(Church church)
        {
            
            if (!ModelState.IsValid)
            {
                return View("New", church);
            }



            if (church.Id == 0)
            {

                var newChurch = new Church
                {
                   Name = church.Name,
                   PhoneNumber1 = church.PhoneNumber1,
                   PhoneNumber2 = church.PhoneNumber2


                };
                _context.Churches.Add(newChurch);


            }
            else
            {
                var existingChurch = _context.Churches.SingleOrDefault(c => c.Id == church.Id);

                existingChurch.Name = church.Name;
                existingChurch.PhoneNumber1 = church.PhoneNumber1;
                existingChurch.PhoneNumber2 = church.PhoneNumber2;


            }


            _context.SaveChanges();

            return RedirectToAction("Index");


        }

        [Authorize(Roles = "Admins")]
        public ActionResult Edit(int id)
        {


            var church = new Church();

            church = _context.Churches.SingleOrDefault(c => c.Id == id);

            if (church == null)
                return HttpNotFound();




            return View("New", church);



        }

        [Authorize(Roles = "Admins")]
        public ActionResult Delete(int id)
        {
            var church = new Church();
            

            church = _context.Churches.SingleOrDefault(c => c.Id == id);

            if (church == null)
                return HttpNotFound();

            _context.Churches.Remove(church);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admins")]
        public ActionResult Details(int id)
        {
            var church = _context.Churches.SingleOrDefault(c => c.Id == id);
            

            return View("Details", church);
        }


    }
}