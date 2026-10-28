using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class PROVINCEMap : EntityTypeConfiguration<Province>
    {
        public PROVINCEMap()
        {
            // Primary Key
            this.HasKey(t => t.PROVINCE_ID);

            // Properties
            this.Property(t => t.NAME_PERSIAN)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.NAME_LATIN)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.REMARK)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("PROVINCES");
            this.Property(t => t.COUNTRY_ID).HasColumnName("COUNTRY_ID");
            this.Property(t => t.PROVINCE_ID).HasColumnName("PROVINCE_ID");
            this.Property(t => t.NAME_PERSIAN).HasColumnName("NAME_PERSIAN");
            this.Property(t => t.NAME_LATIN).HasColumnName("NAME_LATIN");
            this.Property(t => t.REMARK).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.COUNTRy)
                .WithMany(t => t.PROVINCES)
                .HasForeignKey(d => d.COUNTRY_ID);

        }
    }
}
