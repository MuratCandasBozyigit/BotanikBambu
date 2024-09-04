using BotanikBambu.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BotanikBambu.Web.Areas.Shop.Controllers
{
    [Area("Shop")]
    [Authorize]
    [Route("Shop/Shop")]
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

        #region PUT_ALL
        //Put all carts tuş tetieklendiğinde bu işlemi yapacak cart service putall gibi bbir yapı oluştur ajaxla tetiklendiğinde oraya pushlansın kullnıcı login yapılmış ise sql de ıd ile tutması lazım ürünü şu ıd ili ürün vardı diye değil ise cache bellekte tutması daha saglıklı refresh atıldığında favların gitmesi lazım yada hata koyarsın favorilere eklemek için girş yapmış olmanız lazım falan diye.
        #endregion

        #region Link_Carts

        #endregion
    }
}
