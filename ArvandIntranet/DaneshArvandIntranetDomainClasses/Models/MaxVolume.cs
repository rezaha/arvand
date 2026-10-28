using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class MaxVolume
    {
        public int FileVolumeId { get; set; }
        public int DivisionId { get; set; }
        public int MaxFileVolume { get; set; }
        public virtual PlantDivisions PlantDivision { get; set; }
    }
}
