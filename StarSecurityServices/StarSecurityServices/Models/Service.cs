using System;
using System.Collections.Generic;

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
        public string Name { get; set; }
        public int DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<ClientService> ClientServices { get; set; }
    }
}
