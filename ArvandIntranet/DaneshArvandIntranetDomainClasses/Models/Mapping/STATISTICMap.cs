using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class STATISTICMap : EntityTypeConfiguration<Statistic>
    {
        public STATISTICMap()
        {
            // Primary Key
            this.HasKey(t => t.STATISTIC_ID);

            // Properties
            this.Property(t => t.PART_TYPE)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("STATISTICS");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.STATISTIC_ID).HasColumnName("STATISTIC_ID");
            this.Property(t => t.PART_TYPE).HasColumnName("PART_TYPE");
            this.Property(t => t.PART_ID).HasColumnName("PART_ID");
            this.Property(t => t.COUNTER_TODAY).HasColumnName("COUNTER_TODAY");
            this.Property(t => t.COUNTER_YESTERDAY).HasColumnName("COUNTER_YESTERDAY");
            this.Property(t => t.COUNTER_CWEEK).HasColumnName("COUNTER_CWEEK");
            this.Property(t => t.COUNTER_LWEEK).HasColumnName("COUNTER_LWEEK");
            this.Property(t => t.COUNTER_CMONTH).HasColumnName("COUNTER_CMONTH");
            this.Property(t => t.COUNTER_LMONTH).HasColumnName("COUNTER_LMONTH");
            this.Property(t => t.COUNTER_TOTAL).HasColumnName("COUNTER_TOTAL");
            this.Property(t => t.COUNTER_CUSER).HasColumnName("COUNTER_CUSER");
            this.Property(t => t.COUNTER_CGUEST).HasColumnName("COUNTER_CGUEST");
            this.Property(t => t.COUNTER_USER).HasColumnName("COUNTER_USER");
            this.Property(t => t.COUNTER_GUEST).HasColumnName("COUNTER_GUEST");

            // Relationships
            this.HasRequired(t => t.PlantDivision)
                .WithMany(t => t.Statistics)
                .HasForeignKey(d => d.DivisionId);
        }
    }
}
