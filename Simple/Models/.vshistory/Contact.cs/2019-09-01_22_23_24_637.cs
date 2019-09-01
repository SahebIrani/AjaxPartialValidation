using System.ComponentModel.DataAnnotations;

namespace Simple.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Khaliye")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Khaliye")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Khaliye")]
        [EmailAddress(ErrorMessage = "Email Valid Nist ..")]
        public string Email { get; set; }
    }
}
