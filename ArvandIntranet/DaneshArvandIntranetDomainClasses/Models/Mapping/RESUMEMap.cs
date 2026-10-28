using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class RESUMEMap : EntityTypeConfiguration<Resume>
    {
        public RESUMEMap()
        {
            // Primary Key
            this.HasKey(t => t.RESUME_ID);

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
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.NATIONAL_ID)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.UNIVERSITY)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TEL_NO)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MOBILE_NO)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.EMAIL_ADDRESS)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ADDRESS)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.RESUME_FILE_ADDRESS)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.RESUME_FILE_ADDRESS1)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.RESUME_FILE_ADDRESS2)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.RESUME_FILE_ADDRESS3)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.RESUME_FILE_ADDRESS4)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.RESUME_FILE_ADDRESS5)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.RESUME_FILE_ADDRESS6)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.RESUME_FILE_ADDRESS7)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.RESUME_FILE_ADDRESS8)
                .HasMaxLength(500);

            this.Property(t => t.INSERT_DATE)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.INSERT_TIME)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.TRACKING_CODE)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("RESUMES");
            this.Property(t => t.RESUME_ID).HasColumnName("RESUME_ID");
            this.Property(t => t.SEX_ID).HasColumnName("SEX_ID");
            this.Property(t => t.FIRST_NAME).HasColumnName("FIRST_NAME");
            this.Property(t => t.LAST_NAME).HasColumnName("LAST_NAME");
            this.Property(t => t.FATHER_NAME).HasColumnName("FATHER_NAME");
            this.Property(t => t.BIRTH_DATE).HasColumnName("BIRTH_DATE");
            this.Property(t => t.BIRTH_CERT_ID).HasColumnName("BIRTH_CERT_ID");
            this.Property(t => t.NATIONAL_ID).HasColumnName("NATIONAL_ID");
            this.Property(t => t.MARRIED).HasColumnName("MARRIED");
            this.Property(t => t.MILITARY_TYPE).HasColumnName("MILITARY_TYPE");
            this.Property(t => t.DIPLOMA_AVERAGE).HasColumnName("DIPLOMA_AVERAGE");
            this.Property(t => t.CERTIFICATE_LEVEL).HasColumnName("CERTIFICATE_LEVEL");
            this.Property(t => t.UNIVERSITY).HasColumnName("UNIVERSITY");
            this.Property(t => t.CERTIFICATE).HasColumnName("CERTIFICATE");
            this.Property(t => t.CERTIFICATE_AVERAGE).HasColumnName("CERTIFICATE_AVERAGE");
            this.Property(t => t.TEL_NO).HasColumnName("TEL_NO");
            this.Property(t => t.MOBILE_NO).HasColumnName("MOBILE_NO");
            this.Property(t => t.EMAIL_ADDRESS).HasColumnName("EMAIL_ADDRESS");
            this.Property(t => t.ADDRESS).HasColumnName("ADDRESS");
            this.Property(t => t.PETROCHEMICAL_EXPERIENCE).HasColumnName("PETROCHEMICAL_EXPERIENCE");
            this.Property(t => t.USER_QUOTA).HasColumnName("USER_QUOTA");
            this.Property(t => t.RESUME_FILE_ADDRESS).HasColumnName("RESUME_FILE_ADDRESS");
            this.Property(t => t.RESUME_FILE_ADDRESS1).HasColumnName("RESUME_FILE_ADDRESS1");
            this.Property(t => t.RESUME_FILE_ADDRESS2).HasColumnName("RESUME_FILE_ADDRESS2");
            this.Property(t => t.RESUME_FILE_ADDRESS3).HasColumnName("RESUME_FILE_ADDRESS3");
            this.Property(t => t.RESUME_FILE_ADDRESS4).HasColumnName("RESUME_FILE_ADDRESS4");
            this.Property(t => t.RESUME_FILE_ADDRESS5).HasColumnName("RESUME_FILE_ADDRESS5");
            this.Property(t => t.RESUME_FILE_ADDRESS6).HasColumnName("RESUME_FILE_ADDRESS6");
            this.Property(t => t.RESUME_FILE_ADDRESS7).HasColumnName("RESUME_FILE_ADDRESS7");
            this.Property(t => t.RESUME_FILE_ADDRESS8).HasColumnName("RESUME_FILE_ADDRESS8");
            this.Property(t => t.INSERT_DATE).HasColumnName("INSERT_DATE");
            this.Property(t => t.INSERT_TIME).HasColumnName("INSERT_TIME");
            this.Property(t => t.TRACKING_CODE).HasColumnName("TRACKING_CODE");
            this.Property(t => t.SEAT_NO).HasColumnName("SEAT_NO");
            this.Property(t => t.BIDS_NO).HasColumnName("BIDS_NO");
            this.Property(t => t.GENDER_ACCEPT).HasColumnName("GENDER_ACCEPT");
            this.Property(t => t.CERT_ACCEPT).HasColumnName("CERT_ACCEPT");
            this.Property(t => t.AGE_ACCEPT).HasColumnName("AGE_ACCEPT");
            this.Property(t => t.RESUME_READ).HasColumnName("RESUME_READ");
            this.Property(t => t.RESUME_ACCEPT).HasColumnName("RESUME_ACCEPT");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
