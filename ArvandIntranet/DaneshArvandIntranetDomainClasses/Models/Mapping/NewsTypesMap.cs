using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class NewsTypesMap : EntityTypeConfiguration<NewsTypes>
    {
        public NewsTypesMap()
        {
            // Primary Key
            this.HasKey(t => t.TypeId);

            // Properties
            this.Property(t => t.NamePersian)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.NameLatin)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("NEWS_TYPES");
            this.Property(t => t.TypeId).HasColumnName("TYPE_ID");
            this.Property(t => t.TypeNo).HasColumnName("TYPE_NO");
            this.Property(t => t.NamePersian).HasColumnName("NAME_PERSIAN");
            this.Property(t => t.NameLatin).HasColumnName("NAME_LATIN");
            this.Property(t => t.Remark).HasColumnName("REMARK");
        }
    }
}
