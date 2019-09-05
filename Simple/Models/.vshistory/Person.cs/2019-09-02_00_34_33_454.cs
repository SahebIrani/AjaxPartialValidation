using System.ComponentModel.DataAnnotations;

namespace Simple.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0} Khaliye ..")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} Khaliye ..")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} Khaliye ..")]
        [EmailAddress(ErrorMessage = "{0} Valid Nist ..")]
        public string Email { get; set; }
    }
}
