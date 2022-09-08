#pragma warning disable 1591
namespace {{cookiecutter.project_api_pkg}}.Constants
{ 
    public class ApiEndpointConstants
    { 
        // {{cookiecutter.project_api_name}} - Endpoints
        public const string {{cookiecutter.project_api_const_pfx|upper}}_ENDPOINT = "https://binaryblox-account-api.azurewebsites.net";
        public const string {{cookiecutter.project_api_const_pfx|upper}}_ENDPOINT_REDIRECT_ENDPOINT= "https://binaryblox-account-api.azurewebsites.net/oauth2-redirect.htm";
        public const string {{cookiecutter.project_api_const_pfx|upper}}_ENDPOINT_DEV = "http://localhost:5007";
        public const string {{cookiecutter.project_api_const_pfx|upper}}_REDIRECT_ENDPOINT_DEV  = "http://localhost:5007/oauth2-redirect.htm";
    } 
}