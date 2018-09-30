using OnlineSchool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSchool.ValidationAttributes
{
    public class StudentCodeCheck : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public StudentCodeCheck()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (Student)validationContext.ObjectInstance;

            if (student.Id == 0)
            {
                if ((_context.Servants.Any(s => s.Code == student.Code) || _context.Students.Any(s => s.Code == student.Code)))
                {
                    return new ValidationResult("Card Code already exists.");
                }
            }

            return ValidationResult.Success;
        }
    }
}