using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            // Primary Key
            this.HasKey(t => t.CityId);

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
            this.ToTable("CITIES");
            this.Property(t => t.ProvinceId).HasColumnName("PROVINCE_ID");
            this.Property(t => t.CityId).HasColumnName("CITY_ID");
            this.Property(t => t.NamePersian).HasColumnName("NAME_PERSIAN");
            this.Property(t => t.NameLatin).HasColumnName("NAME_LATIN");
            this.Property(t => t.Remark).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.Province)
                .WithMany(t => t.CITIES)
                .HasForeignKey(d => d.ProvinceId);

        }
    }
}
