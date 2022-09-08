// =============================
// Email:  info@binaryblox.com
// www.binaryblox.com/templates
// =============================
 
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks; 

using Microsoft.AspNetCore.Authorization;
  
using BinaryBlox.SDK.Constants;

using {{cookiecutter.project_api_pkg}}.Constants;

#pragma warning disable 1591
namespace {{cookiecutter.project_api_pkg}}.Identity.Authorization
{
    public class AssignApiRolesAuthorizationRequirement : IAuthorizationRequirement { }

    public class AssignApiRolesAuthorizationHandler : AuthorizationHandler<AssignApiRolesAuthorizationRequirement, Tuple<string[], string[]>>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AssignApiRolesAuthorizationRequirement requirement, Tuple<string[], string[]> newAndCurrentRoles)
        {
            if (!GetIsRolesChanged(newAndCurrentRoles.Item1, newAndCurrentRoles.Item2))
            {
                context.Succeed(requirement);
            }
            else if (context.User.HasClaim(ClaimConstants.Permission, ApiPermissions.Assign_Api_Roles))
            {
                if (context.User.HasClaim(ClaimConstants.Permission, ApiPermissions.View_Api_Roles)) // If user has View_Api_Roles permission, then he can assign any roles
                    context.Succeed(requirement);

                else if (GetIsUserInAllAddedRoles(context.User, newAndCurrentRoles.Item1, newAndCurrentRoles.Item2)) // Else user can only assign roles they're part of
                    context.Succeed(requirement);
            } 
            return Task.CompletedTask;
        }


        private bool GetIsRolesChanged(string[] newRoles, string[] currentRoles)
        {
            if (newRoles == null)
                newRoles = new string[] { };

            if (currentRoles == null)
                currentRoles = new string[] { };

            bool roleAdded = newRoles.Except(currentRoles).Any();
            bool roleRemoved = currentRoles.Except(newRoles).Any();

            return roleAdded || roleRemoved;
        }


        private bool GetIsUserInAllAddedRoles(ClaimsPrincipal contextUser, string[] newRoles, string[] currentRoles)
        {
            if (newRoles == null)
                newRoles = new string[] { };

            if (currentRoles == null)
                currentRoles = new string[] { };


            var addedRoles = newRoles.Except(currentRoles);

            return addedRoles.All(role => contextUser.IsInRole(role));
        }
    }
}