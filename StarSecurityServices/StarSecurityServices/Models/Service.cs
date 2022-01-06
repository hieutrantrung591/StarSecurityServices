using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Service : BaseEntity
    {
        public Service()
        {
            ClientServices = new HashSet<ClientService>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Division")]
        public int DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<ClientService> ClientServices { get; set; }
    }
}
