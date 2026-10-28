using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class SoftwareMap : EntityTypeConfiguration<Software>
    {
        public SoftwareMap()
        {
            // Primary Key
            this.HasKey(t => t.SoftwareId);

            // Properties
            this.Property(t => t.SoftwareLargIcon)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.SoftwareSmallIcon)
                .IsRequired()
                .HasMaxLength(1000);


            this.Property(t => t.SoftwareName)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.SoftwareUrl)
                .IsRequired()
                .HasMaxLength(500);


            // Table & Column Mappings
            this.ToTable("SOFTWARES");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.SoftwareId).HasColumnName("SOFTWARE_ID");
            this.Property(t => t.SoftwareName).HasColumnName("SOFTWARE_NAME");
            this.Property(t => t.SoftwareUrl).HasColumnName("SOFTWARE_URL");
            this.Property(t => t.SoftwareLargIcon).HasColumnName("SOFTWARE_LARG_ICON");
            this.Property(t => t.SoftwareSmallIcon).HasColumnName("SOFTWARE_SMALL_ICON");
            this.Property(t => t.SortOrder).HasColumnName("SORT_ORDER");
            this.Property(t => t.Active).HasColumnName("ACTIVE");

            // Relationships
            this.HasRequired(t => t.PlantDivision)
                .WithMany(t => t.Softwares)
                .HasForeignKey(d => d.DivisionId);
        }
    }
}
