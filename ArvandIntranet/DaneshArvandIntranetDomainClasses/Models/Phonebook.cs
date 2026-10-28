using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Phonebook
    {
        public int DivisionId { get; set; }
        public int PhonebookId { get; set; }
        public string PhonebookName { get; set; }
        public string PhonebookPlant { get; set; }
        public string PhonebookTel { get; set; }
        public string PhonebookFax { get; set; }
        public string PhonebookEmail { get; set; }
        public string Remark { get; set; }
        public virtual PlantDivisions PlantDivision { get; set; }
    }
}
