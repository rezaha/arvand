using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class SitesLinkMap : EntityTypeConfiguration<SitesLink>
    {
        public SitesLinkMap()
        {
            // Primary Key
            this.HasKey(t => t.SiteId);

            // Properties
            this.Property(t => t.TitlePersian)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.HtmlTitlePersian)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.TitleLatin)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.HtmlTitleLatin)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.SiteLink)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.LogoPersian)
                .HasMaxLength(500);

            this.Property(t => t.LogoLatin)
                .HasMaxLength(500);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("SITES_LINK");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.SiteId).HasColumnName("SITE_ID");
            this.Property(t => t.SiteGroup).HasColumnName("SITE_GROUP");
            this.Property(t => t.ShowStatus).HasColumnName("SHOW_STATUS");
            this.Property(t => t.TitlePersian).HasColumnName("TITLE_PERSIAN");
            this.Property(t => t.HtmlTitlePersian).HasColumnName("HTML_TITLE_PERSIAN");
            this.Property(t => t.TitleLatin).HasColumnName("TITLE_LATIN");
            this.Property(t => t.HtmlTitleLatin).HasColumnName("HTML_TITLE_LATIN");
            this.Property(t => t.SiteLink).HasColumnName("SITE_LINK");
            this.Property(t => t.SiteOrder).HasColumnName("SITE_ORDER");
            this.Property(t => t.SiteLinkDelete).HasColumnName("SITE_LINK_DELETE");
            this.Property(t => t.LogoPersian).HasColumnName("LOGO_PERSIAN");
            this.Property(t => t.LogoLatin).HasColumnName("LOGO_LATIN");
            this.Property(t => t.Remark).HasColumnName("REMARK");
        }
    }
}
