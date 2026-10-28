using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class VisitorMap : EntityTypeConfiguration<Visitor>
    {
        public VisitorMap()
        {
            // Primary Key
            this.HasKey(t => t.VisitId);

            // Properties
            this.Property(t => t.PartType)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.VisitDate)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.VisitTime)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.VisitOs)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.VisitIp)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.VisitBrowser)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.VisitComputerName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("VISITORS");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.VisitId).HasColumnName("VISIT_ID");
            this.Property(t => t.PartType).HasColumnName("PART_TYPE");
            this.Property(t => t.PartId).HasColumnName("PART_ID");
            this.Property(t => t.UserType).HasColumnName("USER_TYPE");
            this.Property(t => t.UserId).HasColumnName("USER_ID");
            this.Property(t => t.VisitDate).HasColumnName("VISIT_DATE");
            this.Property(t => t.VisitTime).HasColumnName("VISIT_TIME");
            this.Property(t => t.VisitOs).HasColumnName("VISIT_OS");
            this.Property(t => t.VisitIp).HasColumnName("VISIT_IP");
            this.Property(t => t.VisitBrowser).HasColumnName("VISIT_BROWSER");
            this.Property(t => t.VisitComputerName).HasColumnName("VISIT_COMPUTERNAME");
            this.Property(t => t.Remark).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.PlantDivision)
                .WithMany(t => t.Visitors)
                .HasForeignKey(d => d.DivisionId);
        }
    }
}
