using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LionTunes.Web.Models;

namespace LionTunes.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(SearchVM s)
        {

            switch (s.SearchType)
            {
                case "Songs":
                    //_logger.LogInformation(s.SearchText & s.SearchType)
                    return
                    RedirectToAction("Songs", "Music", new { name = s.SearchText });
                
                case "Singers":
                   return RedirectToAction("Singers", "Music", new { name = s.SearchText });
                  
                default:
                    _logger.LogError("Invalid Search Type");
                    return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
