using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Department : BaseEntity
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
