// =============================
// Email:  info@binaryblox.com
// www.binaryblox.com/templates
// =============================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

#pragma warning disable 1591
namespace {{cookiecutter.project_api_pkg}}.Identity.Authorization
{
    public static class ApiPermissions
    { 
        public static ReadOnlyCollection<ApiPermission> AllPermissions;

        public const string ApiName = "{{cookiecutter.project_api_name}}"; 
        public const string ApiPrefixName = "{{cookiecutter.project_api_const_pfx}}"; 

        //-------------------------------------
        // {{cookiecutter.project_api_name}} User & Role Management Permissions
        //-------------------------------------
        public const string ApiUsersPermissionGroupName = ApiName + " API User Permissions";
        public static ApiPermission View_Users = new ApiPermission($"View {ApiName} API Users", $"{ApiPrefixName.ToLower()}.users.view", ApiUsersPermissionGroupName, $"{ApiName} permission to view other {ApiName} API users details");
        public static ApiPermission Manage_Users = new ApiPermission($"Manage {ApiName} API Users", $"{ApiPrefixName.ToLower()}.users.manage", ApiUsersPermissionGroupName, $"{ApiName} permission to create, delete and modify {ApiName} API users details");

        public const string ApiRolesPermissionGroupName = ApiName + " API Role Permissions";
        public static ApiPermission View_Api_Roles = new ApiPermission($"View {ApiName} API Roles", $"{ApiPrefixName.ToLower()}.roles.view", ApiRolesPermissionGroupName, $"{ApiName} permission to view available {ApiName} API roles");
        public static ApiPermission Manage_Roles = new ApiPermission($"Manage {ApiName} API Roles", $"{ApiPrefixName.ToLower()}.roles.manage", ApiRolesPermissionGroupName, $"{ApiName} permission to create, delete and modify {ApiName} API roles");
        public static ApiPermission Assign_Api_Roles = new ApiPermission($"Assign {ApiName} API Roles", $"{ApiPrefixName.ToLower()}.roles.assign", ApiRolesPermissionGroupName, $"{ApiName} permission to assign roles to {ApiName} API users");
         
        static ApiPermissions()
        {
            List<ApiPermission> allPermissions = new List<ApiPermission>()
            {
                View_Users,
                Manage_Users, 
                View_Api_Roles,
                Manage_Roles,
                Assign_Api_Roles  
            };

            AllPermissions = allPermissions.AsReadOnly();
        }

        public static ApiPermission GetPermissionByName(string permissionName) => AllPermissions.Where(p => p.Name == permissionName).SingleOrDefault();
        public static ApiPermission GetPermissionByValue(string permissionValue) => AllPermissions.Where(p => p.Value == permissionValue).SingleOrDefault();
        public static string[] GetAllPermissionValues() => AllPermissions.Select(p => p.Value).ToArray(); 
        public static string[] GetAdministrativePermissionValues() => new string[] { Manage_Users, Manage_Roles, Assign_Api_Roles };
    }
 
    public class ApiPermission
    {
        public ApiPermission() { }

        public ApiPermission(string name, string value, string groupName, string description = null)
        {
            Name = name;
            Value = value;
            GroupName = groupName;
            Description = description;
        }
 
        public string Name { get; set; }
        public string Value { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
 
        public override string ToString() => Value; 
        public static implicit operator string(ApiPermission permission) => permission.Value;
    }
}
