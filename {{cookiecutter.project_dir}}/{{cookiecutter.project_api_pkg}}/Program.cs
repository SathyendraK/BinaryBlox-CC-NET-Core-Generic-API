using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Hosting;

using BinaryBlox.SDK.Utils;

namespace {{cookiecutter.project_api_pkg}}
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        private static readonly Dictionary<string, string> defaults =
        new Dictionary<string, string> {
            { HostDefaults.EnvironmentKey, "development" }
        };
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {   
            const string appTitle = "{{cookiecutter.project_api_pkg}}";
            Console.Title = appTitle;
          
            CoreUtilities.CreateDefaultBinaryBloxBuilder(appTitle,
            null,
            defaults,
            args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); 
                })
            .Build()
            .Run();
        }
    } 
}