using System.ComponentModel.DataAnnotations;

namespace Simple.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "خالیه"), StringLength(3, ErrorMessage = "بین 3 تا 50", MinimumLength = 50]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}