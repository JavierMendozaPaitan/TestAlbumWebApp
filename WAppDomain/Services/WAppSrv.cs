using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WAppDomainBase.Bases;
using WAppDomainBase.Models;

namespace WAppDomain.Services
{
    public class WAppSrv : WAppSrvBase
    {
        public WAppSrv(ILogger<WAppSrv> logger)
        {
            try
            {
                this.logger = logger;
                GetAlbums = AlbLst;
                SelectAlbums = GetSelAlb;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        private readonly ILogger<WAppSrv> logger;

        public override Func<List<Album>> GetAlbums { get; }
        public override Func<SelectAlbums> SelectAlbums { get; }

        private SelectAlbums GetSelAlb()
        {
            try
            {
                var lst = new SelectAlbums
                {
                    Album = "Album 1",
                    Albums = new List<SelectListItem>()                   
                };
                var lalb = AlbLst();
                foreach (var item in lalb)
                {
                    var sitm = new SelectListItem { Value = item.Id, Text = item.Name };
                    lst.Albums.Add(sitm);
                }

                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<Album> AlbLst()
        {
            try
            {
                var lst = new List<Album>();
                var alb1 = new Album
                {
                    Id = "A1",
                    Name = "Album 1"
                };
                lst.Add(alb1);
                var alb2 = new Album
                {
                    Id = "A2",
                    Name = "Album 2"
                };
                lst.Add(alb2);
                var alb3 = new Album
                {
                    Id = "A3",
                    Name = "Album 3"
                };
                lst.Add(alb3);

                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
