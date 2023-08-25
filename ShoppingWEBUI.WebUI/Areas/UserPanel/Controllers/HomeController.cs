using Microsoft.AspNetCore.Mvc;
using ShoppingWEBUI.Core.ViewModel;
using ShoppingWEBUI.Helper.SessionHelper;

namespace ShoppingWEBUI.WebUI.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("/User/Anasayfa")]
        public IActionResult Index()
        {
            UserViewModel user = new()
            {

                AdSoyad = SessionManager.LoggedUser.AdSoyad,
                ID = Convert.ToInt32(SessionManager.LoggedUser.UserID),
                EPosta = SessionManager.LoggedUser.EPosta

            };

            return View(user);
        }
    }
}

