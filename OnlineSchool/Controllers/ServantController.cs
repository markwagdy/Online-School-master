using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSchool.Controllers
{
    public class ServantController : Controller
    {

        private ApplicationDbContext _context;

        public ServantController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Servant
        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            var servants = _context.Servants.ToList();
            return View("Index", servants);
        }

        [Authorize(Roles = "Admins")]
        public ActionResult New()
        {

            var servant = new Servant();
            return View("New", servant);
        }


        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult Save(Servant servant)
        {


            if (!ModelState.IsValid)
            {
                return View("New", servant);
            }



            if (servant.Id == 0)
            {

                var newServant = new Servant
                {
                    Code = servant.Code,
                    Name = servant.Name,
                    Email = servant.Email,





            };
                    var User = _context.Users.SingleOrDefault(u => u.Email == servant.Email);
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
                    UserManager.AddToRole(User.Id, "Admins");

                _context.Servants.Add(newServant);


            }
            else
            {
                var existingServant = _context.Servants.SingleOrDefault(c => c.Id == servant.Id);

                existingServant.Code = servant.Code;
                existingServant.Name = servant.Name;
                existingServant.Email = servant.Email;


            }


            _context.SaveChanges();

            return RedirectToAction("Index");


        }

        [Authorize(Roles = "Admins")]
        public ActionResult Edit(int id)
        {


            var servant = new Servant();
           

            servant = _context.Servants.SingleOrDefault(c => c.Id == id);

            if (servant == null)
                return HttpNotFound();




            return View("New", servant);



        }

        [Authorize(Roles = "Admins")]
        public ActionResult Delete(int id)
        {
            var servant = new Servant();
           

            servant = _context.Servants.SingleOrDefault(c => c.Id == id);

            var User = _context.Users.SingleOrDefault(u => u.Email == servant.Email);
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            UserManager.RemoveFromRole(User.Id, "Admins");

            if (servant == null)
                return HttpNotFound();
            _context.Servants.Remove(servant);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admins")]
        public ActionResult Details(int id)
        {
            var servant = _context.Servants.SingleOrDefault(c => c.Id == id);

           

            return View("Details", servant);
        }
    }
}