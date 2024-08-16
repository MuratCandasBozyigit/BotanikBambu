using Microsoft.AspNetCore.Mvc;
using BotanikBambu.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using BotanikBambu.Models;
namespace BotanikBambu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [Route("Admin/Bambu")]
    public class BambuController : Controller
    {
        private readonly IBambuService _bambuService;
        private readonly IColorService _colorService;
        public BambuController(IBambuService bambuService, IColorService colorService)
        {
            _bambuService = bambuService;
            _colorService = colorService;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region GETALLMETHODS

        [HttpGet]
        public IActionResult GetAllColors()
        {
            var colors = _colorService.GetAll();
            return Json(colors);
        }
        #endregion
        #region BAMBU_CRUD
        [HttpPost]
        public IActionResult Add([FromBody] Bambu bambu)
        {
            if (bambu == null)
            {
                return BadRequest("Color data is null.");
            }
            try
            {
                _bambuService.Add(bambu);
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
            return Ok(_bambuService.GetAll());
        }
        [HttpPost]
        public IActionResult Update([FromBody] Bambu bambu)
        {
            if (bambu == null)
            {
                return BadRequest("Bambu data is null.");
            }
            try
            {
                _bambuService.Update(bambu);
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

            var bambu = _bambuService.GetFirstOrDefault(i => i.Guid == id);
            if (bambu == null)
            {

                return NotFound("Bambu Not found");
            }
            _bambuService.Delete(bambu.Id);
            return Ok(bambu);
            #endregion
        }
    }
}
