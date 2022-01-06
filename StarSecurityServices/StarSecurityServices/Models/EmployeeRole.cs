using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class EmployeeRole : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Employee")]
        public int EmployeeId { get; set; }

        [Required]
        [DisplayName("Role")]
        public int RoleId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
    }
}
