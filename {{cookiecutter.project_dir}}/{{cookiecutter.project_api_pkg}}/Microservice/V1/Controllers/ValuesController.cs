using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;  
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using BinaryBlox.SDK.Configuration.ViewModels;
using BinaryBlox.SDK.Constants;
using BinaryBlox.SDK.Data.Models.Configuration;
using BinaryBlox.SDK.Data.Respository;
using BinaryBlox.SDK.Web.Controllers;
using BinaryBlox.SDK.Web.Http.Request;
using BinaryBlox.SDK.Web.Http.Response; 
using BinaryBlox.SDK.Configuration.Repository;
using BinaryBlox.SDK.Configuration.Constants;

using Serilog;

using Swashbuckle.AspNetCore.Annotations; 
using IdentityServer4.AccessTokenValidation; 

using {{cookiecutter.project_api_pkg}}.DAL;
using {{cookiecutter.project_api_pkg}}.Microservice.V1.ViewModels;

namespace {{cookiecutter.project_api_pkg}}.Microservice.V1.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    //[Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    [ApiController]
    [ApiVersion( "1.0" )]
    [ApiVersion( "0.9", Deprecated = true )]
    [Route( "api/[controller]" )]   
    public class ValuesController : ControllerBase
    {
        // GET api/values
        /// <summary>
        /// Get api values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        /// <summary>
        /// Get api values by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// Post api values
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        /// <summary>
        /// Update api values by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        /// Delete api values by Id.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
