using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class EmployeeBranch : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Employee")]
        public int? EmployeeId { get; set; }

        [Required]
        [DisplayName("Branch")]
        public int? BranchId { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
