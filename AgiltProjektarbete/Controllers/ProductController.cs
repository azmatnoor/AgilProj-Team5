using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AgiltProjektarbete.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext context;
        public ProductController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        { 
            var pizzas = context.Pizzas.ToList();
            return View(pizzas);
        }
    }
}