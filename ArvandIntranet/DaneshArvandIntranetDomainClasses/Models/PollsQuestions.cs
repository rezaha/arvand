using System.Collections.Generic;
using Danesh.ArvandIntranet.DomainClasses.Models;

namespace ArvandIntranetDomainClasses.Models
{
    public class PollsQuestions
    {
        public int PollId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionNo { get; set; }
        public string QuestionDescription { get; set; }
        public int AnswerType { get; set; }
        public int? AnswerCount { get; set; }
        public int QuestionWeight { get; set; }
        public string Remark { get; set; }
        public virtual Poll Poll { get; set; }
        public virtual ICollection<PollsAnswers> PollsAnswers { get; set; }
        public virtual ICollection<PollsQuestionsOptions> PollsQuestionsOptions { get; set; }
    }
}
