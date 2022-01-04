using System;
using System.Collections.Generic;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Clients = new HashSet<Client>();
            EmployeeBranches = new HashSet<EmployeeBranch>();
            EmployeeRoles = new HashSet<EmployeeRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Qualification { get; set; }
        public int Grade { get; set; }
        public string Achievement { get; set; }
        public int JobId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Department Department { get; set; }
        public virtual Job Job { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<EmployeeBranch> EmployeeBranches { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
