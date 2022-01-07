using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Region : BaseEntity
    {
        public Region()
        {
            Branches = new HashSet<Branch>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
    }
}
