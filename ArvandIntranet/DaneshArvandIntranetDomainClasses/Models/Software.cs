using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Software
    {
        public int SoftwareId { get; set; }
        public int DivisionId { get; set; }
        public string SoftwareName { get; set; }
        public string SoftwareUrl { get; set; }
        public string SoftwareLargIcon { get; set; }
        public string SoftwareSmallIcon { get; set; }
        public int SortOrder { get; set; }
        public bool Active { get; set; }
        public virtual PlantDivisions PlantDivision { get; set; }
    }
}
