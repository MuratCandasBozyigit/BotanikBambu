using Microsoft.AspNetCore.Mvc;

namespace BotanikBambu.Web.Areas.Shop.Controllers
{
    public class FavouritesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
