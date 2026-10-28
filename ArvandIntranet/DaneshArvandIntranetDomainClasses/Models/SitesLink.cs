using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class SitesLink
    {
        public int DivisionId { get; set; }
        public int SiteId { get; set; }
        public int SiteGroup { get; set; }
        public int ShowStatus { get; set; }
        public string TitlePersian { get; set; }
        public string HtmlTitlePersian { get; set; }
        public string TitleLatin { get; set; }
        public string HtmlTitleLatin { get; set; }
        public string SiteLink { get; set; }
        public int SiteOrder { get; set; }
        public bool SiteLinkDelete { get; set; }
        public string LogoPersian { get; set; }
        public string LogoLatin { get; set; }
        public string Remark { get; set; }
    }
}
