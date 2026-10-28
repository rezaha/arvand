using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class EXECUTIVE_MANAGERSMap : EntityTypeConfiguration<ExecutiveManagers>
    {
        public EXECUTIVE_MANAGERSMap()
        {
            // Primary Key
            this.HasKey(t => t.ManagerId);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PositionName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CertificateName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Exprience)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.TelNo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.FaxNo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ManagerPicture)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("EXECUTIVE_MANAGERS");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.ManagerId).HasColumnName("EX_ID");
            this.Property(t => t.FirstName).HasColumnName("PERSON_NAME");
            this.Property(t => t.LastName).HasColumnName("PERSON_LAST_NAME");
            this.Property(t => t.PositionName).HasColumnName("POSITION_NAME");
            this.Property(t => t.CertificateName).HasColumnName("CERTIFICATE_NAME");
            this.Property(t => t.Exprience).HasColumnName("EXPRIENCE");
            this.Property(t => t.TelNo).HasColumnName("TEL_NO");
            this.Property(t => t.FaxNo).HasColumnName("FAX_NO");
            this.Property(t => t.Email).HasColumnName("EMAIL");
            this.Property(t => t.RowNo).HasColumnName("ROW_NO");
            this.Property(t => t.ColNo).HasColumnName("COL_NO");
            this.Property(t => t.ManagerPicture).HasColumnName("MANAGER_PICTURE");
            this.Property(t => t.Active).HasColumnName("ACTIVE");
            this.Property(t => t.Remark).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.PlantDivision)
                .WithMany(t => t.ExecutiveManagers)
                .HasForeignKey(d => d.DivisionId);
        }
    }
}
