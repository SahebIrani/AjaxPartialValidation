using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Simple.Models
{
    public class PersonIValidatable : IValidatableObject
    {
        private const int _birthYear = 1998;

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "{0} Valid Nist ..")]
        public string Email { get; set; }

        //[People(year: 1998)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public bool Preorder { get; set; }

        #region snippet_Validate
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BirthDate.Year > _birthYear)
            {
                yield return new ValidationResult(
                    $"Classic movies must have a release year earlier than {_classicYear}.",
                    new[] { "ReleaseDate" });
            }
        }
    }
}