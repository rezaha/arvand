using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class OPINIONMap : EntityTypeConfiguration<Opinion>
    {
        public OPINIONMap()
        {
            // Primary Key
            this.HasKey(t => t.OPINION_ID);

            // Properties
            this.Property(t => t.PART_TYPE)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OPINION_DATE)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.OPINION_TIME)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.OPINION_NAME)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.OPINION_COMPANY)
                .HasMaxLength(100);

            this.Property(t => t.OPINION_TEL)
                .HasMaxLength(50);

            this.Property(t => t.OPINION_EMAIL)
                .HasMaxLength(200);

            this.Property(t => t.OPINION_SUBJECT)
                .HasMaxLength(200);

            this.Property(t => t.OPINION_CONTENT)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.REMARK)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("OPINIONS");
            this.Property(t => t.OPINION_ID).HasColumnName("OPINION_ID");
            this.Property(t => t.PART_TYPE).HasColumnName("PART_TYPE");
            this.Property(t => t.PART_ID).HasColumnName("PART_ID");
            this.Property(t => t.OPINION_DATE).HasColumnName("OPINION_DATE");
            this.Property(t => t.OPINION_TIME).HasColumnName("OPINION_TIME");
            this.Property(t => t.OPINION_NAME).HasColumnName("OPINION_NAME");
            this.Property(t => t.OPINION_COMPANY).HasColumnName("OPINION_COMPANY");
            this.Property(t => t.OPINION_TEL).HasColumnName("OPINION_TEL");
            this.Property(t => t.OPINION_EMAIL).HasColumnName("OPINION_EMAIL");
            this.Property(t => t.OPINION_SUBJECT).HasColumnName("OPINION_SUBJECT");
            this.Property(t => t.OPINION_CONTENT).HasColumnName("OPINION_CONTENT");
            this.Property(t => t.OPINION_RECIEVER).HasColumnName("OPINION_RECIEVER");
            this.Property(t => t.OPINION_SEND).HasColumnName("OPINION_SEND");
            this.Property(t => t.ADMIN_READ).HasColumnName("ADMIN_READ");
            this.Property(t => t.ADMIN_APPROVE).HasColumnName("ADMIN_APPROVE");
            this.Property(t => t.ADMIN_DELETE).HasColumnName("ADMIN_DELETE");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
