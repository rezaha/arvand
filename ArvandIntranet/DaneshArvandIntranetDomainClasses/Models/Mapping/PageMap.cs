using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class PageMap : EntityTypeConfiguration<Page>
    {
        public PageMap()
        {
            // Primary Key
            this.HasKey(t => t.PageId);

            // Properties
            this.Property(t => t.PageFileName)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.PageTitle)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.PageLink)
                .HasMaxLength(500);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("PAGES");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.PageId).HasColumnName("PAGE_ID");
            this.Property(t => t.PageNo).HasColumnName("PAGE_NO");
            this.Ignore(t => t.PageType);
            this.Property(t => t.PageTypeId).HasColumnName("PAGE_TYPE");
            this.Property(t => t.MasterPageId).HasColumnName("MASTERPAGE_ID");
            this.Property(t => t.PageFileName).HasColumnName("PAGE_FILE_NAME");
            this.Property(t => t.PageTitle).HasColumnName("PAGE_TITLE");
            this.Property(t => t.PageLink).HasColumnName("PAGE_LINK");
            this.Property(t => t.PageSummary).HasColumnName("PAGE_SUMMARY");
            this.Property(t => t.PageContent).HasColumnName("PAGE_CONTENT");
            this.Property(t => t.PageDelete).HasColumnName("PAGE_DELETE");
            this.Property(t => t.Active).HasColumnName("ACTIVE");
            this.Property(t => t.Remark).HasColumnName("REMARK");
            this.Property(t => t.DesignId).HasColumnName("DESIGN_ID");

            // Relationships
            this.HasRequired(t => t.MasterPage)
                .WithMany(t => t.PAGES)
                .HasForeignKey(d => d.MasterPageId);

            this.HasRequired(t => t.PlantDivision)
                .WithMany(t => t.Pages)
                .HasForeignKey(d => d.DivisionId);

            this.HasRequired(t => t.PageDesign)
               .WithMany(t => t.Pages)
               .HasForeignKey(d => d.DesignId);

        }
    }
}
