using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class WEBPARTMap : EntityTypeConfiguration<Webpart>
    {
        public WEBPARTMap()
        {
            // Primary Key
            this.HasKey(t => t.WebpartId);

            // Properties
            this.Property(t => t.WebpartName)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.NamePersian)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.NameLatin)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.HeaderPersian)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.HeaderLatin)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.HtmlContentPersian)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.HtmlContentLatin)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.WebpartAddress)
                .HasMaxLength(2000);

            this.Property(t => t.WebpartMethod)
                .HasMaxLength(200);

            this.Property(t => t.WebpartParametrs)
                .HasMaxLength(500);

            this.Property(t => t.DescriptionPersian)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.DescriptionLatin)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("WEBPARTS");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.WebpartId).HasColumnName("WEBPART_ID");
            this.Property(t => t.WebpartNo).HasColumnName("WEBPART_NO");
            this.Property(t => t.WebpartType).HasColumnName("WEBPART_TYPE");
            this.Property(t => t.WebpartGroup).HasColumnName("WEBPART_GROUP");
            this.Property(t => t.WebpartName).HasColumnName("WEBPART_NAME");
            this.Property(t => t.NamePersian).HasColumnName("NAME_PERSIAN");
            this.Property(t => t.NameLatin).HasColumnName("NAME_LATIN");
            this.Property(t => t.HeaderPersian).HasColumnName("HEADER_PERSIAN");
            this.Property(t => t.HeaderLatin).HasColumnName("HEADER_LATIN");
            this.Property(t => t.HtmlContentPersian).HasColumnName("HTML_CONTENT_PERSIAN");
            this.Property(t => t.HtmlContentLatin).HasColumnName("HTML_CONTENT_LATIN");
            this.Property(t => t.WebpartAddress).HasColumnName("WEBPART_ADDRESS");
            this.Property(t => t.WebpartMethod).HasColumnName("WEBPART_METHOD");
            this.Property(t => t.WebpartParametrs).HasColumnName("WEBPART_PARAMETERS");
            this.Property(t => t.DescriptionPersian).HasColumnName("DESCRIPTION_PERSIAN");
            this.Property(t => t.DescriptionLatin).HasColumnName("DESCRIPTION_LATIN");
            this.Property(t => t.Active).HasColumnName("ACTIVE");
            this.Property(t => t.Remark).HasColumnName("REMARK");

            //Relationship
            this.HasRequired(t => t.PlantDivision )
           .WithMany(t => t.Webparts)
           .HasForeignKey(d => d.DivisionId);
        }
    }
}
