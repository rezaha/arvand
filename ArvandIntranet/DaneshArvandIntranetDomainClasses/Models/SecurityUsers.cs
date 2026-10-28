using System;
using System.Collections.Generic;

namespace Danesh.ArvandIntranet.DomainClasses.Models
{
    public class SecurityUsers
    {
      
        public int UserId { get; set; }
        public int DivisionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool UserAdmin { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool UserLock { get; set; }
        public string CreateDate { get; set; }
        public virtual PlantDivisions PlantDivision { get; set; }
        public virtual ICollection<SecurityFormsGranted> SecurityFormGranted { get; set; }
    }
}
