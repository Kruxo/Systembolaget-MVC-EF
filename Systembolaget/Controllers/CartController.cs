using Microsoft.AspNetCore.Mvc;

namespace Systembolaget.Controllers;

public class CartController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

}
