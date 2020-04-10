using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LionTunes.Web.Models;
using System.Text.RegularExpressions;

namespace LionTunes.Web.Controllers
{
    /// <summary>
    /// The HomeControllers handels the default page and generic pages for the web app.
    /// </summary>
    public class HomeController : Controller
    {
        // using built in dependecny injection to inject the.net core logger (like log4j or log4net)
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Takes you to the default search page which is also the strating page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// The Search method is the primary entry point into the functionality of this app.
        /// It takes a view-model of SearchVM which requrie both a search text string and search type.
        /// This method will validate its inputs and give feedback to the user.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IActionResult Search(SearchVM s)
        {
            // ensure we have a search value
            if (s.SearchText is null)
            {
                string msg = "No Search value provided.";
                _logger.LogInformation(msg);
                ViewData["error"] = msg;
                return View("Index");
            }

            // setup what we define as valid string input, input validation
            var validStringInput = new Regex("^[a-zA-Z0-9_? ]*$");

            // validate the input 
            if (!validStringInput.IsMatch(s.SearchText))
            {
                string msg = "Invalid Search value provided.";
                _logger.LogInformation(msg);
                ViewData["error"] = msg;
                return View("Index");
            }

            // ensure we have a search type and pick the correct route based on criteria
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

        /// <summary>
        /// If there is an applicaiton crash, this will return the error page. It also will not cache the response.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
