using System.ComponentModel.DataAnnotations;

namespace Simple.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "خالیه")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "خالیه")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "خالیه")]
        [EmailAddress(ErrorMessage = "ایمیل نامعتبر")]
        public string Email { get; set; }
    }
}
