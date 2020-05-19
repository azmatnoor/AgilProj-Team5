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
            return View();
        }

        public IActionResult ConfirmOrder()
        {
            var cart = SessionHelper.GetObjectFromJson<OrderItems>(HttpContext.Session, "cart");
            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                Customer = userManager.GetUserAsync(User).Result,
                Pizzas = cart.Pizzas,
                Restaurant = cart.Restaurant,
                totalPrice = cart.Pizzas.Sum(p => p.Price),
                Status = "Waiting for confirmation"
            };
            return View(order);
        }

        public IActionResult AddOrder(OrderItems model)
        {
            return RedirectToAction("Index");
        }
    }
}