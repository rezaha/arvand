using Danesh.ArvandIntranet.DomainClasses.Models;

namespace ArvandIntranetDomainClasses.Models
{
    public class PollsAnswers
    {
        public int FillerId { get; set; }
        public int QuestionId { get; set; }
        public int? AnswerInt { get; set; }
        public string AnswerDescription { get; set; }
        public string Remark { get; set; }
        public virtual PollsFiller PollsFiller { get; set; }
        public virtual PollsQuestions PollsQuestion { get; set; }
    }
}
