using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hqub.MusicBrainz.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LionTunes.Web.Controllers
{
    public class MusicController : Controller
    {

        // TODO: Implement search, Error Handeling
        // GET: Songs
        public async Task<ActionResult> Songs(string name)
        {

            return View("Songs", await Recording.SearchAsync(name, 10));
        }

        // GET: Song/5
        public async Task<ActionResult> Song(string id)
        {
            return View("Song", await Recording.GetAsync(id));
        }

        // GET: Singers
        public async Task<ActionResult> Singers(string name)
        {
            return View("Singers", await Artist.SearchAsync(name, 10));
        }

        // GET: Singer/5
        public async Task<ActionResult> Singer(string id)
        {
            return View("Singer", await Artist.GetAsync(id));
        }


    }
}