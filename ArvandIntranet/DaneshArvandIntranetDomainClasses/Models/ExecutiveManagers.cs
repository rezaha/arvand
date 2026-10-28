using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class ExecutiveManagers
    {
        public int DivisionId { get; set; }
        public int ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PositionName { get; set; }
        public string CertificateName { get; set; }
        public string Exprience { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public int RowNo { get; set; }
        public int ColNo { get; set; }
        public string ManagerPicture { get; set; }
        public bool Active { get; set; }
        public string Remark { get; set; }
        public virtual PlantDivisions PlantDivision { get; set; }
    }
}
