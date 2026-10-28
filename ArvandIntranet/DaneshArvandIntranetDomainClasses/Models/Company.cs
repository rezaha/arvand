using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Company
    {
        public int CoId { get; set; }
        public string NamePersian { get; set; }
        public string NameLatin { get; set; }
        public string CoAbbr { get; set; }
        public byte CoType { get; set; }
        public byte CoOrder { get; set; }
        public string ManagerNamePersian { get; set; }
        public string ManagerNameLatin { get; set; }
        public string EstablishYear { get; set; }
        public string OperationYear { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string EmailAddress { get; set; }
        public string AddressPersian { get; set; }
        public string AddressLatin { get; set; }
        public Nullable<long> EconomicalCode { get; set; }
        public int CoCity { get; set; }
        public bool Active { get; set; }
        public string Remark { get; set; }
        public int SymbolStatus { get; set; }
        public byte[] DivisionSymbol { get; set; }
        public string DivisionSymbolLink { get; set; }
        public virtual City City { get; set; }
        public virtual CompanyTypes CompanyTypes { get; set; }
        public virtual Theme Theme { get; set; }
    }
}
