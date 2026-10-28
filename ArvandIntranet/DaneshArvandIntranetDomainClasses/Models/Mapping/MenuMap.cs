using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            // Primary Key
            this.HasKey(t => t.MenuId);

            // Properties
            this.Property(t => t.NamePersian)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.NameLatin)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.MenuLinkPersian)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.MenuLinkLatin)
                .IsRequired()
                .HasMaxLength(2000);

            this.Property(t => t.MenuIconLink)
                .HasMaxLength(2000);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("MENUS");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.MenuId).HasColumnName("MENU_ID");
            this.Property(t => t.MenuNo).HasColumnName("MENU_NO");
            this.Property(t => t.ShowStatus).HasColumnName("SHOW_STATUS");
            this.Property(t => t.NamePersian).HasColumnName("NAME_PERSIAN");
            this.Property(t => t.NameLatin).HasColumnName("NAME_LATIN");
            this.Property(t => t.LinkActive).HasColumnName("LINK_ACTIVE");
            this.Property(t => t.MenuLinkPersian).HasColumnName("MENU_LINK_PERSIAN");
            this.Property(t => t.MenuLinkLatin).HasColumnName("MENU_LINK_LATIN");
            this.Property(t => t.MenuLevel).HasColumnName("MENU_LEVEL");
            this.Property(t => t.MenuOrder).HasColumnName("MENU_ORDER");
            this.Property(t => t.MenuParent).HasColumnName("MENU_PARANT");
            this.Property(t => t.ResultStatus).HasColumnName("RESULT_STATUS");
            this.Property(t => t.IconStatus).HasColumnName("ICON_STATUS");
            this.Property(t => t.MenuIconLink).HasColumnName("MENU_ICON_LINK");
            this.Property(t => t.Active).HasColumnName("ACTIVE");
            this.Property(t => t.Remark).HasColumnName("REMARK");
            this.HasOptional(t => t.Parent)
                .WithMany()
                .HasForeignKey(t => t.MenuParent);
        }
    }
}
