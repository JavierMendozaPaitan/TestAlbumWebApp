using System;
using System.Collections.Generic;
using System.Linq;
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
                GetPhotos = PhtLst;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        private readonly ILogger<WAppSrv> logger;

        public override Func<List<Album>> GetAlbums { get; }
        public override Func<SelectAlbums> SelectAlbums { get; }
        public override Func<string, List<Photo>> GetPhotos { get; }

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
                var pht = PhtLst();
                var alb1 = new Album
                {
                    Id = "A1",
                    Name = "Album 1",
                    Photos = pht.Where(x => x.AlbumId.Equals("A1")).ToList()
                };
                lst.Add(alb1);
                var alb2 = new Album
                {
                    Id = "A2",
                    Name = "Album 2",
                    Photos = pht.Where(x => x.AlbumId.Equals("A2")).ToList()
                };
                lst.Add(alb2);
                var alb3 = new Album
                {
                    Id = "A3",
                    Name = "Album 3",
                    Photos = pht.Where(x => x.AlbumId.Equals("A3")).ToList()
                };
                lst.Add(alb3);

                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<Photo> PhtLst(string album)
        {
            try
            {
                var lalb = AlbLst();
                var lst = lalb.Find(x => x.Id.Equals(album)).Photos;

                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<Photo> PhtLst()
        {
            try
            {
                var lst = new List<Photo>
                {
                    new Photo{ AlbumId = "A1", Name = "Photo 1", CreationDate = DateTime.Now, Comments = new List<Comment>{ new Comment { Content="Content 1"} } },
                    new Photo{ AlbumId = "A1", Name = "Photo 2", CreationDate = DateTime.Now, Comments = new List<Comment>{ new Comment { Content="Content 1"} } },
                    new Photo{ AlbumId = "A1", Name = "Photo 3", CreationDate = DateTime.Now, Comments = new List<Comment>{ new Comment { Content="Content 1"} } },
                    new Photo{ AlbumId = "A2", Name = "Photo 4", CreationDate = DateTime.Now, Comments = new List<Comment>{ new Comment { Content="Content 1"} } },
                    new Photo{ AlbumId = "A2", Name = "Photo 5", CreationDate = DateTime.Now, Comments = new List<Comment>{ new Comment { Content="Content 1"} } },
                    new Photo{ AlbumId = "A2", Name = "Photo 6", CreationDate = DateTime.Now, Comments = new List<Comment>{ new Comment { Content="Content 1"} } },
                    new Photo{ AlbumId = "A3", Name = "Photo 7", CreationDate = DateTime.Now, Comments = new List<Comment>{ new Comment { Content="Content 1"} } },
                    new Photo{ AlbumId = "A3", Name = "Photo 8", CreationDate = DateTime.Now, Comments = new List<Comment>{ new Comment { Content="Content 1"} } },
                };

                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
