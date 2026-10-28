using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class TENDERS_TYPESMap : EntityTypeConfiguration<TendersTypes>
    {
        public TENDERS_TYPESMap()
        {
            // Primary Key
            this.HasKey(t => t.TYPE_ID);

            // Properties
            this.Property(t => t.TYPE_NAME)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.REMARK)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("TENDERS_TYPES");
            this.Property(t => t.TYPE_ID).HasColumnName("TYPE_ID");
            this.Property(t => t.TYPE_NAME).HasColumnName("TYPE_NAME");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
