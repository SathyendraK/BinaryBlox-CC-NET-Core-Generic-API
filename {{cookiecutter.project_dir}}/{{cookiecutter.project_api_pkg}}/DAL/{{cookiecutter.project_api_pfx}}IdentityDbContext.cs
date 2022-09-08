using System;
using Microsoft.EntityFrameworkCore; 
using BinaryBlox.SDK.Data.Context; 

#pragma warning disable 1591
namespace {{cookiecutter.project_api_pkg}}.DAL
{ 
  
    /// <summary>
    /// 
    /// </summary>
    public partial class {{cookiecutter.project_api_pfx}}IdentityDbContext : BxIdentityDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public {{cookiecutter.project_api_pfx}}IdentityDbContext(DbContextOptions<{{cookiecutter.project_api_pfx}}IdentityDbContext> options) : base(options) { }
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}