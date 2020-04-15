using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgiltProjektarbete
{
    //ADD ONLY ACCESS TO OWNERS AFTER/IN MERGE
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Restaurant restaurant = new Restaurant();
            try
            {
                restaurant = context.Restaurants.Where(o => o.Owner.Id == userManager.GetUserAsync(User).Result.Id).First();
            }
            catch (Exception)
            {
            }
            return View(restaurant);
        }

        [HttpGet]
        public async Task<IActionResult> EditMenu()
        {
            var model = new EditMenuModel();
            model.Restaurant = context.Restaurants.Where(o => o.Owner.Id == userManager.GetUserAsync(User).Result.Id).First();
            model.CurrentMenu = context.Pizzas.Where(o => o.RestaurantId == model.Restaurant.Id).ToList();

            if(model.Restaurant != null)
            {
                return View(model);
            } else
            {
                return RedirectToAction("AddRestaurant");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPizza(EditMenuModel model)
        {
            if(model.Pizza != null)
            {
                var pizza = model.Pizza;
                pizza.Id = Guid.NewGuid().ToString();
                pizza.RestaurantId = context.Restaurants.Where(o => o.Owner.Id == userManager.GetUserAsync(User).Result.Id).First().Id;

                if(context.Pizzas.Where(o => o.RestaurantId == pizza.RestaurantId && o.Name == pizza.Name).Count() < 1)
                {
                    context.Pizzas.Add(pizza);
                    await context.SaveChangesAsync();
                } else
                {
                    ModelState.AddModelError("1337", "A pizza with that name already exists.");
                }
            } else
            {
                ModelState.AddModelError("800815", "You need to add something.");
            }

            return RedirectToAction("EditMenu");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePizza(string id)
        {
            if(id != null)
            {
                var user = userManager.GetUserAsync(User).Result;
                var restaurant = context.Restaurants.Where(o => o.Owner.Id == user.Id).First();
                context.Pizzas.Remove(context.Pizzas.Where(o => o.RestaurantId == restaurant.Id && o.Id == id).First());
                await context.SaveChangesAsync();
            }

            return RedirectToAction("EditMenu");
        }

        [HttpGet]
        public IActionResult AddRestaurant()
        {
            if (context.Restaurants.Where(o => o.Owner.Id == userManager.GetUserAsync(User).Result.Id).Count() < 1)
            {
                return View();
            }
            else
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