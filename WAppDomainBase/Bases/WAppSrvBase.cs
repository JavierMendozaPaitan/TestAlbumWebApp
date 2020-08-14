using System;
using System.Collections.Generic;
using System.Text;
using WAppDomainBase.Interfaces;
using WAppDomainBase.Models;

namespace WAppDomainBase.Bases
{
    public abstract class WAppSrvBase : IWAppSrv
    {
        public abstract Func<List<Album>> GetAlbums { get; }
        public abstract Func<SelectAlbums> SelectAlbums { get; }
        public abstract Func<string, List<Photo>> GetPhotos { get; }
    }
}
