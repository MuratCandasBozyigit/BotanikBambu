using BotanikBambu.Business.Abstract;
using BotanikBambu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BotanikBambu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [Route("Admin/Trucker")]
    public class TruckerController : Controller
    {
        private readonly ITruckerService _truckerService;

        public TruckerController(ITruckerService truckerService)
        {
            _truckerService = truckerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region COLOR_CRUD
        [HttpPost]
        public IActionResult Add([FromBody] Trucker trucker)
        {
            if (trucker == null)
            {
                return BadRequest("Trucker data is null.");
            }
            try
            {
                _truckerService.Add(trucker);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:{ex.Message}");
            }

        }
        [HttpPost]
        public IActionResult GetAll()
        {
            return Ok(_truckerService.GetAll());
        }
        [HttpPost]
        public IActionResult Update([FromBody] Trucker trucker)

        {
            if (trucker == null)
            {
                return BadRequest("Data is not valid");

            }
            try
            {
                _truckerService.Update(trucker);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:{ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            if (Guid.TryParse(id, out Guid parseId))
            {
                var result = _truckerService.GetFirstOrDefault(i => i.Guid == parseId);
                _truckerService.Delete(result.Id); return Ok(result);
            }

            return BadRequest();
        }
        #endregion

    }
}