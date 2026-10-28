using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Products
    {
        public int DivisionId { get; set; }
        public int ProductId { get; set; }
        public int ProductNo { get; set; }
        public string NamePersian { get; set; }
        public string NameLatin { get; set; }
        public string SummaryPersian { get; set; }
        public string SummaryLatin { get; set; }
        public string DescriptionPersian { get; set; }
        public string DescriptionLatin { get; set; }
        public string ProductImage { get; set; }
        public string ProductFolder { get; set; }
        public string Remark { get; set; }
    }
}
