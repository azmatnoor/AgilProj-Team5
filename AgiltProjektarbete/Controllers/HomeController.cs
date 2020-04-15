using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AgiltProjektarbete.Models;
using Microsoft.EntityFrameworkCore;

namespace AgiltProjektarbete
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext context;

        public HomeController(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index(SearchRestaurantModel model)
        {
            if(model.Restaurants == null && model.SearchValue == default)
            {
                model = new SearchRestaurantModel();
            }
            
            model.Restaurants = await context.Restaurants.ToListAsync();

            if(model.SearchValue != default)
            {
                model.Restaurants = model.Restaurants.Where(o => o.ZIPCode == model.SearchValue).ToList();
            }

            return View(model);
        }
    }
}
