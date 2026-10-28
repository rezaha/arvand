using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using ArvandIntranetDomainClasses.Models;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class PollMap : EntityTypeConfiguration<Poll>
    {
        public PollMap()
        {
            // Primary Key
            HasKey(t => t.PollId);

            // Properties
            Property(t => t.PollName)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            ToTable("POLLS");
            Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            Property(t => t.PollId).HasColumnName("POLL_ID");
            Property(t => t.PollNo).HasColumnName("POLL_NO");
            Property(t => t.PollName).HasColumnName("POLL_NAME");
            Property(t => t.PollType).HasColumnName("POLL_TYPE");
            Property(t => t.Active).HasColumnName("ACTIVE");
            Property(t => t.Remark).HasColumnName("REMARK");

            HasRequired(t => t.PlantDivisions)
            .WithMany(t => t.Polls)
            .HasForeignKey(d => d.DivisionId);
        }
    }
}
