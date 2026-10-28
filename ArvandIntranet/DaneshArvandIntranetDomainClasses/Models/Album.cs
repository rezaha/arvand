using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Album
    {
        public int DivisionId { get; set; }
        public int AlbumId { get; set; }
        public int AlbumType { get; set; }
        public int AlbumNo { get; set; }
        public string AlbumImage { get; set; }
        public string PersianName { get; set; }
        public string LatinName { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<AlbumsImages> AlbumsImages { get; set; }
        public virtual PlantDivisions PlantDivision { get; set; }
    }
}
