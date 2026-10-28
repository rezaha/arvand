using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Visitor
    {
        public int DivisionId { get; set; }
        public int VisitId { get; set; }
        public string PartType { get; set; }
        public int PartId { get; set; }
        public bool UserType { get; set; }
        public Nullable<int> UserId { get; set; }
        public string VisitDate { get; set; }
        public string VisitTime { get; set; }
        public string VisitOs { get; set; }
        public string VisitIp { get; set; }
        public string VisitBrowser { get; set; }
        public string VisitComputerName { get; set; }
        public string Remark { get; set; }
        public virtual PlantDivisions PlantDivision { get; set; }
    }
}
