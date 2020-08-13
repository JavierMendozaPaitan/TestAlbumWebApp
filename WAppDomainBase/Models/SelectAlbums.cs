using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WAppDomainBase.Models
{
    public class SelectAlbums
    {
        public string Album { get; set; }
        public List<SelectListItem> Albums { get; set; }
    }
}
