using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class DocGrantMap : EntityTypeConfiguration<DocGrant>
    {
        public DocGrantMap()
        {
            // Primary Key
            this.HasKey(t => t.DocGrantId);

            // Properties

            //this.Property(t => t.DocGrantId)
            //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.UserDomain)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("DOCS_GRANTS");
            this.Property(t => t.DocGrantId).HasColumnName("DOCS_GRANT");
            this.Property(t => t.DocId).HasColumnName("DOCS_ID");
            this.Property(t => t.UserDomain).HasColumnName("USER_DOMAIN");

            // Relationships
            this.HasRequired(t => t.DocManagement)
                .WithMany(t => t.DocGrants)
                .HasForeignKey(d => d.DocId);

        }
    }
}
