using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class News
    {
        public int DivisionId { get; set; }
        public int NewsId { get; set; }
        public int NewsNo { get; set; }
        public string NewsUrlFriendly { get; set; }
        public int NewsGroup { get; set; }
        public int NewsType { get; set; }
        public int NewsKind { get; set; }
        public int ShowStatus { get; set; }
        public string TitlePersian { get; set; }
        public string TitleLatin { get; set; }
        public string SummaryPersian { get; set; }
        public string HtmlSummaryPersian { get; set; }
        public string SummaryLatin { get; set; }
        public string HtmlSummaryLatin { get; set; }
        public string ContentPersian { get; set; }
        public string HtmlContentPersian { get; set; }
        public string ContentLatin { get; set; }
        public string HtmlContentLatin { get; set; }
        public string NewsDate { get; set; }
        public string NewsTime { get; set; }
        public int NewsOrder { get; set; }
        public bool NewsShare { get; set; }
        public bool NewsShareOk { get; set; }
        public string ShowDate { get; set; }
        public string ShowTime { get; set; }
        public string ExpireDate { get; set; }
        public string ExpireTime { get; set; }
        public string ShowWeekDays { get; set; }
        public string NewsLabels { get; set; }
        public int InsertUser { get; set; }
        public string SmallPictureLink { get; set; }
        public string LargePictureLink { get; set; }
        public bool NewsDelete { get; set; }
        public bool Active { get; set; }
        public string Remark { get; set; }
        public virtual NewsGroups NewsGroups { get; set; }
        public virtual NewsKinds NewsKinds { get; set; }
        public virtual NewsTypes NewsTypes { get; set; }
    }
}
