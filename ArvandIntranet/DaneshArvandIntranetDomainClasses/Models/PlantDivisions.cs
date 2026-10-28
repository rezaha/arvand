using System;
using System.Collections.Generic;
using ArvandIntranetDomainClasses.Models;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class PlantDivisions
    {
        public int CoId { get; set; }
        public int DivisionId { get; set; }
        public string NamePersian { get; set; }
        public string NameLatin { get; set; }
        public string DivisionAbbr { get; set; }
        public byte? DivisionOrder { get; set; }
        public string HtmlContactusPersianSummary { get; set; }
        public string HtmlContactusLatinSummary { get; set; }
        public string HtmlContactusPersian { get; set; }
        public string HtmlContactusLatin { get; set; }
        public int HeaderStatus { get; set; }
        public byte[] HeaderImage { get; set; }
        public string HeaderImagePersianLink { get; set; }
        public string HeaderImageLatinLink { get; set; }
        public bool ActiveLatinSite { get; set; }
        public int IconStatus { get; set; }
        public byte[] DivisionIcon { get; set; }
        public string DivisionIconLink { get; set; }
        public int? ParentDivisionId { get; set; }
        public int? PageSize { get; set; }
        public int ThemeId { get; set; }
        public bool Active { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string EmailAddress { get; set; }
        public string AddressPersian { get; set; }
        public string AddressLatin { get; set; }
        public virtual ICollection<SecurityUsers> SecurityUsers { get; set; }
        public virtual ICollection<Webpart> Webparts { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public virtual ICollection<Software> Softwares { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<ExecutiveManagers> ExecutiveManagers { get; set; }
        public virtual ICollection<Phonebook> Phonebooks { get; set; }
        public virtual ICollection<Statistic> Statistics { get; set; }
        public virtual ICollection<Visitor> Visitors { get; set; }
        public virtual ICollection<PageDesign> PageDesigns { get; set; }
        public virtual ICollection<MaxVolume> MaxVolumes { get; set; }
        public virtual ICollection<Poll> Polls { get; set; }
        public virtual ICollection<PlantDivisions> ChildPlantDivisions { get; set; }
        public virtual Theme Theme { get; set; }
        public virtual PlantDivisions ParentPlantDivision { get; set; }
        public virtual ICollection<SystemHistory> SystemHistorys { get; set; }
    }
}
