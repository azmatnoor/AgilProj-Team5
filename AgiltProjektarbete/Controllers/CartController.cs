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
            var cart = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart");
            return View(cart);
        }

        public IActionResult Buy(string id)
        {
            if(SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<OrderItem>();
                cart.Add(new OrderItem { Pizza = context.Pizzas.Single(o => o.Id == id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            } else
            {
                var cart = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index != -1)
                {
                    cart[index].Quantity++;
                } else
                {
                    cart.Add(new OrderItem { Pizza = context.Pizzas.Single(o => o.Id == id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<OrderItem> cart = SessionHelper.GetObjectFromJson<List<OrderItem>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Pizza.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}