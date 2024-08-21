using BotanikBambu.Business.Abstract;
using BotanikBambu.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is invalid.");
            }

            try
            {
                var trucker = _truckerService.GetById(id);
                if (trucker == null)
                {
                    return NotFound();
                }
                return Ok(trucker);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var truckers = _truckerService.GetAll();
                return Ok(truckers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpPut("Update/{id}")]
        public IActionResult Update(Guid id, [FromBody] Trucker trucker)
        {
            if (trucker == null)
            {
                return BadRequest("Data is not valid.");
            }

            try
            {
                // Kamyoncuyu güncelleme işlemi yapılmadan önce ID doğrulaması
                var existingTrucker = _truckerService.GetById(id);
                if (existingTrucker == null)
                {
                    return NotFound("Trucker not found.");
                }

                _truckerService.Update(trucker);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
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
