using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class DocManagement
    {
        public int WebPartId { get; set; }
        public int DocId { get; set; }
        public string DocTitle { get; set; }
        public string DocUrl { get; set; }
        public bool PublicGrant { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<DocGrant> DocGrants { get; set; }
        public virtual Webpart Webpart { get; set; }
    }
}
