using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class PrayerTimeMap : EntityTypeConfiguration<PrayerTime>
    {
        public PrayerTimeMap()
        {
            // Primary Key
            this.HasKey(t => t.PrayerId);

            // Properties
            this.Property(t => t.PrayerDate)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.MorningPrayer)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Sunrise)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.NoonPrayer)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Sunset)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.MaghribPrayer)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.MidNight)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("PRAYER_TIME");
            this.Property(t => t.PrayerId).HasColumnName("PRAYER_ID");
            this.Property(t => t.CityId).HasColumnName("CITY_ID");
            this.Property(t => t.PrayerDate).HasColumnName("PRAYER_DATE");
            this.Property(t => t.MorningPrayer).HasColumnName("MORNING_PRAYER");
            this.Property(t => t.Sunrise).HasColumnName("SUNRISE");
            this.Property(t => t.NoonPrayer).HasColumnName("NOON_PRAYER");
            this.Property(t => t.Sunset).HasColumnName("SUNSET");
            this.Property(t => t.MaghribPrayer).HasColumnName("MAGHRIB_PRAYER");
            this.Property(t => t.MidNight).HasColumnName("MIDNIGHT");
            this.Property(t => t.Remark).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.City)
                .WithMany(t => t.PrayerTimes)
                .HasForeignKey(d => d.CityId);

        }
    }
}
