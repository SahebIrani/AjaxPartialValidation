using Simple.Models;

using System;
using System.ComponentModel.DataAnnotations;

namespace Simple.Attributes
{
    public class PeopleAttribute : ValidationAttribute
    {
        private int _year;
        public PeopleAttribute(int year) => _year = year;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var person = (Person)validationContext.ObjectInstance;
            var releaseYear = ((DateTime)value).Year;

            if (person.Email.StartsWith("Sinjul", StringComparison.OrdinalIgnoreCase) && releaseYear > _year)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public int Year => _year;

        public string GetErrorMessage()
        {
            return $"Classic movies must have a release year no later than {_year}.";
        }
    }
}
