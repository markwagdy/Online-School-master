using OnlineSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSchool.Controllers
{
    public class PriestController : Controller
    {
        private ApplicationDbContext _context;

        public PriestController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Priest
        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            var priests = _context.Priests.ToList();
            
            return View("Index", priests);
        }


        [Authorize(Roles = "Admins")]
        public ActionResult New()
        {

            var priest = new Priest();
           

            return View("New", priest);
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult Save(Priest priest)
        {
            var priestChurch = _context.Churches.SingleOrDefault(c => c.Name == priest.Church.Name);


            if (!ModelState.IsValid)
            {
                return View("New", priest);
            }



            if (priest.Id == 0)
            {

                var newPriest = new Priest
                {
                    Name = priest.Name,
                    MobileNumber = priest.MobileNumber,
                    OfficeNumber = priest.OfficeNumber,
                    Church = priestChurch




                };
                _context.Priests.Add(newPriest);


            }
            else
            {
                var existingPriest = _context.Priests.SingleOrDefault(c => c.Id == priest.Id);

                existingPriest.Name = priest.Name;
                existingPriest.MobileNumber = priest.MobileNumber;
                existingPriest.OfficeNumber = priest.OfficeNumber;
                existingPriest.Church = priestChurch;


            }


            _context.SaveChanges();

            return RedirectToAction("Index");


        }

        [Authorize(Roles = "Admins")]
        public ActionResult Edit(int id)
        {


            var priest = new Priest();
           

            priest = _context.Priests.SingleOrDefault(c => c.Id == id);

            if (priest == null)
                return HttpNotFound();




            return View("New", priest);



        }



        [Authorize(Roles = "Admins")]
        public ActionResult Delete(int id)
        {
            var priest = new Priest();
            

            priest= _context.Priests.SingleOrDefault(c => c.Id == id);

            if (priest == null)
                return HttpNotFound();

            _context.Priests.Remove(priest);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admins")]
        public ActionResult Details(int id)
        {
            var priest = _context.Priests.SingleOrDefault(c => c.Id == id);

            priest.Church = _context.Churches.SingleOrDefault(p => p.Id == priest.Church.Id);



            return View("Details", priest);
        }
    }
}