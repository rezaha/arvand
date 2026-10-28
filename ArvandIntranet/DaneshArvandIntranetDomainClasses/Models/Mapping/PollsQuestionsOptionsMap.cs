using System.Data.Entity.ModelConfiguration;
using Danesh.ArvandIntranet.DomainClasses.Models;

namespace ArvandIntranetDomainClasses.Models.Mapping
{
    public class PollsQuestionsOptionsMap : EntityTypeConfiguration<PollsQuestionsOptions>
    {
        public PollsQuestionsOptionsMap()
        {
            // Primary Key
            HasKey(t => t.OptionId);

            // Properties
            Property(t => t.OptionText)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            ToTable("POLLS_QUESTIONS_OPTIONS");
            Property(t => t.QuestionId).HasColumnName("QUESTION_ID");
            Property(t => t.OptionId).HasColumnName("OPTION_ID");
            Property(t => t.OptionNo).HasColumnName("OPTION_NO");
            Property(t => t.OptionText).HasColumnName("OPTION_TEXT");
            Property(t => t.Active).HasColumnName("ACTIVE");
            Property(t => t.Remark).HasColumnName("REMARK");

            // Relationships
            HasRequired(t => t.PollsQuestions)
                .WithMany(t => t.PollsQuestionsOptions)
                .HasForeignKey(d => d.QuestionId);

        }
    }
}
