using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Products>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductId);

            // Properties
            this.Property(t => t.NamePersian)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.NameLatin)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SummaryPersian)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.SummaryLatin)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.ProductImage)
                .HasMaxLength(500);

            this.Property(t => t.ProductFolder)
                .HasMaxLength(500);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("PRODUCTS");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.ProductId).HasColumnName("PRODUCT_ID");
            this.Property(t => t.ProductNo).HasColumnName("PRODUCT_NO");
            this.Property(t => t.NamePersian).HasColumnName("NAME_PERSIAN");
            this.Property(t => t.NameLatin).HasColumnName("NAME_LATIN");
            this.Property(t => t.SummaryPersian).HasColumnName("SUMMARY_PERSIAN");
            this.Property(t => t.SummaryLatin).HasColumnName("SUMMARY_LATIN");
            this.Property(t => t.DescriptionPersian).HasColumnName("DESCRIPTION_PERSIAN");
            this.Property(t => t.DescriptionLatin).HasColumnName("DESCRIPTION_LATIN");
            this.Property(t => t.ProductImage).HasColumnName("PRODUCT_IMAGE");
            this.Property(t => t.ProductFolder).HasColumnName("PRODUCT_FOLDER");
            this.Property(t => t.Remark).HasColumnName("REMARK");
        }
    }
}
