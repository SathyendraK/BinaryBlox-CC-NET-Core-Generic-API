using System.IO;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using BinaryBlox.SDK.Data.Context;  
using BinaryBlox.SDK.Data.Enums; 
using BinaryBlox.SDK.Data.Models.Identity; 

using Serilog;

#pragma warning disable 1591

namespace {{cookiecutter.project_api_pkg}}.DAL
{ 
    //--------------------------------------
    // MIGRATIONS
    //--------------------------------------
    // dotnet ef migrations remove -c BxApplicationDbContext
    // dotnet ef migrations add Initial{{cookiecutter.project_api_pfx}}Migration -c BxApplicationDbContext -o Migrations
    // dotnet ef database update -c BxApplicationDbContext

    //--------------------------------------
    // IMPORTANT: Requires Nuget package for custom indexatrribute
    // https://www.nuget.org/packages/Toolbelt.EntityFrameworkCore.IndexAttribute
    //--------------------------------------
  
    //***************************************
    //- FOR POST-MIGRATION
    //*************************************** 
    // public partial class BxApplicationDbContext : BxDbContext
    // {

    //     private readonly BxConfigurationIdentityDbContext _identityDbContext;

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="options"></param>
    //     /// <param name="identityDbContext"></param>
    //     public BxApplicationDbContext(DbContextOptions<BxApplicationDbContext> options, BxConfigurationIdentityDbContext identityDbContext)
    //         : base(options, EntityCaseType.SnakeCase)
    //     {

    //         // NOTE; keep to prevent lazy loading
    //         // this.Configuration.LazyLoadingEnabled = false;
    //         // this.Configuration.ProxyCreationEnabled = false; 
    //         _identityDbContext = identityDbContext;
 
    //         // ApplicationUser user = _identityDbContext.Users.First();
    //         // this.CurrentUserId = (user != null) ? user.Id : string.Empty;
    //         // _identityDbContext.CurrentUserId = this.CurrentUserId;  
    //     }
//*******************************************
// EXAMPLE CODE
//*******************************************
    //     public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxAttribAccessPriority> BxAttribAccessPriority { get; set; }
    //     public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxAttribTemplate> BxAttribTemplate { get; set; }
    //     public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxAttribValType> BxAttribValType { get; set; }
    //     public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfiguration> BxConfiguration { get; set; }
    //     public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationAccessPriority> BxConfigurationAccessPriority { get; set; }
    //     public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationAttribVal> BxConfigurationAttribVal { get; set; }
    //     public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationAttribValOverride> BxConfigurationAttribValOverride { get; set; }
    //     public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationMedia> BxConfigurationMedia { get; set; }
    //     public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationTemplate> BxConfigurationTemplate { get; set; }
    //     public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationType> BxConfigurationType { get; set; }
    //     public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxPriorityRank> BxPriorityRank { get; set; }

    // }
 
    //***************************************
    //- FOR POST-MIGRATION - END
    //*************************************** 
 
    //***************************************
    //- FOR PRE-MIGRATION
    //***************************************
    public partial class BxApplicationDbContext : DbContext
    {
        
        private readonly {{cookiecutter.project_api_pfx}}IdentityDbContext _identityDbContext; 

        public BxApplicationDbContext() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="identityDbContext"></param>
        /// <returns></returns>
        public BxApplicationDbContext(DbContextOptions<BxApplicationDbContext> options, {{cookiecutter.project_api_pfx}}IdentityDbContext identityDbContext) : base(options) { 

             _identityDbContext = identityDbContext;
            // Important; keep to prevent lazy loading
            // this.Configuration.LazyLoadingEnabled = false;
            // this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = GetContextConfiguration();
                optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("{{cookiecutter.project_api_pkg}}"));
 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);  

            // Important: Creates snake case for the Entities
            builder.AddSnakeCaseToEntities();

             // Creates identity in SQL
            System.Console.WriteLine("Creates identity in SQL");
            builder.SetDefaultValuesTableName(true);
    
//*******************************************
// EXAMPLE CODE
//*******************************************
            // // BxAttribAccessPriority
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxAttribAccessPriority>().Property(c => c.PriorityRankId).IsRequired();

            // // BxAttribTemplate
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxAttribTemplate>().Property(c => c.ConfigurationTemplateId).IsRequired();
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxAttribTemplate>().Property(c => c.AttribValueTypeId).IsRequired();

            // // BxAttribValType
            // // -NONE-

            // // BxConfiguration
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxConfiguration>().Property(c => c.ConfigurationTemplateId).IsRequired();
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxConfiguration>().Property(c => c.ConfigurationGroupId).IsRequired();
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxConfiguration>().Property(c => c.IsEnabled).IsRequired();
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxConfiguration>().Property(c => c.Name).IsRequired();

            // // BxConfiguration - Index
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxConfiguration>().HasIndex(
            //        idx => new { idx.ConfigurationTemplateId, idx.ConfigurationGroupId, idx.Name }).IsUnique(true);

            // // BxConfigurationAccessPriority
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationAccessPriority>().Property(c => c.ConfigurationId).IsRequired();
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationAccessPriority>().Property(c => c.PriorityRankId).IsRequired();

            // // BxConfigurationAttribVal
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationAttribVal>().Property(c => c.ConfigurationId).IsRequired();
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationAttribVal>().Property(c => c.AttribTemplateId).IsRequired();

            // // BxConfigurationAttribVal - Index
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationAttribVal>().HasIndex(
            //        idx => new { idx.ConfigurationId, idx.AttribTemplateId }).IsUnique(true);

            // // BxConfigurationAttribValOverride
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationAttribValOverride>().Property(c => c.ConfigurationAttribValId).IsRequired();
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationAttribValOverride>().Property(c => c.AttribAccessPriorityId).IsRequired();

            // // BxConfigurationMedia
            // // -NONE-

            // // BxConfigurationTemplate
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationTemplate>().Property(c => c.ConfigurationTypeId).IsRequired();

            // // BxConfigurationType
            // // -NONE- 

            // // BxPriorityRank
            // builder.Entity<BinaryBlox.SDK.Data.Models.Configuration.BxPriorityRank>().Property(c => c.PriorityRank).IsRequired();

           
        }

//*******************************************
// EXAMPLE CODE
//*******************************************
        // public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxAttribAccessPriority> BxAttribAccessPriority { get; set; }
        // public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxAttribTemplate> BxAttribTemplate { get; set; }
        // public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxAttribValType> BxAttribValType { get; set; }
        // public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfiguration> BxConfiguration { get; set; }
        // public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationAccessPriority> BxConfigurationAccessPriority { get; set; }
        // public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationAttribVal> BxConfigurationAttribVal { get; set; }
        // public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationAttribValOverride> BxConfigurationAttribValOverride { get; set; }
        // public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationMedia> BxConfigurationMedia { get; set; }
        // public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationTemplate> BxConfigurationTemplate { get; set; }
        // public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxConfigurationType> BxConfigurationType { get; set; }
        // public DbSet<BinaryBlox.SDK.Data.Models.Configuration.BxPriorityRank> BxPriorityRank { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected IConfigurationRoot GetContextConfiguration()
        {
            Log.Debug("Adding configuration paths...");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Production.json", optional: true)
                .AddJsonFile("appsettings.Staging.json", optional: true)
                .AddJsonFile("appsettings.QA.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();
            return configuration;
        }
    }
    //***************************************
    //- FOR PRE-MIGRATION - END
    //*************************************** 
}

#pragma warning restore 1591

 