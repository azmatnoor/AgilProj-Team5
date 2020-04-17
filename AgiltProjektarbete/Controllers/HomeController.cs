using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index([FromRoute]string search)
        {
            var restaurants = await context.Restaurants.ToListAsync();
            return View(restaurants);
        }
    }
}
