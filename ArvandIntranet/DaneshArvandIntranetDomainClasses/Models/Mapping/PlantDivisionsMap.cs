

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class PlantDivisionsMap : EntityTypeConfiguration<PlantDivisions>
    {
        public PlantDivisionsMap()
        {
            // Primary Key
            HasKey(t => t.DivisionId);

            // Properties

            //Property(t => t.DivisionId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(t => t.NamePersian)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.NameLatin)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.DivisionAbbr)
                .IsRequired()
                .HasMaxLength(20);

            Property(t => t.HtmlContactusPersian)
                .HasMaxLength(8000);

            Property(t => t.HtmlContactusLatin)
                .HasMaxLength(8000);

            Property(t => t.HeaderImagePersianLink)
                .HasMaxLength(2000);

            Property(t => t.HeaderImageLatinLink)
                .HasMaxLength(2000);

            Property(t => t.DivisionIconLink)
                .HasMaxLength(2000);

            Property(t => t.TelNo)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.FaxNo)
                .IsRequired()
                .HasMaxLength(200);

            Property(t => t.EmailAddress)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.AddressPersian)
                .IsRequired()
                .HasMaxLength(500);

            Property(t => t.AddressLatin)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            ToTable("PLANT_DIVISIONS");
            Property(t => t.CoId).HasColumnName("CO_ID");
            Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            Property(t => t.NamePersian).HasColumnName("NAME_PERSIAN");
            Property(t => t.NameLatin).HasColumnName("NAME_LATIN");
            Property(t => t.DivisionAbbr).HasColumnName("DIVISION_ABBR");
            Property(t => t.DivisionOrder).HasColumnName("DIVISION_ORDER");
            Property(t => t.HtmlContactusPersianSummary).HasColumnName("HTML_CONTACTUS_PERSIAN_SUMMARY");
            Property(t => t.HtmlContactusLatinSummary).HasColumnName("HTML_CONTACTUS_LATIN_SUMMARY");
            Property(t => t.HtmlContactusPersian).HasColumnName("HTML_CONTACTUS_PERSIAN");
            Property(t => t.HtmlContactusLatin).HasColumnName("HTML_CONTACTUS_LATIN");
            Property(t => t.HeaderStatus).HasColumnName("HEADER_STATUS");
            Property(t => t.HeaderImage).HasColumnName("HEADER_IMAGE");
            Property(t => t.HeaderImagePersianLink).HasColumnName("HEADER_IMAGE_PERSIAN_LINK");
            Property(t => t.HeaderImageLatinLink).HasColumnName("HEADER_IMAGE_LATIN_LINK");
            Property(t => t.ActiveLatinSite).HasColumnName("ACTIVE_LATIN_SITE");
            Property(t => t.IconStatus).HasColumnName("ICON_STATUS");
            Property(t => t.DivisionIcon).HasColumnName("DIVISION_ICON");
            Property(t => t.DivisionIconLink).HasColumnName("DIVISION_ICON_LINK");
            Property(t => t.ParentDivisionId).HasColumnName("PARENT_DIVISION_ID");
            Property(t => t.PageSize).HasColumnName("PAGE_SIZE");
            Property(t => t.ThemeId).HasColumnName("THEME_ID");
            Property(t => t.Active).HasColumnName("ACTIVE");
            Property(t => t.TelNo).HasColumnName("TEL_NO");
            Property(t => t.FaxNo).HasColumnName("FAX_NO");
            Property(t => t.EmailAddress).HasColumnName("EMAIL_ADDRESS");
            Property(t => t.AddressPersian).HasColumnName("ADDRESS_PERSIAN");
            Property(t => t.AddressLatin).HasColumnName("ADDRESS_LATIN");

            // Relationships
            HasRequired(t => t.Theme)
                .WithMany(t => t.PlantDivisions)
                .HasForeignKey(d => d.ThemeId);

            HasOptional(t => t.ParentPlantDivision)
               .WithMany(t => t.ChildPlantDivisions)
               .HasForeignKey(d => d.ParentDivisionId);

        }
    }
}
