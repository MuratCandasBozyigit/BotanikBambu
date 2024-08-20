using BotanikBambu.Business.Abstract;
using BotanikBambu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BotanikBambu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]

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

        #region TRUCKER_CRUD
        [HttpPost("Add")]
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
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var trucker = _truckerService.GetAll();
                return Ok(trucker);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("Update")]
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

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var result = _truckerService.GetFirstOrDefault(i => i.Guid == id);
                if (result != null)
                {
                    _truckerService.Delete(result.Id);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        #endregion

    }
}