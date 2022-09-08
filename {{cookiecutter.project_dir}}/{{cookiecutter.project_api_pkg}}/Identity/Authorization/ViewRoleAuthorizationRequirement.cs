using System.Collections.Generic;
using System.Security.Claims; 
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

using Serilog; 

using BinaryBlox.SDK.Constants;

using {{cookiecutter.project_api_pkg}}.Constants;

#pragma warning disable 1591
namespace {{cookiecutter.project_api_pkg}}.Identity.Authorization
{
    public class ViewApiRoleAuthorizationRequirement : IAuthorizationRequirement { }
 
    public class ViewApiRoleAuthorizationHandler : AuthorizationHandler<ViewApiRoleAuthorizationRequirement, string>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ViewApiRoleAuthorizationRequirement requirement, string roleName)
        {
            if (context.User == null)
                return Task.CompletedTask;

            // Log.Information($"ViewApiRoleAuthorizationHandler");
            // foreach (Claim claim in context.User.Claims)
            // { 
            //     Log.Information($"Claim info: {claim.ToString()}");
            // } 
 
            if (context.User.HasClaim(ClaimConstants.Permission, ApiPermissions.View_Api_Roles) || context.User.IsInRole(roleName))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
