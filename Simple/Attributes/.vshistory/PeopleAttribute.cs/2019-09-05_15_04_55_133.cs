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

            return person.Email.StartsWith("Sinjul", StringComparison.OrdinalIgnoreCase) && releaseYear > _year
                ? new ValidationResult(GetErrorMessage())
                : ValidationResult.Success;
        }

        public int Year => _year;

        public string GetErrorMessage()
        {
            return $"Classic movies must have a release year no later than {_year}.";
        }
    }
}
