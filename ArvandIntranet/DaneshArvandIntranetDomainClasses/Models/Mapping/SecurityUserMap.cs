using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class SecurityUserMap : EntityTypeConfiguration<SecurityUsers>
    {
        public SecurityUserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UserPassword)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CreateDate)
                .IsRequired()
                .HasMaxLength(8);

            // Table & Column Mappings
            this.ToTable("SECURITY_USERS");
            this.Property(t => t.UserId).HasColumnName("USER_ID");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.FirstName).HasColumnName("FIRST_NAME");
            this.Property(t => t.LastName).HasColumnName("LAST_NAME");
            this.Property(t => t.UserAdmin).HasColumnName("USER_TYPE");
            this.Property(t => t.UserName).HasColumnName("USER_NAME");
            this.Property(t => t.UserPassword).HasColumnName("USER_PASSWORD");
            this.Property(t => t.UserLock).HasColumnName("USER_LOCK");
            this.Property(t => t.CreateDate).HasColumnName("CREATE_DATE");

            this.HasRequired(t => t.PlantDivision)
              .WithMany(t => t.SecurityUsers)
              .HasForeignKey(d => d.DivisionId);
        }
    }
}
