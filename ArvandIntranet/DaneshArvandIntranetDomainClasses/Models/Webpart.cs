using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Webpart
    {
        public int DivisionId { get; set; }
        public int WebpartId { get; set; }
        public int WebpartNo { get; set; }
        public int WebpartType { get; set; }
        public int WebpartGroup { get; set; }
        public string WebpartName { get; set; }
        public string NamePersian { get; set; }
        public string NameLatin { get; set; }
        public string HeaderPersian { get; set; }
        public string HeaderLatin { get; set; }
        public string HtmlContentPersian { get; set; }
        public string HtmlContentLatin { get; set; }
        public string WebpartAddress { get; set; }
        public string WebpartMethod { get; set; }
        public string WebpartParametrs { get; set; }
        public string DescriptionPersian { get; set; }
        public string DescriptionLatin { get; set; }
        public bool Active { get; set; }
        public string Remark { get; set; }
        public virtual PlantDivisions PlantDivision { get; set; }
        public virtual ICollection<MasterpageWebparts> MasterpageWebparts { get; set; }
        public virtual ICollection<PageWebPart> PageWebParts { get; set; }
        public virtual ICollection<DocManagement> DocManagements { get; set; }
    }
}
