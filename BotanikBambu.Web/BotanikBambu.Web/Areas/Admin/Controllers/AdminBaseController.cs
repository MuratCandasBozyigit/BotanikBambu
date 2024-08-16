using BotanikBambu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BotanikBambu.Web.Areas.Admin.Controllers
{
    // Burada controller'dan kalıtılması gerekiyor
    public class AdminBaseController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public int UserId { get; private set; }

        // Constructor'da hata varsa class içinde değil, method veya özellik tanımlamalarında olabilir
        public AdminBaseController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            if (_httpContextAccessor.HttpContext != null &&
                _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null)
                {
                    UserId = int.Parse(userIdClaim.Value);
                }
            }
            else
            {
                // Kullanıcı kimliği yoksa veya HttpContext null ise bir varsayılan değer atayın
                UserId = 0;  // Örneğin, UserId'yi sıfır olarak ayarlayabilirsiniz
            }
        }
    }
}
