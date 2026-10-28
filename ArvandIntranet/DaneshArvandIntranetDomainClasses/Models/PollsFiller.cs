using System.Collections.Generic;

namespace ArvandIntranetDomainClasses.Models
{
    public class PollsFiller
    {
        public int PollId { get; set; }
        public int FillerId { get; set; }
        public int FillerNo { get; set; }
        public string FillerName { get; set; }
        public string FillerCompany { get; set; }
        public string FillerTel { get; set; }
        public string FillerEmail { get; set; }
        public string FillDate { get; set; }
        public string FillTime { get; set; }
        public string FillerIp { get; set; }
        public string Remark { get; set; }
        public virtual Poll Poll { get; set; }
        public virtual ICollection<PollsAnswers> PollsAnswers { get; set; }
    }
}
