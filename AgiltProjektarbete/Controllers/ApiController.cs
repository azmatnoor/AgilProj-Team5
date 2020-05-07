using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;

namespace AgiltProjektarbete.Controllers
{
    public class ApiController : Controller
    {
        private readonly ApplicationContext context;
        public ApiController(ApplicationContext context)
        {
            this.context = context;
        }

        //Emil M API
        [Route("{controller}/pizzas/{id}")]
        [HttpGet]
        public IEnumerable<GoogleChartParsed> Pizzas(string id)
        {
            var orders = context.Orders.Where(o => o.Customer.Id == id).ToList();;
            var parsedOrders = new List<GoogleChartParsed>();
            foreach (var order in orders)
            {
                order.Pizzas = context.Pizzas.Where(o => o.OrderId == order.Id).ToList();
                var groupedOrders = order.Pizzas.GroupBy(m => m.Name).Select(m => new GoogleChartParsed { Key = m.Key, Value = m.Count() });
                parsedOrders.AddRange(groupedOrders);
            }
            return parsedOrders.GroupBy(m => m.Key).Select(m => new GoogleChartParsed { Key = m.Key, Value = m.Count() }).ToList();
        }
    }
}