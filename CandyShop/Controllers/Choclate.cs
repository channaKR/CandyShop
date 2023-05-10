using Microsoft.AspNetCore.Mvc;

namespace CandyShop.Controllers
{
    public class Choclate : Controller
    {
        [HttpGet]
        public IActionResult AddChoclate()
        {
            return View();
        }
    }
}
