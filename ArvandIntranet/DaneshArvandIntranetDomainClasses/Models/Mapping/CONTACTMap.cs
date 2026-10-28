using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class CONTACTMap : EntityTypeConfiguration<Contact>
    {
        public CONTACTMap()
        {
            // Primary Key
            this.HasKey(t => t.CONTACT_ID);

            // Properties
            this.Property(t => t.CONTACT_NAME)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CONTACT_POSITION)
                .HasMaxLength(50);

            this.Property(t => t.CONTACT_LOCATION)
                .HasMaxLength(200);

            this.Property(t => t.CONTACT_TEL1)
                .HasMaxLength(50);

            this.Property(t => t.CONTACT_TEL2)
                .HasMaxLength(50);

            this.Property(t => t.CONTACT_TEL3)
                .HasMaxLength(50);

            this.Property(t => t.CONTACT_TEL4)
                .HasMaxLength(50);

            this.Property(t => t.CONTACT_FAX)
                .HasMaxLength(50);

            this.Property(t => t.CONTACT_EMAIL)
                .HasMaxLength(100);

            this.Property(t => t.CONTACT_WEBSITE)
                .HasMaxLength(50);

            this.Property(t => t.CONTACT_ADDRESS)
                .HasMaxLength(200);

            this.Property(t => t.REMARK)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("CONTACTS");
            this.Property(t => t.DIVISION_ID).HasColumnName("DIVISION_ID");
            this.Property(t => t.CONTACT_ID).HasColumnName("CONTACT_ID");
            this.Property(t => t.CONTACT_NO).HasColumnName("CONTACT_NO");
            this.Property(t => t.CONTACT_NAME).HasColumnName("CONTACT_NAME");
            this.Property(t => t.CONTACT_POSITION).HasColumnName("CONTACT_POSITION");
            this.Property(t => t.CONTACT_LOCATION).HasColumnName("CONTACT_LOCATION");
            this.Property(t => t.CONTACT_TEL1).HasColumnName("CONTACT_TEL1");
            this.Property(t => t.CONTACT_TEL2).HasColumnName("CONTACT_TEL2");
            this.Property(t => t.CONTACT_TEL3).HasColumnName("CONTACT_TEL3");
            this.Property(t => t.CONTACT_TEL4).HasColumnName("CONTACT_TEL4");
            this.Property(t => t.CONTACT_FAX).HasColumnName("CONTACT_FAX");
            this.Property(t => t.CONTACT_EMAIL).HasColumnName("CONTACT_EMAIL");
            this.Property(t => t.CONTACT_WEBSITE).HasColumnName("CONTACT_WEBSITE");
            this.Property(t => t.CONTACT_ADDRESS).HasColumnName("CONTACT_ADDRESS");
            this.Property(t => t.ACTIVE).HasColumnName("ACTIVE");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
