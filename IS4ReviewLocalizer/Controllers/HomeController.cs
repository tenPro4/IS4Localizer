using IS4ReviewLocalizer.Helpers;
using IS4ReviewLocalizer.ViewModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace IS4ReviewLocalizer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericControllerLocalizer<HomeController> _localizer;

        public HomeController(IGenericControllerLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var vm = new HomeVM(_localizer["HomeIndex"]);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }
    }
}
