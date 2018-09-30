using OnlineSchool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineSchool.ValidationAttributes
{
    public class ServantCodeCheck : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public ServantCodeCheck()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var servant = (Servant)validationContext.ObjectInstance;

            if (servant.Id == 0)
            {
                if ((_context.Servants.Any(s => s.Code == servant.Code) || _context.Students.Any(s => s.Code == servant.Code)))
                {
                    return new ValidationResult("Card Code already exists.");
                }
            }

            return ValidationResult.Success;
        }
    }
}