using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class NewsGroupsMap : EntityTypeConfiguration<NewsGroups>
    {
        public NewsGroupsMap()
        {
            // Primary Key
            this.HasKey(t => t.GROUP_ID);

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
            this.ToTable("NEWS_GROUPS");
            this.Property(t => t.GROUP_ID).HasColumnName("GROUP_ID");
            this.Property(t => t.GROUP_NO).HasColumnName("GROUP_NO");
            this.Property(t => t.NAME_PERSIAN).HasColumnName("NAME_PERSIAN");
            this.Property(t => t.NAME_LATIN).HasColumnName("NAME_LATIN");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
