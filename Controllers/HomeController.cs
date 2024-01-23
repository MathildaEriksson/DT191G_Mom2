using Microsoft.AspNetCore.Mvc;

namespace DT191G_Mom2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() {
        return View();
    }

        public IActionResult Characters() {
        return View();
    }
}