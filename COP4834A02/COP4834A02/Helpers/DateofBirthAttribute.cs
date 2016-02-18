using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4834A02.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidateBirthDate : ValidationAttribute
    {
        //Validate date exists between today Min = 5 years old Max = 120 years old
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime _birthJoin = Convert.ToDateTime(value);

                if (_birthJoin > DateTime.Now)
                {
                    return new ValidationResult("Birth date can not be greater than current date.");
                }
                else if (_birthJoin.AddYears(5) > DateTime.Now)
                {
                    return new ValidationResult("Birth date must be greater than 5 years from current date.");
                }
                else if (_birthJoin < DateTime.Now.AddYears(-120)) {
                    return new ValidationResult("Birth date must be less than 120 years from current date.");
                }
            }
            return ValidationResult.Success;
        }
    }  
}
