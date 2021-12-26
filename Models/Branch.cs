using System;
using System.Collections.Generic;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Branch
    {
        public Branch()
        {
            EmployeeBranches = new HashSet<EmployeeBranch>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<EmployeeBranch> EmployeeBranches { get; set; }
    }
}
