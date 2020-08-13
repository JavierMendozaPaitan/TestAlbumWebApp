using System;
using System.Collections.Generic;
using System.Text;

namespace WAppDomainBase.Models
{
    public class Photo
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
