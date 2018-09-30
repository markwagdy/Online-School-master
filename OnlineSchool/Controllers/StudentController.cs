using iTextSharp.text;
using iTextSharp.text.pdf;
using OnlineSchool.Models;
using OnlineSchool.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Image = OnlineSchool.Models.Image;

namespace OnlineSchool.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _context;

        public StudentController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Student
        [HttpGet]
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            var students = _context.Students.Include(s => s.Priest).ToList();
            return View("Index", students);
        }

        [Authorize(Roles = "Admins")]
        public ActionResult New()
        {

            var studentViewModel = new StudentViewModel
            {
                Student = new Student(),
                Priests = _context.Priests.ToList(),
                Churches = _context.Churches.ToList(),

            };

            return View("New", studentViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public ActionResult Save(StudentViewModel studentViewModel,Image image, HttpPostedFileBase file)
        {
            studentViewModel.Priests = _context.Priests.ToList();
            studentViewModel.Churches = _context.Churches.ToList();


            if (!ModelState.IsValid)
            {
                return View("New", studentViewModel);
            }


            if (studentViewModel.Student.Id == 0)
            {

            if (file != null)
            {
                file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);
                image.ImagePath = file.FileName;
                studentViewModel.Student.StudentCard = image;
            }
            _context.Images.Add(image);

                var newStudent = new Student
                {
                    Code = studentViewModel.Student.Code,
                    Name = studentViewModel.Student.Name,
                    Email = studentViewModel.Student.Email,
                    BirtDate = studentViewModel.Student.BirtDate,
                    Gender = studentViewModel.Student.Gender,
                    AcademicYear = studentViewModel.Student.AcademicYear,
                    MobileNumber = studentViewModel.Student.MobileNumber,
                    HomeNumber = studentViewModel.Student.HomeNumber,
                    Address = studentViewModel.Student.Address,
                    MaritalStatus = studentViewModel.Student.MaritalStatus,
                    Job = studentViewModel.Student.Job,
                    FatherPhone = studentViewModel.Student.FatherPhone,
                    MotherPhone = studentViewModel.Student.MotherPhone,
                    MotherName = studentViewModel.Student.MotherName,
                    PriestId = studentViewModel.Student.PriestId,
                    ChurchId = studentViewModel.Student.ChurchId,
                    StudentCard = studentViewModel.Student.StudentCard,
                    DeaconshipHistories = new List<DeaconshipHistory>()

                };

                if (studentViewModel.DeaconshipHistory.Rank != null)
                {
                    newStudent.IsDeacon = true;
                    studentViewModel.DeaconshipHistory.UserCode = studentViewModel.Student.Code;
                    newStudent.DeaconshipHistories.Add(studentViewModel.DeaconshipHistory);

                    _context.DeaconshipHistories.Add(studentViewModel.DeaconshipHistory);



                }

                _context.Students.Add(newStudent);


            }
            else
            {
                var existingStudent = _context.Students.Include(s => s.StudentCard).SingleOrDefault(c => c.Id == studentViewModel.Student.Id);

                
                //Image Error when editing
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);
                    image.ImagePath = file.FileName;

                    if(existingStudent.StudentCard != null)
                    _context.Images.Remove(existingStudent.StudentCard);

                    studentViewModel.Student.StudentCard = image;
                    _context.Images.Add(image);
                }

                existingStudent.Code = studentViewModel.Student.Code;
                existingStudent.Name = studentViewModel.Student.Name;
                existingStudent.Email = studentViewModel.Student.Email;
                existingStudent.BirtDate = studentViewModel.Student.BirtDate;
                existingStudent.Gender = studentViewModel.Student.Gender;
                existingStudent.AcademicYear = studentViewModel.Student.AcademicYear;
                existingStudent.MobileNumber = studentViewModel.Student.MobileNumber;
                existingStudent.HomeNumber = studentViewModel.Student.HomeNumber;
                existingStudent.Address = studentViewModel.Student.Address;
                existingStudent.MaritalStatus = studentViewModel.Student.MaritalStatus;
                existingStudent.Job = studentViewModel.Student.Job;
                existingStudent.FatherPhone = studentViewModel.Student.FatherPhone;
                existingStudent.MotherPhone = studentViewModel.Student.MotherPhone;
                existingStudent.MotherName = studentViewModel.Student.MotherName;
                existingStudent.PriestId = studentViewModel.Student.PriestId;
                existingStudent.ChurchId = studentViewModel.Student.ChurchId;
                existingStudent.StudentCard = studentViewModel.Student.StudentCard;
                //existingStudent.Deacon = studentViewModel.Student.Deacon;


            }


            _context.SaveChanges();

            return RedirectToAction("Index");


        }

        [Authorize(Roles = "Admins")]
        public ActionResult Edit(int id)
        {


            var studentViewModel = new StudentViewModel
            {
                Student = new Student(),
                Priests = _context.Priests.ToList(),
                Churches = _context.Churches.ToList(),

            };

            studentViewModel.Student = _context.Students.Include(s => s.Priest)
                                                        .Include(s => s.StudentCard).SingleOrDefault(c => c.Id == id);

            if (studentViewModel == null)
                return HttpNotFound();




            return View("New", studentViewModel);



        }

        [Authorize(Roles = "Admins")]
        public ActionResult Delete(int id)
        {
            var studentViewModel = new StudentViewModel
            {
                Student = new Student(),
                Priests = _context.Priests.ToList(),
                Churches = _context.Churches.ToList(),
                DeaconshipHistory = new DeaconshipHistory()
            };

            studentViewModel.Student = _context.Students.Include(s=>s.StudentCard).SingleOrDefault(c => c.Id == id);
            studentViewModel.DeaconshipHistory = _context.DeaconshipHistories.SingleOrDefault(c => c.UserCode == studentViewModel.Student.Code);

            if (studentViewModel == null)
                return HttpNotFound();

            _context.Students.Remove(studentViewModel.Student);

            //Removing the Deaconship history from the database
            if (studentViewModel.DeaconshipHistory != null)
                _context.DeaconshipHistories.Remove(studentViewModel.DeaconshipHistory);

            if (studentViewModel.Student.StudentCard != null)
                _context.Images.Remove(studentViewModel.Student.StudentCard);

            _context.SaveChanges();


            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admins")]
        public ActionResult Details(int id)
        {
            var student = _context.Students.Include(s=> s.DeaconshipHistories)
                                           .Include(s => s.StudentCard).SingleOrDefault(c => c.Id == id);

           
            student.Priest = _context.Priests.SingleOrDefault(p => p.Id == student.PriestId);
            student.Church = _context.Churches.SingleOrDefault(p => p.Id == student.ChurchId);


            return View("Details", student);
        }

        [HttpPost]
        [Authorize(Roles = "Admins")]
        public void Print()
        {
            

        }

    }
    }
