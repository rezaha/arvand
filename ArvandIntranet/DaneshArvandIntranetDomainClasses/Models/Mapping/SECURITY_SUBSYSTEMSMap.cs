using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class SECURITY_SUBSYSTEMSMap : EntityTypeConfiguration<SecuritySubsystems>
    {
        public SECURITY_SUBSYSTEMSMap()
        {
            // Primary Key
            this.HasKey(t => t.SUBSYSTEM_ID);

            // Properties
            //this.Property(t => t.SUBSYSTEM_ID)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SUBSYSTEM_NAME)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.REMARK)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("SECURITY_SUBSYSTEMS");
            this.Property(t => t.SUBSYSTEM_ID).HasColumnName("SUBSYSTEM_ID");
            this.Property(t => t.SUBSYSTEM_NAME).HasColumnName("SUBSYSTEM_NAME");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
