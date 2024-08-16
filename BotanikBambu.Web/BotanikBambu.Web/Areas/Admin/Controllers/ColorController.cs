using Microsoft.AspNetCore.Mvc;
using BotanikBambu.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using BotanikBambu.Models;
namespace BotanikBambu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
        [HttpPost]
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
                return StatusCode(500, $"Internal server error:{ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult GetAll()
        {
            return Ok(_colorService.GetAll());
        }
        [HttpPost]
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
                return StatusCode(500, $"Internal Server Error {ex.Message}");
            }


        }
        [HttpPost]
        public IActionResult Delete([FromBody] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid Id Format");
            }

            var color = _colorService.GetFirstOrDefault(i => i.Guid == id);
            if (color == null)
            {

                return NotFound("Color Not found");
            }
            _colorService.Delete(color.Id);
            return Ok(color);
            #endregion
        }
    }
}
