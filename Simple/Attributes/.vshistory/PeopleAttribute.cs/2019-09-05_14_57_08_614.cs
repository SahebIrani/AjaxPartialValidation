using System;
using System.ComponentModel.DataAnnotations;

namespace Simple.Attributes
{
    // The ClassicMovie attribute is an
    // example that uses an AttributeAdapter to
    // provide client-side validation.

    #region snippet_ClassicMovieAttribute
    public class PeopleAttribute : ValidationAttribute
    {
        private int _year;

        public PeopleAttribute(int year)
        {
            _year = year;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            var releaseYear = ((DateTime)value).Year;

            if (movie.Genre == Genre.Classic && releaseYear > _year)
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
    #endregion
}
