using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Masterpage
    {
        public Masterpage()
        {
            this.MASTERPAGE_WEBPARTS = new List<MasterpageWebparts>();
            this.PAGES = new List<Page>();
        }

        public int MASTERPAGE_ID { get; set; }
        public int MASTERPAGE_NO { get; set; }
        public string MASTERPAGE_FILE_NAME { get; set; }
        public string MASTERPAGE_LINK { get; set; }
        public string MASTERPAGE_TITLE_PERSIAN { get; set; }
        public string MASTERPAGE_TITLE_LATIN { get; set; }
        public string CONTENT_DIV_NAME { get; set; }
        public Nullable<int> MASTERPAGE_PARENT { get; set; }
        public int MASTERPAGE_GROUP { get; set; }
        public string REMARK { get; set; }
        public virtual ICollection<MasterpageWebparts> MASTERPAGE_WEBPARTS { get; set; }
        public virtual ICollection<Page> PAGES { get; set; }
    }
}
