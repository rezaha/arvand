using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class PAGES_METATAGSMap : EntityTypeConfiguration<PagesMetatags>
    {
        public PAGES_METATAGSMap()
        {
            // Primary Key
            this.HasKey(t => t.META_NO);

            // Properties
            this.Property(t => t.PART_TYPE)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.META_ID)
                .HasMaxLength(100);

            this.Property(t => t.META_NAME)
                .HasMaxLength(200);

            this.Property(t => t.META_CONTENT)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.META_HTTPEQUIV)
                .HasMaxLength(200);

            this.Property(t => t.META_LANG)
                .HasMaxLength(100);

            this.Property(t => t.META_DIR)
                .HasMaxLength(50);

            this.Property(t => t.META_SCHEME)
                .HasMaxLength(100);

            this.Property(t => t.META_XMLLANG)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("PAGES_METATAGS");
            this.Property(t => t.META_NO).HasColumnName("META_NO");
            this.Property(t => t.PART_TYPE).HasColumnName("PART_TYPE");
            this.Property(t => t.PART_ID).HasColumnName("PART_ID");
            this.Property(t => t.META_ID).HasColumnName("META_ID");
            this.Property(t => t.META_NAME).HasColumnName("META_NAME");
            this.Property(t => t.META_CONTENT).HasColumnName("META_CONTENT");
            this.Property(t => t.META_HTTPEQUIV).HasColumnName("META_HTTPEQUIV");
            this.Property(t => t.META_LANG).HasColumnName("META_LANG");
            this.Property(t => t.META_DIR).HasColumnName("META_DIR");
            this.Property(t => t.META_SCHEME).HasColumnName("META_SCHEME");
            this.Property(t => t.META_XMLLANG).HasColumnName("META_XMLLANG");
            this.Property(t => t.ACTIVE).HasColumnName("ACTIVE");
        }
    }
}
