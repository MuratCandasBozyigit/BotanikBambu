using BotanikBambu.Business.Abstract;
using BotanikBambu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BotanikBambu.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        public IActionResult GetAll()
        {
            return Json(_userService.GetAll());
        }
        [HttpPost]
        [RequestFormLimits(ValueLengthLimit = int.MaxValue)]
        public IActionResult Add(User appUser)
        {

            return Ok(_userService.Add(appUser));

        }

        [HttpPost]
        public IActionResult Update(User appUser)
        {

            return Ok(_userService.Update(appUser));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();

        }
        public IActionResult Profile(int id)
        {

            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);

        }




    }

}
