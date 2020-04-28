using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgiltProjektarbete.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgiltProjektarbete.Controllers
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

        [NonAction]
        public FetchResult Buy(string id, string restaurantId)
        {
            var fetchResult = new FetchResult();
            if(SessionHelper.GetObjectFromJson<OrderItems>(HttpContext.Session, "cart") == null)
            {
                var cart = new OrderItems();
                cart.RestaurantId = context.Restaurants.Single(o => o.Id == restaurantId).Id;
                cart.Pizzas.Add(context.Pizzas.Single(o => o.Id == id));
                cart.Quantity.Add(context.Pizzas.Single(o => o.Id == id).Id, 1);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                fetchResult.Message = $"Created new cart for {context.Restaurants.Single(o => o.Id == restaurantId).Name} and added {cart.Pizzas.Last().Name} to the cart";
            } else
            {
                var cart = SessionHelper.GetObjectFromJson<OrderItems>(HttpContext.Session, "cart");
                string pizzaId = isExist(id);
                if(pizzaId != null)
                {
                    cart.Quantity[pizzaId]++;
                } else
                {                  
                    cart.Pizzas.Add(context.Pizzas.Single(o => o.Id == id));
                    cart.Quantity.Add(context.Pizzas.Single(o => o.Id == id).Id, 1);
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            fetchResult.Success = true;
            fetchResult.StatusCode = 200;
            return fetchResult;
        }

        public IActionResult Remove(string id)
        {
            var cart = SessionHelper.GetObjectFromJson<OrderItems>(HttpContext.Session, "cart");
            string pizzaId = isExist(id);
            cart.Pizzas.Remove(cart.Pizzas.Single(o => o.Id == pizzaId));
            cart.Quantity[pizzaId] = cart.Quantity[pizzaId] - 1;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private string isExist(string id)
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