using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class PhonebookMap : EntityTypeConfiguration<Phonebook>
    {
        public PhonebookMap()
        {
            // Primary Key
            this.HasKey(t => t.PhonebookId);

            // Properties
            this.Property(t => t.PhonebookName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PhonebookEmail)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PhonebookFax)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PhonebookTel)
               .IsRequired()
               .HasMaxLength(50);

            this.Property(t => t.PhonebookPlant)
             .IsRequired()
             .HasMaxLength(100);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("PHONEBOOK");
            this.Property(t => t.DivisionId).HasColumnName("DIVISION_ID");
            this.Property(t => t.PhonebookEmail).HasColumnName("PHONEBOOK_EMAIL");
            this.Property(t => t.PhonebookFax).HasColumnName("PHONEBOOK_FAX");
            this.Property(t => t.PhonebookId).HasColumnName("PHONEBOOK_ID");
            this.Property(t => t.PhonebookName).HasColumnName("PHONEBOOK_NAME");
            this.Property(t => t.PhonebookPlant).HasColumnName("PHONEBOOK_PLANT");
            this.Property(t => t.PhonebookTel).HasColumnName("PHONEBOOK_TEL");
            this.Property(t => t.Remark).HasColumnName("REMARK");

            // Relationships
            this.HasRequired(t => t.PlantDivision)
                .WithMany(t => t.Phonebooks)
                .HasForeignKey(d => d.DivisionId);
        }
    }
}
