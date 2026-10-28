using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class PagesMetatags
    {
        public int META_NO { get; set; }
        public string PART_TYPE { get; set; }
        public int PART_ID { get; set; }
        public string META_ID { get; set; }
        public string META_NAME { get; set; }
        public string META_CONTENT { get; set; }
        public string META_HTTPEQUIV { get; set; }
        public string META_LANG { get; set; }
        public string META_DIR { get; set; }
        public string META_SCHEME { get; set; }
        public string META_XMLLANG { get; set; }
        public bool ACTIVE { get; set; }
    }
}
