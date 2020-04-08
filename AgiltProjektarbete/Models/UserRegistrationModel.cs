using System.ComponentModel.DataAnnotations;

namespace AgiltProjektarbete
{
    public class UserRegistrationModel
    {
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public Role UserRole { get; set; }
    }
}
