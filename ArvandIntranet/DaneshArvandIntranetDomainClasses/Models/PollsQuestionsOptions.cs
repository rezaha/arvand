namespace ArvandIntranetDomainClasses.Models
{

    public class PollsQuestionsOptions
    {
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
        public int OptionNo { get; set; }
        public string OptionText { get; set; }
        public bool Active { get; set; }
        public string Remark { get; set; }
        public virtual PollsQuestions PollsQuestions { get; set; }
    }
}
