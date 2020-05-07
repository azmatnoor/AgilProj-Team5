using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgiltProjektarbete
{
    public class RestaurantController : Controller
    {
        private ApplicationContext context;
        private UserManager<User> userManager;

        public RestaurantController(ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromRoute]string id)
        {
            var restaurant = new Restaurant();
            if(id != null)
            {
                restaurant = context.Restaurants.Where(r => r.Id == id).Single();
            } else
            {
                restaurant = context.Restaurants.Where(o => o.Owner.Id == userManager.GetUserAsync(User).Result.Id).Single();
            }

            restaurant.Menu = await context.Pizzas.Where(p => p.RestaurantId == restaurant.Id && p.InMenu == true).ToListAsync();
            restaurant.Ingredients = await context.Ingredients.Where(p => p.RestaurantId == restaurant.Id).ToListAsync();
            return View(restaurant);
        }

        [Authorize(Roles="RestaurantOwner")]
        [HttpGet]
        public async Task<IActionResult> EditMenu()
        {
            var model = new CreateMenuModel();
            model.Restaurant = context.Restaurants.Where(o => o.Owner.Id == userManager.GetUserAsync(User).Result.Id).First();
            model.CurrentMenu = context.Pizzas.Where(o => o.RestaurantId == model.Restaurant.Id).ToList();
            model.CurrentIngredients = context.Ingredients.Where(o => o.RestaurantId == model.Restaurant.Id).ToList();

            if (model.Restaurant != null)
            {
                return View(model);
            } else
            {
                return RedirectToAction("AddRestaurant");
            }
        }

        [Authorize(Roles = "RestaurantOwner")]
        [HttpPost]
        public async Task<IActionResult> AddPizza(CreateMenuModel model)
        {
            if(model.Pizza != null)
            {
                var pizza = model.Pizza;
                pizza.Id = Guid.NewGuid().ToString();
                pizza.RestaurantId = context.Restaurants.Where(o => o.Owner.Id == userManager.GetUserAsync(User).Result.Id).First().Id;
                pizza.InMenu = true;
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

        [Authorize(Roles = "RestaurantOwner")]
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

        [Authorize(Roles = "RestaurantOwner")]
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

        [Authorize(Roles = "RestaurantOwner")]
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
                Address = model.Address,
                Phone = model.Phone,
                Owner = await userManager.GetUserAsync(User),
                PricePerKilometer = model.PricePerKilometer,
                ZIPCode = int.Parse(model.ZIPCode)
            };

            await context.Restaurants.AddAsync(restaurant);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "RestaurantOwner")]
        [HttpPost]
        public async Task<IActionResult> UpdateRestaurantInfo(Restaurant restaurant)
        {
            restaurant.Id = context.Restaurants.AsNoTracking().Where(x => x.Owner.Id == userManager.GetUserAsync(User).Result.Id).First().Id;
            context.Restaurants.Update(restaurant);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "RestaurantOwner")]
        [HttpPost]
        public async Task<IActionResult> AddIngredients(CreateMenuModel model)
        {
            if (model.Ingredient != null)
            {
                var ingredient = model.Ingredient;
                ingredient.Id = Guid.NewGuid().ToString();
                ingredient.RestaurantId = context.Restaurants.Where(o => o.Owner.Id == userManager.GetUserAsync(User).Result.Id).First().Id;
                ingredient.InMenu = true;
                if (context.Ingredients.Where(o => o.RestaurantId == ingredient.RestaurantId).Count() < 1)
                {
                    context.Ingredients.Add(ingredient);
                    await context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("1337", "A ingredient with that name already exists.");
                }
            }
            else
            {
                ModelState.AddModelError("800815", "You need to add something.");
            }

            return RedirectToAction("EditMenu");
        }
    }
}