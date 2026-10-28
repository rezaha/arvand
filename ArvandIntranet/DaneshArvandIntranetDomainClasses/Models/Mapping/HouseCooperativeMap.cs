using System.Data.Entity.ModelConfiguration;

namespace Danesh.ArvandIntranet.DomainClasses.Models.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class HouseCooperativeMap : EntityTypeConfiguration<HouseCooperative>
    {
        /// <summary>
        /// 
        /// </summary>
        public HouseCooperativeMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.FatherName)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.NationalId)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            Property(t => t.MobileNo)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            Property(t => t.TelNo)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            Property(t => t.WorkLocation)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.Remark)
                .HasMaxLength(500);

            // Table & Column Mappings
            ToTable("HOUSE_COOPERATIVE");
            Property(t => t.Id).HasColumnName("ID");
            Property(t => t.RegisterTime).HasColumnName("REGISTER_TIME");
            Property(t => t.FirstName).HasColumnName("FIRST_NAME");
            Property(t => t.LastName).HasColumnName("LAST_NAME");
            Property(t => t.FatherName).HasColumnName("FATHER_NAME");
            Property(t => t.NationalId).HasColumnName("NATIONAL_ID");
            Property(t => t.EmpType).HasColumnName("EMP_TYPE");
            Property(t => t.CooperativeLocation).HasColumnName("COOPERATIVE_LOCATION");
            Property(t => t.MobileNo).HasColumnName("MOBILE_NO");
            Property(t => t.TelNo).HasColumnName("TEL_NO");
            Property(t => t.WorkLocation).HasColumnName("WORK_LOCATION");
            Property(t => t.PersonNo).HasColumnName("PERSON_NO");
            Property(t => t.Remark).HasColumnName("REMARK");
        }
    }
}
