using System;
using System.Collections.Generic;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Vacancy
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Job Job { get; set; }
    }
}
