using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgiltProjektarbete.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationContext context;
        private readonly UserManager<User> userManager;
        public ProfileController(ApplicationContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(userManager.GetUserAsync(User).Result);
        }
    }
}