using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class COUNTRyMap : EntityTypeConfiguration<Country>
    {
        public COUNTRyMap()
        {
            // Primary Key
            this.HasKey(t => t.COUNTRY_ID);

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
            this.ToTable("COUNTRIES");
            this.Property(t => t.COUNTRY_ID).HasColumnName("COUNTRY_ID");
            this.Property(t => t.NAME_PERSIAN).HasColumnName("NAME_PERSIAN");
            this.Property(t => t.NAME_LATIN).HasColumnName("NAME_LATIN");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
