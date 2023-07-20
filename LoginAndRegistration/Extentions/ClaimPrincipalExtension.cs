using EasyForm.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace EasyForm.Extentions
{
    public static class ClaimPrincipalExtension
    {
        public static string GetClaimValue(this ClaimsPrincipal user, string claimType)
        {
            return user.Claims.FirstOrDefault(x => x.Type == claimType)?.Value;
        }

        public static List<Claim> GetClaims(this ClaimsPrincipal user, string claimType)
        {
            return user.Claims.Where(x => x.Type == claimType).ToList();
        }

        public static string GetName(this ClaimsPrincipal user) => user.FindFirst(ClaimTypes.Name)?.Value;

        public static bool IsAdmin(this ClaimsPrincipal user) => user.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == Constants.Admin);

        public static string GetEmail(this ClaimsPrincipal user) => user.FindFirst(ClaimTypes.Email)?.Value;
    }
}
