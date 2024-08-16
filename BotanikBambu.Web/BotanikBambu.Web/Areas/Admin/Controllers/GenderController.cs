using BotanikBambu.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using BotanikBambu.Business.Abstract;

namespace Vkod.Web.Areas.Admin.Controllers
{
    public class GenderController(IGenderService genderService) : AdminBaseController
    {
        private readonly IGenderService _genderService = genderService;
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_genderService.GetAll());
        }
    }
}
