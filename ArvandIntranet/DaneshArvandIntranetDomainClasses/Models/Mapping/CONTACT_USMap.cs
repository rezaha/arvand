using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class CONTACT_USMap : EntityTypeConfiguration<ContactUs>
    {
        public CONTACT_USMap()
        {
            // Primary Key
            this.HasKey(t => t.CONTACT_ID);

            // Properties
            this.Property(t => t.CONTACT_NAME)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CONTACT_EMAIL)
                .HasMaxLength(100);

            this.Property(t => t.CONTACT_SUBJECT)
                .HasMaxLength(200);

            this.Property(t => t.CONTACT_TEXT)
                .IsRequired();

            this.Property(t => t.CONTACT_DATE)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.CONTACT_TIME)
                .IsRequired()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("CONTACT_US");
            this.Property(t => t.DIVISION_ID).HasColumnName("DIVISION_ID");
            this.Property(t => t.CONTACT_ID).HasColumnName("CONTACT_ID");
            this.Property(t => t.CONTACT_TYPE).HasColumnName("CONTACT_TYPE");
            this.Property(t => t.CONTACT_NAME).HasColumnName("CONTACT_NAME");
            this.Property(t => t.CONTACT_EMAIL).HasColumnName("CONTACT_EMAIL");
            this.Property(t => t.CONTACT_SUBJECT).HasColumnName("CONTACT_SUBJECT");
            this.Property(t => t.CONTACT_TEXT).HasColumnName("CONTACT_TEXT");
            this.Property(t => t.CONTACT_DATE).HasColumnName("CONTACT_DATE");
            this.Property(t => t.CONTACT_TIME).HasColumnName("CONTACT_TIME");
            this.Property(t => t.IS_READ).HasColumnName("IS_READ");
            this.Property(t => t.IS_DELETE).HasColumnName("IS_DELETE");
        }
    }
}
