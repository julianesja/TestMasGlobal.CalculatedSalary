using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestMasGlobal.CalculatedSalary.Infra.Data.Seeders;

namespace TestMasGlobal.CalculatedSalary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            RunSeeding(host);
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                 .UseStartup<Startup>();

        private static void RunSeeding(IWebHost host)
        {
            List<ISeeder> seedDbs = new List<ISeeder>();
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var userSeed = scope.ServiceProvider.GetService<UserSeeder>();
                userSeed.ExecuteSeederAsync().Wait();
            }
        }
    }
}

