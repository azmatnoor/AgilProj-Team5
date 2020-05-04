using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AgiltProjektarbete
{
    public class OrderController : Controller
    {
        public IActionResult Index(string id)
        {
            return View();
        }

        public IActionResult ConfirmOrder(string id)
        {
            return View();
        }

        public IActionResult AddOrder(string id)
        {
            return RedirectToAction("Index");
        }
    }
}