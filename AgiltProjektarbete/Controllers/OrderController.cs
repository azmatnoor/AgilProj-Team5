using System;
using System.Linq;
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

        [HttpGet]
        public IActionResult Index([FromRoute]string id)
        {
            return View(context.Orders.Single(o => o.Id == id).DeliveryTime);
        }

        public IActionResult ConfirmOrder()
        {
            var cart = SessionHelper.GetObjectFromJson<OrderItems>(HttpContext.Session, "cart");
            var restaurant = context.Restaurants.Single(o => o.Id == cart.Restaurant.Id);
            var id = Guid.NewGuid().ToString();
            foreach (var pizza in cart.Pizzas)
            {
                pizza.OrderId = id;
            }
            restaurant.Orders.Add(new Order
            {
                Id = id,
                Customer = userManager.GetUserAsync(User).Result,
                Pizzas = cart.Pizzas,
                totalPrice = cart.Pizzas.Sum(p => p.Price),
                DeliveryTime = DateTime.Now.AddMinutes(25),
                Status = "Confirmed"
            });
            context.SaveChanges();
            var order = context.Orders.Single(o => o.Id == id);
            return View(order);
        }
    }
}