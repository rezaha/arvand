using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class SecurityFormMap : EntityTypeConfiguration<SecurityForms>
    {
        public SecurityFormMap()
        {
            // Primary Key
            this.HasKey(t => t.FormPermisionId);

            // Properties
            this.Property(t => t.FormTag)
                .IsRequired()
                .HasMaxLength(700);

            this.Property(t => t.FormName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.FormTitle)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.TabName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.TabTitle)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("SECURITY_FORMS");
            this.Property(t => t.FormPermisionId).HasColumnName("FORM_PERMISSION");
            this.Property(t => t.ListOrder).HasColumnName("LIST_ORDER");
            this.Property(t => t.SubSystemId).HasColumnName("SUBSYSTEM_ID");
            this.Property(t => t.FormTag).HasColumnName("FORM_TAG");
            this.Property(t => t.FormName).HasColumnName("FORM_NAME");
            this.Property(t => t.FormTitle).HasColumnName("FORM_TITLE");
            this.Property(t => t.TabNo).HasColumnName("TAB_NO");
            this.Property(t => t.TabName).HasColumnName("TAB_NAME");
            this.Property(t => t.TabTitle).HasColumnName("TAB_TITLE");
            this.Property(t => t.InsertRecord).HasColumnName("INSERT_RECORD");
            this.Property(t => t.DeleteRecord).HasColumnName("DELETE_RECORD");
            this.Property(t => t.UpdateRecord).HasColumnName("UPDATE_RECORD");
            this.Property(t => t.SearchRecord).HasColumnName("SEARCH_RECORD");
            this.Property(t => t.PrintRecord).HasColumnName("PRINT_RECORD");
            this.Property(t => t.ApproveAction).HasColumnName("APPROVE_ACTION");
            this.Property(t => t.EtcAction).HasColumnName("ETC_ACTION");
            this.Property(t => t.EtcAction2).HasColumnName("ETC2_ACTION");
        }
    }
}
