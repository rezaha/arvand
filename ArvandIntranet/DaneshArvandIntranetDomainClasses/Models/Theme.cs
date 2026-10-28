using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Theme
    {
        public int THEME_ID { get; set; }
        public int THEME_NO { get; set; }
        public string THEME_NAME { get; set; }
        public string THEME_FILE { get; set; }
        public string REMARK { get; set; }
        public virtual ICollection<PlantDivisions> PlantDivisions { get; set; }
    }
}
