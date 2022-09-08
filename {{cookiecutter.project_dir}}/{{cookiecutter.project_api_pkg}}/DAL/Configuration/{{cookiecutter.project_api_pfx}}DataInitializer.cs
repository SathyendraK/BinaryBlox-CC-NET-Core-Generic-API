using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using BinaryBlox.SDK.Data.Interfaces.Context;
using BinaryBlox.SDK.Data.Interfaces.Entity;
using BinaryBlox.SDK.Data.Models.Configuration;
using BinaryBlox.SDK.Identity.Interfaces;

using Serilog; 

namespace {{cookiecutter.project_api_pkg}}.DAL.Configuration {

    /// <summary>
    /// 
    /// </summary>
    public class {{cookiecutter.project_api_pfx}}DataInitializer : IBxDataInitializer, IIdentityDataInitializer {
        private readonly IConfiguration _configuration;
        private readonly BxApplicationDbContext _context; 
        private readonly {{cookiecutter.project_api_pfx}}IdentityDbContext _identityDbContext;
        private readonly IAccountManager _accountManager;

        private bool _truncateOnSeed;
        private bool _bypassIfSeeded;

 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="identityDbContext"></param>
        /// <param name="accountManager"></param>
        /// <param name="configuration"></param>
        public {{cookiecutter.project_api_pfx}}DataInitializer(
            BxApplicationDbContext context,
            {{cookiecutter.project_api_pfx}}IdentityDbContext identityDbContext,
            IAccountManager accountManager,
            IConfiguration configuration) {
            _context = context;
            _identityDbContext = identityDbContext;
            _accountManager = accountManager;
            _configuration = configuration;

            _truncateOnSeed = _configuration.GetSection("DAL:TruncateOnSeed").Get<bool>();
            _bypassIfSeeded = _configuration.GetSection("DAL:BypassOnSeed").Get<bool>();
 
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {

            Log.Information($"START: Seeding {{cookiecutter.project_api_pfx}} API Data");

            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (_truncateOnSeed)
            {
                Log.Information($"PRELIM: Truncating Tables");
                await TruncateTables();
            }

            if (_bypassIfSeeded)
            {
                Log.Information($"BYPASS: Bypass on Seeding enabled.");
            }

            await CreateApiData();

            Log.Information($"END: Seeding {{cookiecutter.project_api_pfx}} API Data");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task SeedIdentityAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// IMPORTANT: This method cannot be in the base class because base context classes are different and will not serialize.
        /// </summary>
        /// <returns></returns>
        protected async Task CreateApiData()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns> 
        protected async Task TruncateTables()
        {

        } 
 
    }
}