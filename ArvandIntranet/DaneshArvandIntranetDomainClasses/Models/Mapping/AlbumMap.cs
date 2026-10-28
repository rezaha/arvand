using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class AlbumMap : EntityTypeConfiguration<Album>
    {
        public AlbumMap()
        {
            // Primary Key
            this.HasKey(t => t.AlbumId);

            // Properties
            this.Property(t => t.AlbumImage)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.PersianName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.LatinName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ALBUMS");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.AlbumId).HasColumnName("ALBUM_ID");
            this.Property(t => t.AlbumType).HasColumnName("ALBUM_TYPE");
            this.Property(t => t.AlbumNo).HasColumnName("ALBUM_NO");
            this.Property(t => t.AlbumImage).HasColumnName("ALBUM_IMAGE");
            this.Property(t => t.PersianName).HasColumnName("PERSIAN_NAME");
            this.Property(t => t.LatinName).HasColumnName("LATIN_NAME");
            this.Property(t => t.Remark).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.PlantDivision)
                .WithMany(t => t.Albums)
                .HasForeignKey(d => d.DivisionId);
        }
    }
}
