using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hqub.MusicBrainz.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LionTunes.Web.Controllers
{
    /// <summary>
    /// This controller handels all of the web requests for Singer(s) and Songs(s). 
    /// It talks directly to the MusicBrainz API.
    /// </summary>
    public class MusicController : Controller
    {

        // using built in dependecny injection to inject the.net core logger (like log4j or log4net)
        private readonly ILogger<MusicController> _logger;


        public MusicController(ILogger<MusicController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Lookup songs by name, limits the collection of results.
        /// Using Async to free up threads on the web server.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        // GET: Songs
        public async Task<ActionResult> Songs(string name)
        {
            try
            {
                // use asyc method to find songs by name, limit to 10 results
                var result = await Recording.SearchAsync(name,10);
                // did we get any results?
                if (result.Count < 1)
                {
                    _logger.LogError($"No Search Results for Songs Titled: {name}");
                    ViewData["error"] = "Could not find the song you were looking for. " +
                        "Go back to the home page and Try again.";
                }
                // return the view with a view model
                return View("Songs", result);
            }
            catch (Exception ex)
            {
                // something went wrong, log it and bring user back to home.
                _logger.LogError("Error finding any Recordings", ex.InnerException);
                ViewData["error"] = "An error occured, please try your search again.";
                return View("~/Views/Home/index.cshtml");
            }

        }
        /// <summary>
        /// Lookup a song by Id, only returns one song.
        /// Using Async to free up threads on the web server.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Song/5
        public async Task<ActionResult> Song(string id)
        {
            try
            {
                // use async method to find song by ID and related data (sub qurires)
                var result = await Recording.GetAsync(id, "artist-credits", "releases", "media", 
                                "discids", "isrcs", "genres", "tags", "work-rels", "url-rels");
                // did we get any results?
                if (result is null)
                {
                    _logger.LogError($"No Search Results for SongId: {id}");
                    ViewData["error"] = "Could not find the song you were looking for. " +
                        "Go back to the home page and Try again.";
                }
                // return the view with a view model
                return View("Song", result);
            }
            catch (Exception ex)
            {
                // something went wrong, log it and bring user back to home.
                _logger.LogError("Error finding Recording", ex.InnerException);
                ViewData["error"] = "An error occured, please try your search again.";
                return View("~/Views/Home/index.cshtml");
            }
        }
        /// <summary>
        /// Lookup singers by name, returns a collection of possible matches
        /// Using Async to free up threads on the web server.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        // GET: Singers
        public async Task<ActionResult> Singers(string name)
        {
            try
            {
                // use asyc method to find artists by name, limit to 10 results
                var result = await Artist.SearchAsync(name,10);
                // did we get any results?
                if (result.Count < 1)
                {
                    _logger.LogError($"No Results for Singer: {name}");
                    ViewData["error"] = "Could not find the singer you were looking for. " +
                        "Go back to the home page and Try again.";
                }
                // return the view with a view model
                return View("Singers", result);
            }
            catch (Exception ex)
            {
                // something went wrong, log it and bring user back to home.
                _logger.LogError("Error finding any Artist", ex.InnerException);
                ViewData["error"] = "An error occured, please try your search again.";
                return View("~/Views/Home/index.cshtml");
            }

        }
        /// <summary>
        /// Look for singer by Id.
        /// Returns one singer
        /// Using Async to free up threads on the web server.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Singer/5
        public async Task<ActionResult> Singer(string id)
        {
            try
            {
                // use async method to find singer by ID and bring back related data.
                var result = await Artist.GetAsync(id, "artist-rels", "url-rels", "recordings", "releases", "works");

                // did we get any results?
                if (result is null)
                {
                    _logger.LogError($"No Search Results for SingerId: {id}");
                    ViewData["error"] = "Could not find the singer you were looking for. " +
                        "Go back to the home page and Try again.";
                }
                // return the view with a view model
                return View("Singer", result);
            }
            catch (Exception ex)
            {
                // something went wrong, log it and bring user back to home.
                _logger.LogError("Error finding Artist", ex.InnerException);
                ViewData["error"] = "An error occured, please try your search again.";
                return View("~/Views/Home/index.cshtml");
            }
        }
    }
}