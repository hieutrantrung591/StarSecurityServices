using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Branch : BaseEntity
    {
        public Branch()
        {
            Employees = new HashSet<Employee>();
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("Region")]
        public int RegionId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:0.0#####}", ApplyFormatInEditMode = true)]
        public decimal Latitude { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:0.0#####}", ApplyFormatInEditMode = true)]
        public decimal Longtitude { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public String GetDetailLatLong()
        {
            return $"[{Latitude.ToString().Replace(",", ".")}, {Longtitude.ToString().Replace(",", ".")}]";
        }
    }
}
