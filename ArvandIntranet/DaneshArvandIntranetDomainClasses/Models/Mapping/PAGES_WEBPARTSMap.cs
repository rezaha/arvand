using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class PAGES_WEBPARTSMap : EntityTypeConfiguration<PageWebPart>
    {
        public PAGES_WEBPARTSMap()
        {
            // Primary Key
            this.HasKey(t => t.PageWebPartId);

            // Properties
            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("PAGES_WEBPARTS");
            this.Property(t => t.PageWebPartId).HasColumnName("PAGE_WEBPART");
            this.Property(t => t.PageId).HasColumnName("PAGE_ID");
            this.Property(t => t.WebpartId).HasColumnName("WEBPART_ID");
            this.Property(t => t.RowNo).HasColumnName("ROW_NO");
            this.Property(t => t.ColNo).HasColumnName("COL_NO");
            this.Property(t => t.ColOrder).HasColumnName("COL_ORDER");
            this.Property(t => t.HeaderVisible).HasColumnName("HEADER_VISIBLE");
            this.Property(t => t.CollapseOption).HasColumnName("COLLAPSE_OPTION");
            this.Property(t => t.MoveOption).HasColumnName("MOVE_OPTION");
            this.Property(t => t.DeleteOption).HasColumnName("DELETE_OPTION");
            this.Property(t => t.Remark).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.Page)
                .WithMany(t => t.PagesWebparts)
                .HasForeignKey(d => d.PageId);
            this.HasRequired(t => t.Webpart)
                .WithMany(t => t.PageWebParts)
                .HasForeignKey(d => d.WebpartId);

        }
    }
}
