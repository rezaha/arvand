using System.Collections.Generic;
using Danesh.ArvandIntranet.DomainClasses.Models;

namespace ArvandIntranetDomainClasses.Models
{
    public class Poll
    {
        public int DivisionId { get; set; }
        public int PollId { get; set; }
        public int PollNo { get; set; }
        public string PollName { get; set; }
        public int PollType { get; set; }
        public bool Active { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<PollsFiller> PollsFiller { get; set; }
        public virtual ICollection<PollsQuestions> PollsQuestions { get; set; }
        public virtual PlantDivisions PlantDivisions { get; set; }
    }
}
