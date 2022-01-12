using StarSecurityServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarSecurityServices.Areas.Customer.ViewModels
{
    public class BranchRegionViewModel
    {
        public IEnumerable<Branch> Branches { get; set; }
        public IEnumerable<Region> Regions { get; set; }
    }
}
