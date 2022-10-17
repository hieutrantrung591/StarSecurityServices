using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Division : BaseEntity
    {
        public Division()
        {
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
