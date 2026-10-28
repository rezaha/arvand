using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class DocGrant
    {
        public int DocGrantId { get; set; }
        public int DocId { get; set; }
        public string UserDomain { get; set; }
        public virtual DocManagement DocManagement { get; set; }
    }
}
