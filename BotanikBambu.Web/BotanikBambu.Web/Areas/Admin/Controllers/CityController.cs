using BotanikBambu.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BotanikBambu.Web.Areas.Admin.Controllers
{
    public class CityController : AdminBaseController
    {
        private readonly ICityService _cityService;

        // Constructor'da IHttpContextAccessor'ı base class'a ve ICityService'yi alıyoruz
        public CityController(ICityService cityService, IHttpContextAccessor httpContextAccessor)
            : base(httpContextAccessor)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_cityService.GetAll());
        }
    }
}
