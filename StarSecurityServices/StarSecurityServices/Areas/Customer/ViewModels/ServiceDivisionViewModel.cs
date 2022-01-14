using StarSecurityServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarSecurityServices.Areas.Customer.ViewModels
{
    public class ServiceDivisionViewModel
    {
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Division> Divisions { get; set; }
    }
}
