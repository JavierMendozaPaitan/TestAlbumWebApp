using System;
using System.Collections.Generic;
using System.Text;
using WAppDomainBase.Models;

namespace WAppDomainBase.Interfaces
{
    public interface IWAppSrv
    {
        Func<SelectAlbums> SelectAlbums { get; }
        Func<List<Album>> GetAlbums { get; }
    }
}
