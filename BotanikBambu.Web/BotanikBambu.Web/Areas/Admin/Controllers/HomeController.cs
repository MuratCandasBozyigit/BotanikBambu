using Microsoft.AspNetCore.Mvc;
using Vkod.Web.Areas.Admin.Controllers;

namespace BotanikBambu.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
