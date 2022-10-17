using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class ClientService : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Client")]
        public int ClientId { get; set; }

        [Required]
        [DisplayName("Service Availed")]
        public int ServiceId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Service Service { get; set; }
    }
}
