using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class AlbumsImages
    {
        public int AlbumId { get; set; }
        public int ImageId { get; set; }
        public string ImageAddress { get; set; }
        public string PersianDescription { get; set; }
        public string LatinDescription { get; set; }
        public string Remark { get; set; }
        public virtual Album Album { get; set; }
    }
}
