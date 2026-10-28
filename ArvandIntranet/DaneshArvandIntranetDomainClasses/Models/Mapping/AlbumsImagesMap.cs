using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class AlbumsImagesMap : EntityTypeConfiguration<AlbumsImages>
    {
        public AlbumsImagesMap()
        {
            // Primary Key
            this.HasKey(t => t.ImageId);

            // Properties
            this.Property(t => t.ImageAddress)
                .IsRequired()
                .HasMaxLength(1000);

            this.Property(t => t.PersianDescription)
                .HasMaxLength(8000);

            this.Property(t => t.LatinDescription)
                .HasMaxLength(8000);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ALBUMS_IMAGES");
            this.Property(t => t.AlbumId).HasColumnName("ALBUM_ID");
            this.Property(t => t.ImageId).HasColumnName("IMAGE_ID");
            this.Property(t => t.ImageAddress).HasColumnName("IMAGE_ADDRESS");
            this.Property(t => t.PersianDescription).HasColumnName("PERSIAN_DESCRIPTION");
            this.Property(t => t.LatinDescription).HasColumnName("LATIN_DESCRIPTION");
            this.Property(t => t.Remark).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.Album)
                .WithMany(t => t.AlbumsImages)
                .HasForeignKey(d => d.AlbumId);

        }
    }
}
