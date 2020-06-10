using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace AgiltProjektarbete.Controllers
{
    public class ApiController : Controller
    {
        private readonly ApplicationContext context;

        public ApiController(ApplicationContext context)
        {
            this.context = context;
        }

        [Route("{controller}/pizzas/{id}")]
        [HttpGet]
        public ActionResult Pizzas(string id)
        {
            var orders = context.Orders.Where(o => o.Customer.Id == id).ToList();
            var pizzas = new List<Pizza>();
            foreach (var order in orders)
            {
                pizzas.AddRange(context.Pizzas.Where(o => o.OrderId == order.Id).ToList());
            }
            return Json(pizzas.GroupBy(p => p.Name).Select(p => new GoogleChartParsed { Key = p.Key, Value = p.Count() }).ToList());    
        }

        [Route("{controller}/soldpizzas/{id}")]
        [HttpGet]
        public ActionResult SoldPizzas(string id)
        {
            var orders = context.Orders.Where(o => o.Restaurant.Id == id).ToList();
            var pizzas = new List<Pizza>();
            foreach (var order in orders)
            {
                pizzas.AddRange(context.Pizzas.Where(o => o.OrderId == order.Id).ToList());
            }
            return Json(pizzas.GroupBy(p => p.Name).Select(p => new GoogleChartParsed { Key = p.Key, Value = p.Count() }).ToList());
        }
    }
}