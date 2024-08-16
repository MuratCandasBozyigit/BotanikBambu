using Microsoft.AspNetCore.Mvc;
using Vkod.Web.Areas.Admin.Controllers;

namespace BotanikBambu.Web.Areas.Admin.Controllers
{
    public class AdminHomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
