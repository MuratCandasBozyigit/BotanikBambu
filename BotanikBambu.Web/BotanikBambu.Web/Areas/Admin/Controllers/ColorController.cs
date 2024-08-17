using Microsoft.AspNetCore.Mvc;
using BotanikBambu.Business.Abstract;
using BotanikBambu.Models;
using System;

namespace BotanikBambu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Color")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region COLOR_CRUD

        [HttpPost("Add")]
        public IActionResult Add([FromBody] Color color)
        {
            if (color == null)
            {
                return BadRequest("Color data is null.");
            }
            try
            {
                _colorService.Add(color);
                return Ok();
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
                var colors = _colorService.GetAll();
                return Ok(colors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("Update/{id}")]
        public IActionResult Update([FromBody] Color color)
        {
            if (color == null)
            {
                return BadRequest("Color data is null.");
            }
            try
            {
                _colorService.Update(color);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid Id Format");
            }
            try
            {
                var color = _colorService.GetById(id);
                if (color == null)
                {
                    return NotFound("Color Not Found");
                }
                return Ok(color);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid Id Format");
            }

            var color = _colorService.GetById(id);
            if (color == null)
            {
                return NotFound("Color Not Found");
            }

            _colorService.Delete(id);
            return Ok();
        }


        #endregion
    }
}
