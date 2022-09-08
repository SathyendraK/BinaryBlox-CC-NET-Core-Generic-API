using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

using BinaryBlox.SDK.Utils;
using BinaryBlox.SDK.Constants;

using {{cookiecutter.project_api_pkg}}.Constants;

#pragma warning disable 1591
namespace {{cookiecutter.project_api_pkg}}.Identity.Authorization
{
    public class ApiUserAccountAuthorizationRequirement : IAuthorizationRequirement
    {
        public ApiUserAccountAuthorizationRequirement(string operationName)
        {
            this.OperationName = operationName;
        }
 
        public string OperationName { get; private set; }
    }
 
    public class ViewApiUserAuthorizationHandler : AuthorizationHandler<ApiUserAccountAuthorizationRequirement, string>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiUserAccountAuthorizationRequirement requirement, string targetUserId)
        {
            if (context.User == null || requirement.OperationName != ApiAccountManagementOperations.ReadOperationName)
                return Task.CompletedTask;

            if (context.User.HasClaim(ClaimConstants.Permission, ApiPermissions.View_Users) || GetIsSameUser(context.User, targetUserId))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
 
        private bool GetIsSameUser(ClaimsPrincipal user, string targetUserId)
        {
            if (string.IsNullOrWhiteSpace(targetUserId))
                return false;

            return CoreUtilities.GetUserId(user) == targetUserId;
        }
    }
 
    public class ManageApiUserAuthorizationHandler : AuthorizationHandler<ApiUserAccountAuthorizationRequirement, string>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiUserAccountAuthorizationRequirement requirement, string targetUserId)
        {
            if (context.User == null ||
                (requirement.OperationName != ApiAccountManagementOperations.CreateOperationName &&
                 requirement.OperationName != ApiAccountManagementOperations.UpdateOperationName &&
                 requirement.OperationName != ApiAccountManagementOperations.DeleteOperationName))
                return Task.CompletedTask;

            if (context.User.HasClaim(ClaimConstants.Permission, ApiPermissions.Manage_Users) || GetIsSameUser(context.User, targetUserId))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
 
        private bool GetIsSameUser(ClaimsPrincipal user, string targetUserId)
        {
            if (string.IsNullOrWhiteSpace(targetUserId))
                return false;

            return CoreUtilities.GetUserId(user) == targetUserId;
        }
    }
}