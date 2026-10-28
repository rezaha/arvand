using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class PAGES_DESIGNMap : EntityTypeConfiguration<PageDesign>
    {
        public PAGES_DESIGNMap()
        {
            // Primary Key
            this.HasKey(t => t.DesignId);

            // Properties
            this.Property(t => t.DesignName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.DesignHtml)
                .IsRequired();

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("PAGES_DESIGN");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.DesignId).HasColumnName("DESIGN_ID");
            this.Property(t => t.DesignNo).HasColumnName("DESIGN_NO");
            this.Property(t => t.DesignName).HasColumnName("DESIGN_NAME");
            this.Property(t => t.DesignHtml).HasColumnName("DESIGN_HTML");
            this.Property(t => t.ContainerCount).HasColumnName("CONTAINER_COUNT");
            this.Property(t => t.DesignFileName).HasColumnName("DESIGN_FILE_NAME");
            this.Property(t => t.DesignType).HasColumnName("DESIGN_TYPE");
            this.Property(t => t.DesignDefault).HasColumnName("DESIGN_DEFAULT");
            this.Property(t => t.Remark).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.PlantDivision)
                .WithMany(t => t.PageDesigns)
                .HasForeignKey(d => d.DivisionId);

        }
    }
}
