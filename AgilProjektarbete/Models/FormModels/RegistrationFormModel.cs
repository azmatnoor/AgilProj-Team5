using System.ComponentModel.DataAnnotations;

namespace AgilProjektarbete
{
    public class RegistrationFormModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}