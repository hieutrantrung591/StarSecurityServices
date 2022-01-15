using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarSecurityServices.Areas.Admin.ViewModels
{
    public class DashboardViewModel
    {
        public int BranchCount { get; set; }
        public int ClientCount { get; set; }
        public int ClientServiceCount { get; set; }
        public int DepartmentCount { get; set; }
        public int DivisionCount { get; set; }
        public int EmployeeCount { get; set; }
        public int EmployeeRoleCount { get; set; }
        public int JobCount { get; set; }
        public int RegionCount { get; set; }
        public int RoleCount { get; set; }
        public int ServiceCount { get; set; }
        public int VacancyCount { get; set; }
    }
}
