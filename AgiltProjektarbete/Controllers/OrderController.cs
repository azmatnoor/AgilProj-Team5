using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgiltProjektarbete
{
    public class OrderController : Controller
    {
        private readonly ApplicationContext context;
        private readonly UserManager<User> userManager;
        public OrderController(ApplicationContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IActionResult Index(string id)
        {
            return View(DateTime.Now.AddMinutes(2));
        }

        public IActionResult ConfirmOrder()
        {
            var cart = SessionHelper.GetObjectFromJson<OrderItems>(HttpContext.Session, "cart");
            var restaurant = context.Restaurants.Single(o => o.Id == cart.Restaurant.Id);
            var id = Guid.NewGuid().ToString();
            restaurant.Orders.Add(new Order
            {
                Id = id,
                Customer = userManager.GetUserAsync(User).Result,
                Pizzas = cart.Pizzas,
                totalPrice = cart.Pizzas.Sum(p => p.Price),
                Status = "Waiting for confirmation"
            });
            context.SaveChanges();
            var order = context.Orders.Single(o => o.Id == id);
            return View(order);
        }
    }
}