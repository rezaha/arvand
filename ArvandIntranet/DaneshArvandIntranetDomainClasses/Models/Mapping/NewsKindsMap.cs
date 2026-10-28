using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class NewsKindsMap : EntityTypeConfiguration<NewsKinds>
    {
        public NewsKindsMap()
        {
            // Primary Key
            this.HasKey(t => t.KIND_ID);

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
            this.ToTable("NEWS_KINDS");
            this.Property(t => t.KIND_ID).HasColumnName("KIND_ID");
            this.Property(t => t.KIND_NO).HasColumnName("KIND_NO");
            this.Property(t => t.NAME_PERSIAN).HasColumnName("NAME_PERSIAN");
            this.Property(t => t.NAME_LATIN).HasColumnName("NAME_LATIN");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
