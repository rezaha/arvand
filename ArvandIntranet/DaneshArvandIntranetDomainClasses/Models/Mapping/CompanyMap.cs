using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            // Primary Key
            this.HasKey(t => t.CoId);

            // Properties
            this.Property(t => t.NamePersian)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.NameLatin)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CoAbbr)
                .HasMaxLength(20);

            this.Property(t => t.ManagerNamePersian)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ManagerNameLatin)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.EstablishYear)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.OperationYear)
                .IsRequired()
                .HasMaxLength(8);

            this.Property(t => t.TelNo)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.FaxNo)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.EmailAddress)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.AddressPersian)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.AddressLatin)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Remark)
                .HasMaxLength(500);

            this.Property(t => t.DivisionSymbolLink)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("COMPANIES");
            this.Property(t => t.CoId).HasColumnName("CO_ID");
            this.Property(t => t.NamePersian).HasColumnName("NAME_PERSIAN");
            this.Property(t => t.NameLatin).HasColumnName("NAME_LATIN");
            this.Property(t => t.CoAbbr).HasColumnName("CO_ABBR");
            this.Property(t => t.CoType).HasColumnName("CO_TYPE");
            this.Property(t => t.CoOrder).HasColumnName("CO_ORDER");
            this.Property(t => t.ManagerNamePersian).HasColumnName("MANAGER_NAME_PERSIAN");
            this.Property(t => t.ManagerNameLatin).HasColumnName("MANAGER_NAME_LATIN");
            this.Property(t => t.EstablishYear).HasColumnName("ESTABLISH_YEAR");
            this.Property(t => t.OperationYear).HasColumnName("OPERATION_YEAR");
            this.Property(t => t.TelNo).HasColumnName("TEL_NO");
            this.Property(t => t.FaxNo).HasColumnName("FAX_NO");
            this.Property(t => t.EmailAddress).HasColumnName("EMAIL_ADDRESS");
            this.Property(t => t.AddressPersian).HasColumnName("ADDRESS_PERSIAN");
            this.Property(t => t.AddressLatin).HasColumnName("ADDRESS_LATIN");
            this.Property(t => t.EconomicalCode).HasColumnName("ECONOMICAL_CODE");
            this.Property(t => t.CoCity).HasColumnName("CO_CITY");
            this.Property(t => t.Active).HasColumnName("ACTIVE");
            this.Property(t => t.Remark).HasColumnName("REMARK");
            this.Property(t => t.SymbolStatus).HasColumnName("SYMBOL_STATUS");
            this.Property(t => t.DivisionSymbol).HasColumnName("DIVISION_SYMBOL");
            this.Property(t => t.DivisionSymbolLink).HasColumnName("DIVISION_SYMBOL_LINK");

            // Relationships
            this.HasRequired(t => t.City)
                .WithMany(t => t.Companies)
                .HasForeignKey(d => d.CoCity);
            this.HasRequired(t => t.CompanyTypes)
                .WithMany(t => t.COMPANIES)
                .HasForeignKey(d => d.CoType);

        }
    }
}
