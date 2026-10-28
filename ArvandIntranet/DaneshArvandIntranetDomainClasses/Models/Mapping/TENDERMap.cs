using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class TENDERMap : EntityTypeConfiguration<Tender>
    {
        public TENDERMap()
        {
            // Primary Key
            this.HasKey(t => t.TENDER_ID);

            // Properties
            this.Property(t => t.TENDER_NO)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TENDER_DATE)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.TENDER_TITLE)
                .IsRequired();

            this.Property(t => t.TENDER_CONTENT)
                .IsRequired();

            this.Property(t => t.SHOW_DATE)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.EXPIRE_DATE)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.SELL_FROM_DATE)
                .HasMaxLength(8);

            this.Property(t => t.SELL_TO_DATE)
                .HasMaxLength(8);

            this.Property(t => t.DELIVER_DATE)
                .HasMaxLength(8);

            this.Property(t => t.POCKETS_OPENING_DATE)
                .HasMaxLength(8);

            this.Property(t => t.POCKETS_OPENING_TIME)
                .HasMaxLength(5);

            this.Property(t => t.POCKETS_OPENING_LOCATION)
                .HasMaxLength(2000);

            this.Property(t => t.TENDER_FILE_LINK)
                .HasMaxLength(2000);

            this.Property(t => t.INSERT_DATE)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.INSERT_TIME)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.REMARK)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("TENDERS");
            this.Property(t => t.DIVISION_ID).HasColumnName("DIVISION_ID");
            this.Property(t => t.TENDER_ID).HasColumnName("TENDER_ID");
            this.Property(t => t.TENDER_TYPE).HasColumnName("TENDER_TYPE");
            this.Property(t => t.TENDER_NO).HasColumnName("TENDER_NO");
            this.Property(t => t.TENDER_DATE).HasColumnName("TENDER_DATE");
            this.Property(t => t.TENDER_STEPS).HasColumnName("TENDER_STEPS");
            this.Property(t => t.TENDER_TITLE).HasColumnName("TENDER_TITLE");
            this.Property(t => t.TENDER_CONTENT).HasColumnName("TENDER_CONTENT");
            this.Property(t => t.TENDER_GROUP).HasColumnName("TENDER_GROUP");
            this.Property(t => t.SHOW_DATE).HasColumnName("SHOW_DATE");
            this.Property(t => t.EXPIRE_DATE).HasColumnName("EXPIRE_DATE");
            this.Property(t => t.SELL_FROM_DATE).HasColumnName("SELL_FROM_DATE");
            this.Property(t => t.SELL_TO_DATE).HasColumnName("SELL_TO_DATE");
            this.Property(t => t.SELL_PRICE).HasColumnName("SELL_PRICE");
            this.Property(t => t.DELIVER_DATE).HasColumnName("DELIVER_DATE");
            this.Property(t => t.POCKETS_OPENING_DATE).HasColumnName("POCKETS_OPENING_DATE");
            this.Property(t => t.POCKETS_OPENING_TIME).HasColumnName("POCKETS_OPENING_TIME");
            this.Property(t => t.POCKETS_OPENING_LOCATION).HasColumnName("POCKETS_OPENING_LOCATION");
            this.Property(t => t.POCKETS_OPENING_FREE).HasColumnName("POCKETS_OPENING_FREE");
            this.Property(t => t.NEWSPAPER_PRINT).HasColumnName("NEWSPAPER_PRINT");
            this.Property(t => t.TENDER_FILE_LINK).HasColumnName("TENDER_FILE_LINK");
            this.Property(t => t.TENDER_FILE).HasColumnName("TENDER_FILE");
            this.Property(t => t.INSERT_DATE).HasColumnName("INSERT_DATE");
            this.Property(t => t.INSERT_TIME).HasColumnName("INSERT_TIME");
            this.Property(t => t.USER_ID).HasColumnName("USER_ID");
            this.Property(t => t.ACTIVE).HasColumnName("ACTIVE");
            this.Property(t => t.REMARK).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.TENDERS_GROUPS)
                .WithMany(t => t.TENDERS)
                .HasForeignKey(d => d.TENDER_GROUP);
            this.HasRequired(t => t.TENDERS_TYPES)
                .WithMany(t => t.TENDERS)
                .HasForeignKey(d => d.TENDER_TYPE);

        }
    }
}
