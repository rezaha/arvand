using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class WEATHERMap : EntityTypeConfiguration<Weather>
    {
        public WEATHERMap()
        {
            // Primary Key
            this.HasKey(t => t.WEATHER_ID);

            // Properties
            this.Property(t => t.WEATHER_HTML)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.REMARK)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("WEATHER");
            this.Property(t => t.WEATHER_ID).HasColumnName("WEATHER_ID");
            this.Property(t => t.WEATHER_CITY).HasColumnName("WEATHER_CITY");
            this.Property(t => t.WEATHER_CODE).HasColumnName("WEATHER_CODE");
            this.Property(t => t.CITY_DEFAULT).HasColumnName("CITY_DEFAULT");
            this.Property(t => t.SHOW_TYPE).HasColumnName("SHOW_TYPE");
            this.Property(t => t.WEATHER_HTML).HasColumnName("WEATHER_HTML");
            this.Property(t => t.ACTIVE).HasColumnName("ACTIVE");
            this.Property(t => t.REMARK).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.CITy)
                .WithMany(t => t.Weathers)
                .HasForeignKey(d => d.WEATHER_CITY);

        }
    }
}
