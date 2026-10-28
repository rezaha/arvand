using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Page
    {
        public int DivisionId { get; set; }
        public int PageId { get; set; }
        public int PageNo { get; set; }
        public byte PageTypeId { get; set; }
        //[NotMapped]
        public PageType PageType
        {
            get { return (PageType)this.PageTypeId; }
            set { this.PageTypeId = (byte)value; }
        }
        public int MasterPageId { get; set; }
        public string PageFileName { get; set; }
        public string PageTitle { get; set; }
        public string PageLink { get; set; }
        public string PageContent { get; set; }
        public string PageSummary { get; set; }
        public bool PageDelete { get; set; }
        public bool Active { get; set; }
        public string Remark { get; set; }
        public int? DesignId { get; set; }
        public virtual Masterpage MasterPage { get; set; }
        public virtual ICollection<PageWebPart> PagesWebparts { get; set; }
        public virtual PlantDivisions PlantDivision { get; set; }
        public virtual PageDesign PageDesign { get; set; }
    }
    public enum PageType
    {
        UserDefinePage = 1,
        SystemPage = 2
    }
}
