using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Branch : BaseEntity
    {
        public Branch()
        {
            EmployeeBranches = new HashSet<EmployeeBranch>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Description { get; set; }
        public virtual ICollection<EmployeeBranch> EmployeeBranches { get; set; }
    }
}
