using System.Data.Entity.ModelConfiguration;
using Danesh.ArvandIntranet.DomainClasses.Models;

namespace ArvandIntranetDomainClasses.Models.Mapping
{
    public class PollsFillerMap : EntityTypeConfiguration<PollsFiller>
    {
        public PollsFillerMap()
        {
            // Primary Key
            HasKey(t => t.FillerId);

            // Properties
            Property(t => t.FillerName)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.FillerCompany)
                .HasMaxLength(200);

            Property(t => t.FillerTel)
                .HasMaxLength(50);

            Property(t => t.FillerEmail)
                .HasMaxLength(100);

            Property(t => t.FillDate)
                .IsRequired()
                .HasMaxLength(8);

            Property(t => t.FillTime)
                .IsRequired()
                .HasMaxLength(5);

            Property(t => t.FillerIp)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            ToTable("POLLS_FILLER");
            Property(t => t.PollId).HasColumnName("POLL_ID");
            Property(t => t.FillerId).HasColumnName("FILLER_ID");
            Property(t => t.FillerNo).HasColumnName("FILLER_NO");
            Property(t => t.FillerName).HasColumnName("FILLER_NAME");
            Property(t => t.FillerCompany).HasColumnName("FILLER_COMPANY");
            Property(t => t.FillerTel).HasColumnName("FILLER_TEL");
            Property(t => t.FillerEmail).HasColumnName("FILLER_EMAIL");
            Property(t => t.FillDate).HasColumnName("FILL_DATE");
            Property(t => t.FillTime).HasColumnName("FILL_TIME");
            Property(t => t.FillerIp).HasColumnName("FILLER_IP");
            Property(t => t.Remark).HasColumnName("REMARK");

            // Relationships
            HasRequired(t => t.Poll)
                .WithMany(t => t.PollsFiller)
                .HasForeignKey(d => d.PollId);

        }
    }
}
