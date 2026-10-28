using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class COMPLAINTMap : EntityTypeConfiguration<Complaint>
    {
        public COMPLAINTMap()
        {
            // Primary Key
            this.HasKey(t => t.COMPLAINT_ID);

            // Properties
            this.Property(t => t.SENDER_NAME)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SENDER_COMPANY)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SENDER_TEL)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SENDER_FAX)
                .HasMaxLength(50);

            this.Property(t => t.SENDER_EMAIL)
                .HasMaxLength(50);

            this.Property(t => t.DRAFT_ISSUE_DATE)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.DELIVERY_DATE)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.PRODUCT_NAME)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PRODUCT_GRADE)
                .HasMaxLength(50);

            this.Property(t => t.COMPLAINT_DESCRIPTION)
                .IsRequired();

            this.Property(t => t.REMARK)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("COMPLAINTS");
            this.Property(t => t.COMPLAINT_ID).HasColumnName("COMPLAINT_ID");
            this.Property(t => t.COMPLAINT_NO).HasColumnName("COMPLAINT_NO");
            this.Property(t => t.SENDER_NAME).HasColumnName("SENDER_NAME");
            this.Property(t => t.SENDER_COMPANY).HasColumnName("SENDER_COMPANY");
            this.Property(t => t.SENDER_TEL).HasColumnName("SENDER_TEL");
            this.Property(t => t.SENDER_FAX).HasColumnName("SENDER_FAX");
            this.Property(t => t.SENDER_EMAIL).HasColumnName("SENDER_EMAIL");
            this.Property(t => t.SUBSCRIPTION_NO).HasColumnName("SUBSCRIPTION_NO");
            this.Property(t => t.DRAFT_NO).HasColumnName("DRAFT_NO");
            this.Property(t => t.DRAFT_ISSUE_DATE).HasColumnName("DRAFT_ISSUE_DATE");
            this.Property(t => t.DELIVERY_DATE).HasColumnName("DELIVERY_DATE");
            this.Property(t => t.PRODUCT_ID).HasColumnName("PRODUCT_ID");
            this.Property(t => t.PRODUCT_NAME).HasColumnName("PRODUCT_NAME");
            this.Property(t => t.PRODUCT_GRADE).HasColumnName("PRODUCT_GRADE");
            this.Property(t => t.COMPLAINT_TYPE).HasColumnName("COMPLAINT_TYPE");
            this.Property(t => t.COMPLAINT_DESCRIPTION).HasColumnName("COMPLAINT_DESCRIPTION");
            this.Property(t => t.RECIEVER_ID).HasColumnName("RECIEVER_ID");
            this.Property(t => t.COMPLAINT_READ).HasColumnName("COMPLAINT_READ");
            this.Property(t => t.ACTIVE).HasColumnName("ACTIVE");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
