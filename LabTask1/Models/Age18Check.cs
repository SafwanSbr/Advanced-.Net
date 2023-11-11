using System;
using System.ComponentModel.DataAnnotations;

namespace LabTask1.Models
{
    public class Age18Check : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                var today = DateTime.Today;
                var age = today.Year - dateOfBirth.Year;

                // Check if the birthday has occurred this year.
                if (dateOfBirth.Date > today.AddYears(-age))
                {
                    age--;
                }

                if (age < 18)
                {
                    return new ValidationResult("You must be at least 18 years old.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
