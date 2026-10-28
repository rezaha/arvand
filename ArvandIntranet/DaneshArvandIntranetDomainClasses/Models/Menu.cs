using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Menu
    {
        public int DivisionId { get; set; }
        public int MenuId { get; set; }
        public int MenuNo { get; set; }
        public int ShowStatus { get; set; }
        public string NamePersian { get; set; }
        public string NameLatin { get; set; }
        public bool LinkActive { get; set; }
        public string MenuLinkPersian { get; set; }
        public string MenuLinkLatin { get; set; }
        public int MenuLevel { get; set; }
        public int MenuOrder { get; set; }
        public Nullable<int> MenuParent { get; set; }
        public int ResultStatus { get; set; }
        public int IconStatus { get; set; }
        public string MenuIconLink { get; set; }
        public bool Active { get; set; }
        public string Remark { get; set; }
        public virtual Menu Parent { get; set; }
    }
}
