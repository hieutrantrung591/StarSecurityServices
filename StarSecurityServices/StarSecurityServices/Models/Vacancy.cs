using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Vacancy : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Job")]
        public int JobId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Number { get; set; }

        public virtual Job Job { get; set; }
    }
}
