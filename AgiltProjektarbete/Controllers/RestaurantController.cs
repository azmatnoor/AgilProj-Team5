using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgiltProjektarbete.Controllers
{
    [Authorize]
    public class RestaurantController : Controller
    {
        private ApplicationContext context;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public RestaurantController(ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddRestaurant()
        {
            if(context.Restaurants.Where(o => o.Owner.Id == userManager.GetUserAsync(User).Result.Id).Count() < 1)
            {
                return View();
            } else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRestaurant(RestaurantRegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string guid = Guid.NewGuid().ToString("D");
            var restaurant = new Restaurant
            {
                Id = guid,
                Name = model.Name,
                Owner = await userManager.GetUserAsync(User),
                PricePerKilometer = model.PricePerKilometer,
                ZIPCode = int.Parse(model.ZIPCode)
            };

            await context.Restaurants.AddAsync(restaurant);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}