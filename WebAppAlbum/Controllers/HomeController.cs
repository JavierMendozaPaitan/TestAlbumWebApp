using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WAppDomain.Services;
using WAppDomainBase.Interfaces;
using WAppDomainBase.Models;
using WebAppAlbum.Models;

namespace WebAppAlbum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(IWAppSrv srv, ILogger<HomeController> logger)
        {
            this.logger = logger;
            this.srv = (WAppSrv)srv;
        }

        private readonly ILogger<HomeController> logger;
        private readonly WAppSrv srv;

        //[BindProperty]
        //public List<Album> AlbumList { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Albums()
        {
            try
            {
                var model = srv.SelectAlbums();

                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Photos(string Album)
        {
            try
            {
                if (!Album.Equals("noselect"))
                {
                    var lpth = srv.GetPhotos(Album);

                    return View(lpth);
                }
                else
                    return View("Albums", srv.SelectAlbums());
            }
            catch (Exception)
            {
                throw;
            }
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
