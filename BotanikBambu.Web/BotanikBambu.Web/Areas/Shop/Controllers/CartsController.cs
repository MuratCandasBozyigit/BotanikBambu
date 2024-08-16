using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BotanikBambu.Web.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Authorize]
    [Route("Shop/Carts")]
    public class CartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
