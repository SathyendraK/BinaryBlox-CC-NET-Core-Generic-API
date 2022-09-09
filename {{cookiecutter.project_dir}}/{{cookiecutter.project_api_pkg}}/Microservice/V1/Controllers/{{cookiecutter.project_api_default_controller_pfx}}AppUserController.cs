using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;  
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
 
using BinaryBlox.SDK.Data.Context;
using BinaryBlox.SDK.Constants; 
using BinaryBlox.SDK.Data.Models.Entity;
using BinaryBlox.SDK.Data.ViewModels.Entity;
using BinaryBlox.SDK.Data.Respository;
using BinaryBlox.SDK.Web.Controllers;
using BinaryBlox.SDK.Web.Http.Request;
using BinaryBlox.SDK.Web.Http.Response;  

using Serilog;

using Swashbuckle.AspNetCore.Annotations; 
using IdentityServer4.AccessTokenValidation; 

using {{cookiecutter.project_api_pkg}}.DAL;
using {{cookiecutter.project_api_pkg}}.ViewModels;
using {{cookiecutter.project_api_pkg}}.Repository;

#pragma warning disable 1591
namespace {{cookiecutter.project_api_pkg}}.Microservice.V1.Controllers
{
   {
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class {{cookiecutter.project_api_default_controller_pfx}}AppUserController : BxDynamicRestController<AppUser,
        AppUserViewModel,
        AppUserRequest,
        AppUserResponse, Guid>
    {
        public const string API_CONTROLLER_TAG = BinaryBlox.SDK.Account.Constants.OpenApiTagConstants.Account_ApiScope;
        
        /// <summary>
        /// 
        /// </summary> 
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        /// <remarks>
        /// Generic CRUD Controller for given TEntity and TDto 
        /// </remarks>
        public {{cookiecutter.project_api_default_controller_pfx}}AppUserController(AppUserRepository repository, IMapper mapper) : base(Log.Logger, repository, mapper) { }

        #region Overriding Methods
        // NOTE: Override example(s)
        /// <summary>
        /// Get list of <c>AppUser</c> entities
        /// </summary>
        /// <param name="request">Request object <c>IBxRequest</c></param>
        /// <returns>
        /// Response object <c>IBxResponse</c>
        /// </returns>
        /// <value></value>
        [SwaggerOperation(
            Summary = "POST AppUserRequest",
            Description = ApiWebActionOpenAPI.BX_GET_ALL,
            Tags = new[] { API_CONTROLLER_TAG })]
        override public async Task<ActionResult<AppUserResponse>> GetAll([FromBody] AppUserRequest request) => await base.GetAll(request);

        /// <summary>
        /// Get entity of type <c>AppUser</c> for given Id.
        /// </summary>
        /// <param name="request">Request object <c>IBxRequest</c></param>
        /// <returns>
        /// Response object <c>IBxResponse</c>
        /// </returns>
        /// <value></value>
        [SwaggerOperation(
            Summary = "POST AppUserRequest",
            Description = ApiWebActionOpenAPI.BX_GET,
            Tags = new[] { API_CONTROLLER_TAG })]
        override public async Task<ActionResult<AppUserResponse>> Get([FromBody] AppUserRequest request) => await base.Get(request);


        /// <summary>
        /// Update entity of type <c>AppUser</c> for given Id.
        /// </summary>
        /// <param name="request">Request object <c>IBxRequest</c></param>
        /// <returns>
        /// Response object <c>IBxResponse</c>
        /// </returns>
        /// <value></value>
        [SwaggerOperation(
            Summary = "POST AppUserRequest",
            Description = ApiWebActionOpenAPI.BX_UPDATE,
            Tags = new[] { API_CONTROLLER_TAG })]
        override public async Task<ActionResult<AppUserResponse>> Update([FromBody] AppUserRequest request) => await base.Update(request);

        /// <summary>
        /// Add entity of type <c>AppUser</c>.
        /// </summary>
        /// <param name="request">Request object <c>IBxRequest</c></param>
        /// <returns>
        /// Response object <c>IBxResponse</c>
        /// </returns>
        /// <value></value>
        [SwaggerOperation(
            Summary = "POST AppUserRequest",
            Description = ApiWebActionOpenAPI.BX_CREATE,
            Tags = new[] { API_CONTROLLER_TAG })]
        override public async Task<ActionResult<AppUserResponse>> Add([FromBody] AppUserRequest request) => await base.Add(request);

        /// <summary>
        /// Delete(soft) entity of type <c>AppUser</c> for given Id.
        /// </summary>
        /// <param name="request">Request object <c>IBxRequest</c></param>
        /// <returns>
        /// Response object <c>IBxResponse</c>
        /// </returns>
        /// <value></value>
        [SwaggerOperation(
            Summary = "POST AppUserRequest",
            Description = ApiWebActionOpenAPI.BX_DELETE,
            Tags = new[] { API_CONTROLLER_TAG })]
        [ApiExplorerSettings(IgnoreApi = BinaryBlox.SDK.Constants.OpenApiMethodConstants.IGNORE_DELETE)]
        override public async Task<ActionResult<AppUserResponse>> Delete([FromBody] AppUserRequest request) => await base.Delete(request);
        #endregion
    }

    public class AppUserResponse : BxResponse<AppUserViewModel, int> { }
    public class AppUserRequest : BxRequest<AppUserViewModel, int> { }


}

namespace {{cookiecutter.project_api_pkg}}.ViewModels
{

#pragma warning disable 1591

 /// <summary>
    /// 
    /// </summary> 
    public class AppUser :  BxAuditableEntityType<Guid>, IBxAttribOptions
    {  
        public AppUser(): base() {}

        public bool Enabled { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public bool Email { get; set; } 
    } 

    public class AppUserViewModel : BxEntityDto<Guid>, IAppUser
    {
        public bool Enabled { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public bool Email { get; set; } 
    }
}

namespace {{cookiecutter.project_api_pkg}}.Repository
{
    public class AppUserRepository : BxRepository<AppUser, BxIdentityDbContext>
    {
        public AppUserRepository(BxIdentityDbContext context) : base(context) { }
    }
}

#pragma warning restore 1591
