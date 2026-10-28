using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class TENDERS_GROUPSMap : EntityTypeConfiguration<TendersGroups>
    {
        public TENDERS_GROUPSMap()
        {
            // Primary Key
            this.HasKey(t => t.GROUP_ID);

            // Properties
            this.Property(t => t.GROUP_NAME)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.REMARK)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("TENDERS_GROUPS");
            this.Property(t => t.GROUP_ID).HasColumnName("GROUP_ID");
            this.Property(t => t.GROUP_NAME).HasColumnName("GROUP_NAME");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
