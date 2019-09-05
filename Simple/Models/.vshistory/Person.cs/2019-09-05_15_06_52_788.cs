using Simple.Attributes;

using System;
using System.ComponentModel.DataAnnotations;

namespace Simple.Models
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "{0} Valid Nist ..")]
        public string Email { get; set; }

        [People(year: 1370)]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
