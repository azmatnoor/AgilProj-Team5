using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AgiltProjektarbete
{
    public class User : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
    }
}
