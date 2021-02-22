using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using System.IO;
using Serilog.Exceptions;

namespace CalculatorService.Server
{
    public class Program
    {
        public static IConfiguration Configuration { get; private set; }

        public static void Main(string[] args)
        {

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
                .AddCommandLine(args)
                .AddEnvironmentVariables()
                .Build();

            // Configure serilog
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .CreateLogger();

            Log.Information("Starting.");

            CreateHostBuilder(args).Build().Run();

            Log.Information("End.");
            Log.CloseAndFlush();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseConfiguration(Configuration)
                    .UseSerilog();

                });
    }
}
