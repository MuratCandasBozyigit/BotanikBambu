using Microsoft.AspNetCore.Mvc;

namespace BotanikBambu.Web.Areas.Shop.Controllers
{
    public class CartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
