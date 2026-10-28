using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class MASTERPAGE_WEBPARTSMap : EntityTypeConfiguration<MasterpageWebparts>
    {
        public MASTERPAGE_WEBPARTSMap()
        {
            // Primary Key
            this.HasKey(t => t.MASTERPAGE_WEBPART);

            // Properties
            this.Property(t => t.REMARK)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("MASTERPAGE_WEBPARTS");
            this.Property(t => t.MASTERPAGE_WEBPART).HasColumnName("MASTERPAGE_WEBPART");
            this.Property(t => t.MASTERPAGE_ID).HasColumnName("MASTERPAGE_ID");
            this.Property(t => t.WEBPART_ID).HasColumnName("WEBPART_ID");
            this.Property(t => t.ROW_NO).HasColumnName("ROW_NO");
            this.Property(t => t.COL_NO).HasColumnName("COL_NO");
            this.Property(t => t.COL_ORDER).HasColumnName("COL_ORDER");
            this.Property(t => t.COLLAPSE_OPTION).HasColumnName("COLLAPSE_OPTION");
            this.Property(t => t.MOVE_OPTION).HasColumnName("MOVE_OPTION");
            this.Property(t => t.DELETE_OPTION).HasColumnName("DELETE_OPTION");
            this.Property(t => t.REMARK).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.MASTERPAGE)
                .WithMany(t => t.MASTERPAGE_WEBPARTS)
                .HasForeignKey(d => d.MASTERPAGE_ID);
            this.HasRequired(t => t.WEBPART)
                .WithMany(t => t.MasterpageWebparts)
                .HasForeignKey(d => d.WEBPART_ID);

        }
    }
}
