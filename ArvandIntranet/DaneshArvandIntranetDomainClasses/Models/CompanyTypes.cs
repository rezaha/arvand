using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class CompanyTypes
    {

        public byte CoTypeId { get; set; }
        public string CoTypeDes { get; set; }
        public virtual ICollection<Company> COMPANIES { get; set; }
    }
}
