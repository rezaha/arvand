using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Danesh.ArvandIntranet.DomainClasses.Models;

namespace ArvandIntranetDomainClasses.Models.Mapping
{
    public class PollsAnswersMap : EntityTypeConfiguration<PollsAnswers>
    {
        public PollsAnswersMap()
        {
            // Primary Key
            HasKey(t => new {t.FillerId, t.QuestionId });

            // Properties
            //Property(t => t.FillerId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //Property(t => t.QuestionId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.AnswerDescription)
                .HasMaxLength(1000);

            Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            ToTable("POLLS_ANSWERS");
            Property(t => t.FillerId).HasColumnName("FILLER_ID");
            Property(t => t.QuestionId).HasColumnName("QUESTION_ID");
            Property(t => t.AnswerInt).HasColumnName("ANSWER_INT");
            Property(t => t.AnswerDescription).HasColumnName("ANSWER_DESCRIPTION");
            Property(t => t.Remark).HasColumnName("REMARK");

            // Relationships
            HasRequired(t => t.PollsFiller)
                .WithMany(t => t.PollsAnswers)
                .HasForeignKey(d => d.FillerId);
            HasRequired(t => t.PollsQuestion)
                .WithMany(t => t.PollsAnswers)
                .HasForeignKey(d => d.QuestionId);

        }
    }
}
