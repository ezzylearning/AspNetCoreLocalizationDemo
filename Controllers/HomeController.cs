using AspNetCoreLocalizationDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;

namespace AspNetCoreLocalizationDemo.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IStringLocalizer<HomeController> _stringLocalizer;

       // public HomeController(IStringLocalizer<HomeController> stringLocalizer)
        public HomeController()
        {
           // _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
           // ViewData["PageTitle"] = _stringLocalizer["page.title"].Value;
           // ViewData["PageDesc"] = _stringLocalizer["page.description"].Value;

            return View();
        }

        [HttpPost]
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(7)
                    }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
