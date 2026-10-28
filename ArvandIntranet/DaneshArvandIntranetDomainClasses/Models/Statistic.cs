using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class Statistic
    {
        public int DivisionId { get; set; }
        public int STATISTIC_ID { get; set; }
        public string PART_TYPE { get; set; }
        public int PART_ID { get; set; }
        public int COUNTER_TODAY { get; set; }
        public int COUNTER_YESTERDAY { get; set; }
        public int COUNTER_CWEEK { get; set; }
        public int COUNTER_LWEEK { get; set; }
        public int COUNTER_CMONTH { get; set; }
        public int COUNTER_LMONTH { get; set; }
        public int COUNTER_TOTAL { get; set; }
        public int COUNTER_CUSER { get; set; }
        public int COUNTER_CGUEST { get; set; }
        public int COUNTER_USER { get; set; }
        public int COUNTER_GUEST { get; set; }
        public virtual PlantDivisions PlantDivision { get; set; }
    }
}
