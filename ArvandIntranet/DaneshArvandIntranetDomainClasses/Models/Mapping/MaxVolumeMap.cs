using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class MaxVolumeMap : EntityTypeConfiguration<MaxVolume>
    {
        public MaxVolumeMap()
        {
            // Primary Key
            this.HasKey(t => t.FileVolumeId);

            // Properties
            // Table & Column Mappings
            this.ToTable("MAX_VOLUME");
            this.Property(t => t.FileVolumeId).HasColumnName("FILE_VOLUME_ID");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.MaxFileVolume).HasColumnName("MAX_VOLUME");

            // Relationships
            this.HasRequired(t => t.PlantDivision)
                .WithMany(t => t.MaxVolumes)
                .HasForeignKey(d => d.DivisionId);

        }
    }
}
