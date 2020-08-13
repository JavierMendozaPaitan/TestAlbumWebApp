using System;
using System.Collections.Generic;
using System.Text;

namespace WAppDomainBase.Models
{
    public class Album
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Photo> Photos { get; set; }
    }
}
