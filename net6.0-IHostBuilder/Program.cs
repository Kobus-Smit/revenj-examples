using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace AspNetTutorial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // webBuilder.UseRevenj()
                    //     .UseRevenjServiceProvider()
                    //     .Configure("server=localhost;database=tutorial2;user=postgres;password=postgres");
                    //
                    // The above throws exception:
                    // System.NotSupportedException: Requested type not found in services: Revenj.Extensibility.IObjectFactory
                    //     Use GetService API to avoid this exception and get null value instead.
                    //     Check if service should be registered or it's dependencies satisfied
                    // at Revenj.DomainPatterns.ServiceProviderHelper.Resolve[T](IServiceProvider provider) in Revenj.Core.Interface\DomainPatterns\ServiceLocator.cs:line 22

                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog((_, lc) => lc.WriteTo.Console())
                .UseRevenj()
                    .UseRevenjServiceProvider()
                    .WithCommands()
                    .ConfigureHostBuilder("server=localhost;database=tutorial2;user=postgres;password=postgres");
        }
    }
}