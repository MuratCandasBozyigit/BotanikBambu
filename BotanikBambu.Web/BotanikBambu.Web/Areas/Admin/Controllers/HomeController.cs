using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BotanikBambu.Web.Areas.Admin.Controllers;

namespace BotanikBambu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : AdminBaseController
    {
        public HomeController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
