using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace AgiltProjektarbete
{
    public class CartController : Controller
    {
        private readonly ApplicationContext context;
        public CartController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<OrderItems>(HttpContext.Session, "cart");
            return View(cart);
        }

        public IActionResult Buy([FromBody]FetchBuyModel model)
        {
            if (model.Id == null || model.RestaurantId == null)
            {            
                return Json(new {StatusCode = 400, Content = "Id is null"});
            }
            else
            {
                if (SessionHelper.GetObjectFromJson<OrderItems>(HttpContext.Session, "cart") == null)
                {
                    var cart = new OrderItems();
                    cart.Restaurant = context.Restaurants.Single(o => o.Id == model.RestaurantId);
                    cart.Pizzas.Add(context.Pizzas.Single(o => o.Id == model.Id));
                    cart.Quantity.Add(context.Pizzas.Single(o => o.Id == model.Id).Id, 1);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                    return Json(new { StatusCode = 200, Content = $"Created cart and added {cart.Pizzas.Last().Name}" });
                }
                else
                {
                    var cart = SessionHelper.GetObjectFromJson<OrderItems>(HttpContext.Session, "cart");
                    string pizzaId = getPizzaIdFromCart(model.Id);
                    if (pizzaId != null)
                    {
                        cart.Quantity[pizzaId]++;
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                        return Json(new { StatusCode = 200, Content = $"Added {cart.Pizzas.First(o => o.Id == pizzaId).Name}" });
                    }
                    else
                    {
                        cart.Pizzas.Add(context.Pizzas.Single(o => o.Id == model.Id));
                        cart.Quantity.Add(context.Pizzas.Single(o => o.Id == model.Id).Id, 1);
                        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                        return Json(new { StatusCode = 200, Content = $"Added {cart.Pizzas.Last().Name}" });
                    }
                }
            }
        }

        public IActionResult Remove(string id)
        {
            var cart = SessionHelper.GetObjectFromJson<OrderItems>(HttpContext.Session, "cart");
            string pizzaId = getPizzaIdFromCart(id);
            cart.Pizzas.Remove(cart.Pizzas.Single(o => o.Id == pizzaId));
            cart.Quantity.Remove(pizzaId);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private string getPizzaIdFromCart(string id)
        {
            OrderItems cart = SessionHelper.GetObjectFromJson<OrderItems>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Pizzas.Count; i++)
            {
                if (cart.Pizzas[i].Id.Equals(id))
                {
                    return cart.Pizzas[i].Id;
                }
            }
            return null;
        }
    }
}