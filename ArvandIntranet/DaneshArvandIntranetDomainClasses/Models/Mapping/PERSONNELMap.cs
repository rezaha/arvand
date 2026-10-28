using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class PERSONNELMap : EntityTypeConfiguration<Personnel>
    {
        public PERSONNELMap()
        {
            // Primary Key
            this.HasKey(t => t.PERSON_ID);

            // Properties
            this.Property(t => t.FIRST_NAME)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LAST_NAME)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FATHER_NAME)
                .HasMaxLength(50);

            this.Property(t => t.BIRTH_DATE)
                .HasMaxLength(8);

            this.Property(t => t.NATIONAL_ID)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.EMP_DATE)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.REMARK)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("PERSONNEL");
            this.Property(t => t.PERSON_ID).HasColumnName("PERSON_ID");
            this.Property(t => t.PERSON_NO).HasColumnName("PERSON_NO");
            this.Property(t => t.SEX_ID).HasColumnName("SEX_ID");
            this.Property(t => t.FIRST_NAME).HasColumnName("FIRST_NAME");
            this.Property(t => t.LAST_NAME).HasColumnName("LAST_NAME");
            this.Property(t => t.FATHER_NAME).HasColumnName("FATHER_NAME");
            this.Property(t => t.BIRTH_DATE).HasColumnName("BIRTH_DATE");
            this.Property(t => t.BIRTH_CERT_ID).HasColumnName("BIRTH_CERT_ID");
            this.Property(t => t.NATIONAL_ID).HasColumnName("NATIONAL_ID");
            this.Property(t => t.CERTIFICATE_ID).HasColumnName("CERTIFICATE_ID");
            this.Property(t => t.EMP_TYPE).HasColumnName("EMP_TYPE");
            this.Property(t => t.EMP_DATE).HasColumnName("EMP_DATE");
            this.Property(t => t.POSITION_ID).HasColumnName("POSITION_ID");
            this.Property(t => t.ACTIVE).HasColumnName("ACTIVE");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
