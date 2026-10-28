using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class COMPANY_TYPESMap : EntityTypeConfiguration<CompanyTypes>
    {
        public COMPANY_TYPESMap()
        {
            // Primary Key
            this.HasKey(t => t.CoTypeId);

            // Properties
            this.Property(t => t.CoTypeDes)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("COMPANY_TYPES");
            this.Property(t => t.CoTypeId).HasColumnName("CO_TYPE_ID");
            this.Property(t => t.CoTypeDes).HasColumnName("CO_TYPE_DES");
        }
    }
}
