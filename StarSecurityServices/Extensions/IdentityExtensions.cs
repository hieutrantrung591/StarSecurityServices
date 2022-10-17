using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace StarSecurityServices.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetEmployeeId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("EmployeeId");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetRoleId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("RoleId");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetSpecificClaim(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == claimType);
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}
