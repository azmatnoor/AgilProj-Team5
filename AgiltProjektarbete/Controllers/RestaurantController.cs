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

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var restaurant = from r in await context.Restaurants.ToListAsync()
                              join user in await context.Users.ToListAsync() on r.Owner.Id equals userManager.GetUserAsync(User).Result.Id
                              where r.Owner.Id == userManager.GetUserAsync(User).Result.Id                             
                              select r;

            if(restaurant.Count() > 0)
            {
                return View(restaurant.First());
            } else
            {
                return RedirectToAction("AddRestaurant");
            }
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
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