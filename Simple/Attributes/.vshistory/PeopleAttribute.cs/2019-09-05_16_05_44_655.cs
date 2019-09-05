using Simple.Models;

using System;
using System.ComponentModel.DataAnnotations;

namespace Simple.Attributes
{
    public class PeopleAttribute : ValidationAttribute
    {
        public PeopleAttribute(int year) => _year = year;
        private readonly int _year;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _ = (Person)validationContext.ObjectInstance;
            //به خود شخص دسترسی داریم میتونیم رو هر پروپرتی که بخوایم شرط و شروط قرار بدیم ..

            var birthYear = ((DateTime)value).Year;

            return birthYear > Year1 ? new ValidationResult(GetErrorMessage()) : ValidationResult.Success;
        }

        public string GetErrorMessage() => $"birthDate must have a birthYear no later than {Year1} .. !!!!";
    }
}
