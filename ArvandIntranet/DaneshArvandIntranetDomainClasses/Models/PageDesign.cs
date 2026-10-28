using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class PageDesign
    {
        public int DivisionId { get; set; }
        public int DesignId { get; set; }
        public int DesignNo { get; set; }
        public string DesignName { get; set; }
        public string DesignHtml { get; set; }
        public int ContainerCount { get; set; }
        public string DesignFileName { get; set; }
        public bool DesignType { get; set; }
        public bool DesignDefault { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public virtual PlantDivisions PlantDivision { get; set; }
    }
}
