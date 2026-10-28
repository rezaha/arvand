using System.Data.Entity.ModelConfiguration;

namespace ArvandIntranetDomainClasses.Models.Mapping
{
    public class PollsQuestionsMap : EntityTypeConfiguration<PollsQuestions>
    {
        public PollsQuestionsMap()
        {
            // Primary Key
            HasKey(t => t.QuestionId);

            // Properties
            Property(t => t.QuestionDescription)
                .IsRequired()
                .HasMaxLength(5000);

            Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            ToTable("POLLS_QUESTIONS");
            Property(t => t.PollId).HasColumnName("POLL_ID");
            Property(t => t.QuestionId).HasColumnName("QUESTION_ID");
            Property(t => t.QuestionNo).HasColumnName("QUESTION_NO");
            Property(t => t.QuestionDescription).HasColumnName("QUESTION_DESCRIPTION");
            Property(t => t.AnswerType).HasColumnName("ANSWER_TYPE");
            Property(t => t.AnswerCount).HasColumnName("ANSWER_COUNT");
            Property(t => t.QuestionWeight).HasColumnName("QUESTION_WEIGHT");
            Property(t => t.Remark).HasColumnName("REMARK");

            HasRequired(t => t.Poll)
                .WithMany(t => t.PollsQuestions)
                .HasForeignKey(d => d.PollId);
        }
    }
}
