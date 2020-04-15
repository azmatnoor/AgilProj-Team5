using System.ComponentModel.DataAnnotations;

namespace AgiltProjektarbete
{
    public class UserLoginModel
    {
        [Display(Name = "E-mail")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
