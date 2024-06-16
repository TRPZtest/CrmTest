using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace CrmTest.Helpers
{
    public static class UserHelpers
    {
        public static int? GetEmployeeId(this ClaimsPrincipal user)
        {
            var claim = user?.Claims.FirstOrDefault(x => x.Type == "EmployeeId");

            if (claim == null)
                return null;
            else           
                return Int32.Parse(claim.Value);                 
        }
    }
}
