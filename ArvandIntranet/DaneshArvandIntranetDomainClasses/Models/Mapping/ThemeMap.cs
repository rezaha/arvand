using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class ThemeMap : EntityTypeConfiguration<Theme>
    {
        public ThemeMap()
        {
            // Primary Key
            this.HasKey(t => t.THEME_ID);

            // Properties
            this.Property(t => t.THEME_NAME)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.THEME_FILE)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.REMARK)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("THEMES");
            this.Property(t => t.THEME_ID).HasColumnName("THEME_ID");
            this.Property(t => t.THEME_NO).HasColumnName("THEME_NO");
            this.Property(t => t.THEME_NAME).HasColumnName("THEME_NAME");
            this.Property(t => t.THEME_FILE).HasColumnName("THEME_FILE");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
