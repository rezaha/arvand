using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class PageWebPart
    {
        public int PageWebPartId { get; set; }
        public int PageId { get; set; }
        public int WebpartId { get; set; }
        public int RowNo { get; set; }
        public int ColNo { get; set; }
        public int ColOrder { get; set; }
        public bool HeaderVisible { get; set; }
        public bool CollapseOption { get; set; }
        public bool MoveOption { get; set; }
        public bool DeleteOption { get; set; }
        public string Remark { get; set; }
        public virtual Page Page { get; set; }
        public virtual Webpart Webpart { get; set; }
    }
}
