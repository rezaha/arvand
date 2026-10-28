using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class SystemHistoryMap : EntityTypeConfiguration<SystemHistory>
    {
        public SystemHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.HistoryId);

            // Properties
            this.Property(t => t.FormName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.TableName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ActionName)
               .IsRequired()
               .HasMaxLength(50);

            this.Property(t => t.LoginUserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ActionDate)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ActionTime)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.OsUser)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.OsName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.IpAddress)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BrowserType)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            this.Property(t => t.XmlDate)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SYSTEM_HISTORY");
            this.Property(t => t.HistoryId).HasColumnName("HISTORY_ID");
            this.Property(t => t.FormName).HasColumnName("FORM_NAME");
            this.Property(t => t.TableName).HasColumnName("TABLE_NAME");
            this.Property(t => t.ActionName).HasColumnName("ACTION_NAME");
            this.Property(t => t.LoginUserId).HasColumnName("LOGIN_USER_ID");
            this.Property(t => t.LoginUserName).HasColumnName("LOGIN_USER_NAME");
            this.Property(t => t.ActionDate).HasColumnName("ACTION_DATE");
            this.Property(t => t.ActionTime).HasColumnName("ACTION_TIME");
            this.Property(t => t.OsUser).HasColumnName("OS_USER");
            this.Property(t => t.OsName).HasColumnName("OS_NAME");
            this.Property(t => t.IpAddress).HasColumnName("IP_ADDRESS");
            this.Property(t => t.BrowserType).HasColumnName("BROWSER_TYPE");
            this.Property(t => t.ParentHistoryId).HasColumnName("PRE_HISTORY");
            this.Property(t => t.Remark).HasColumnName("REMARK");
            this.Property(t => t.XmlDate).HasColumnName("XML_DATE");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");

            // Relationships
            this.HasOptional(t => t.ParentHistory).WithMany(t => t.SystemHistorys).HasForeignKey(d => d.ParentHistoryId);
            this.HasOptional(t => t.PlantDivisions).WithMany(t => t.SystemHistorys).HasForeignKey(d => d.DivisionId);

        }
    }
}
