using System;
using System.Collections.Generic;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class EmployeeBranch
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? BranchId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
