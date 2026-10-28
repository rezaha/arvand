using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class MASTERPAGEMap : EntityTypeConfiguration<Masterpage>
    {
        public MASTERPAGEMap()
        {
            // Primary Key
            this.HasKey(t => t.MASTERPAGE_ID);

            // Properties
            this.Property(t => t.MASTERPAGE_FILE_NAME)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.MASTERPAGE_LINK)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.MASTERPAGE_TITLE_PERSIAN)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.MASTERPAGE_TITLE_LATIN)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.CONTENT_DIV_NAME)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.REMARK)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("MASTERPAGES");
            this.Property(t => t.MASTERPAGE_ID).HasColumnName("MASTERPAGE_ID");
            this.Property(t => t.MASTERPAGE_NO).HasColumnName("MASTERPAGE_NO");
            this.Property(t => t.MASTERPAGE_FILE_NAME).HasColumnName("MASTERPAGE_FILE_NAME");
            this.Property(t => t.MASTERPAGE_LINK).HasColumnName("MASTERPAGE_LINK");
            this.Property(t => t.MASTERPAGE_TITLE_PERSIAN).HasColumnName("MASTERPAGE_TITLE_PERSIAN");
            this.Property(t => t.MASTERPAGE_TITLE_LATIN).HasColumnName("MASTERPAGE_TITLE_LATIN");
            this.Property(t => t.CONTENT_DIV_NAME).HasColumnName("CONTENT_DIV_NAME");
            this.Property(t => t.MASTERPAGE_PARENT).HasColumnName("MASTERPAGE_PARENT");
            this.Property(t => t.MASTERPAGE_GROUP).HasColumnName("MASTERPAGE_GROUP");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
