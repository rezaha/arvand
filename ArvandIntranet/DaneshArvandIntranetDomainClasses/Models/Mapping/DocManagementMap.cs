using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class DocManagementMap : EntityTypeConfiguration<DocManagement>
    {
        public DocManagementMap()
        {

            // Primary Key
            this.HasKey(t => t.DocId);

            // Properties
            //this.Property(t => t.DocId)
            // .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.DocTitle)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.DocUrl)
                .IsRequired()
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("DOCS_MANAGEMENT");
            this.Property(t => t.WebPartId).HasColumnName("WEBPART_ID");
            this.Property(t => t.DocId).HasColumnName("DOCS_ID");
            this.Property(t => t.DocTitle).HasColumnName("DOCS_TITLE");
            this.Property(t => t.DocUrl).HasColumnName("DOCS_URL");
            this.Property(t => t.PublicGrant).HasColumnName("PUBLIC_GRANT");
            this.Property(t => t.Active).HasColumnName("ACTIVE");

            // Relationships
            this.HasRequired(t => t.Webpart)
                .WithMany(t => t.DocManagements)
                .HasForeignKey(d => d.WebPartId);

        }
    }
}
