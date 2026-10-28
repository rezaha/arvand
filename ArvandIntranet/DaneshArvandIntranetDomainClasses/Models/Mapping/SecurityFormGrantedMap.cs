using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class SecurityFormGrantedMap : EntityTypeConfiguration<SecurityFormsGranted>
    {
        public SecurityFormGrantedMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.FormPermission });

            // Properties
            //this.Property(t => t.UserId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //this.Property(t => t.FormPermission)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("SECURITY_FORMS_GRANTED");
            this.Property(t => t.UserId).HasColumnName("USER_ID");
            this.Property(t => t.FormPermission).HasColumnName("FORM_PERMISSION");
            this.Property(t => t.InsertRecord).HasColumnName("INSERT_RECORD");
            this.Property(t => t.DeleteRecord).HasColumnName("DELETE_RECORD");
            this.Property(t => t.UpdateRecord).HasColumnName("UPDATE_RECORD");
            this.Property(t => t.SearchRecord).HasColumnName("SEARCH_RECORD");
            this.Property(t => t.PrintRecord).HasColumnName("PRINT_RECORD");
            this.Property(t => t.ApproveAction).HasColumnName("APPROVE_ACTION");
            this.Property(t => t.EtcAction).HasColumnName("ETC_ACTION");
            this.Property(t => t.EtcAction2).HasColumnName("ETC2_ACTION");

            // Relationships
            this.HasRequired(t => t.SecurityForm)
                .WithMany(t => t.SecurityFormGranteds)
                .HasForeignKey(d => d.FormPermission);
            this.HasRequired(t => t.SecurityUser)
                .WithMany(t => t.SecurityFormGranted)
                .HasForeignKey(d => d.UserId);

        }
    }
}
