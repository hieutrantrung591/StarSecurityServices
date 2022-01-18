using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Employee : BaseEntity
    {
        public Employee()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password!")]
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

        [Required]
        [DisplayName("Branch")]
        public int BranchId { get; set; }

        [Required]
        [DisplayName("Role")]
        public int RoleId { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Department Department { get; set; }
        public virtual Job Job { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
