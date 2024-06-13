using Microsoft.AspNetCore.Mvc;

namespace BSG.EasyShop.WebUI.MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
