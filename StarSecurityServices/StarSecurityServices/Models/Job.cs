using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Job : BaseEntity
    {
        public Job()
        {
            Employees = new HashSet<Employee>();
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}
