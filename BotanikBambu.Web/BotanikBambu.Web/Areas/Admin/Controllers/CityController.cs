using BotanikBambu.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Vkod.Web.Areas.Admin.Controllers;

namespace BotanikBambu.Web.Areas.Admin.Controllers
{
    public class CityController(ICityService cityService) : AdminBaseController
    {
        private readonly ICityService _cityService=cityService;
        [HttpGet]
        public IActionResult GetAll()
        {
           return Ok(_cityService.GetAll());
        }
    }
}
