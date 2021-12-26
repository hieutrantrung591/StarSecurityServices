using System;
using System.Collections.Generic;

#nullable disable

namespace StarSecurityServices.Models
{
    public partial class Service
    {
        public Service()
        {
            ClientServices = new HashSet<ClientService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<ClientService> ClientServices { get; set; }
    }
}
