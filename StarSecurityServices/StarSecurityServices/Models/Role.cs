using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Role : BaseEntity
    {
        public Role()
        {
            EmployeeRoles = new HashSet<EmployeeRole>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
