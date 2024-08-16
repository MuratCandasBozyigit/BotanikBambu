using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Vkod.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
  //  [Authorize(Roles = "Admin")] // Sadece "Admin" rolüne sahip kullanıcılar erişebilir
    public class AdminBaseController : Controller
    {
        private readonly int _userId;

        public AdminBaseController()
        {
            // Eğer kullanıcı kimliği doğrulanmışsa (Authenticated), kullanıcı ID'sini alır
            if (User.Identity.IsAuthenticated)
            {
                // Kullanıcı ID'sini alır ve _userId değişkenine atar
                _userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            }
            else
            {
                // Eğer kullanıcı giriş yapmamışsa, bir hata fırlatabilirsiniz ya da başka bir işlem yapabilirsiniz
                _userId = 0; // Veya başka bir varsayılan değer
            }
        }
    }
}
