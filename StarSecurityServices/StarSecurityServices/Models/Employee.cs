using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Employee : BaseEntity
    {
        public Employee()
        {
            Clients = new HashSet<Client>();
            EmployeeBranches = new HashSet<EmployeeBranch>();
            EmployeeRoles = new HashSet<EmployeeRole>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        public int Grade { get; set; }

        [Required]
        public string Achievement { get; set; }

        [Required]
        [DisplayName("Job")]
        public int JobId { get; set; }

        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Job Job { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<EmployeeBranch> EmployeeBranches { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
