using BotanikBambu.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BotanikBambu.Web.Areas.Shop.Controllers
{
    public class ShopController : Controller
    {
        private readonly IBambuService _bambuService;
        private readonly IColorService _colorService;
        private readonly ICartsService _cartService;
        public ShopController(IBambuService bambuService, IColorService colorService, ICartsService cartService)
        {
            _bambuService = bambuService;
            _colorService = colorService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region GET_ALL
        public IActionResult GetAllBambu()
        {

            return Ok(_bambuService.GetAll());
        }
        public IActionResult GetAllCart()
        {
            return Ok(_cartService.GetAll());
        }
        public IActionResult GetAllColors()
        {
            return Ok(_colorService.GetAll());
        }

        #endregion

        #region Link_Carts

        #endregion
    }
}
