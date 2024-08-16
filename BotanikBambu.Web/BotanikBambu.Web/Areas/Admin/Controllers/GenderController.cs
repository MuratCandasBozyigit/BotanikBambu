using BotanikBambu.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using BotanikBambu.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Http;

namespace Vkod.Web.Areas.Admin.Controllers
{
    public class GenderController : AdminBaseController
    {
        private readonly IGenderService _genderService;

        // GenderController'ın constructor'ına IHttpContextAccessor parametresi ekleniyor
        public GenderController(IGenderService genderService, IHttpContextAccessor httpContextAccessor)
            : base(httpContextAccessor) // IHttpContextAccessor'ı base class'a iletme
        {
            _genderService = genderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_genderService.GetAll());
        }
    }
}
