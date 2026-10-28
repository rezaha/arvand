using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class HouseCooperative
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime RegisterTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NationalId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int EmpType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CooperativeLocation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MobileNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TelNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WorkLocation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long PersonNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Remark { get; set; }
    }

    public enum EmployType
    {
        [Display(Name = "نامشخص")]
        [Description("نامشخص")]
        Unknown = 0,
        [Display(Name = "رسمی")]
        [Description("رسمی")]
        Official = 1,
        [Display(Name = "مدت معین")]
        [Description("مدت معین")]
        SpecifiedPeriod = 2,
        [Display(Name = "مدت موقت")]
        [Description("مدت موقت")]
        TemporaryPeriod = 3,
        [Display(Name = "پیمانکار")]
        [Description("پیمانکار")]
        Contractor = 5
    }

    public enum CooperativeLocation
    {
        [Display(Name = "نامشخص")]
        [Description("نامشخص")]
        Unknown = 0,
        [Display(Name = "جنوب")]
        [Description("جنوب")]
        South = 1,
        [Display(Name = "شمال")]
        [Description("شمال")]
        North = 2
    }
}
