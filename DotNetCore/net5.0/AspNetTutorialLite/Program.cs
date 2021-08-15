using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AspNetTutorial
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//TODO(Default .NET Core 3.1) CreateHostBuilder(args).Build().Run();
			CreateWebHostBuilder(args).Build().Run();
		}

		//TODO(Default .NET Core 3.1) 
		//public static IHostBuilder CreateHostBuilder(string[] args) =>
		//	Host.CreateDefaultBuilder(args)
		//		//'IHostBuilder' does not contain a definition for 'UseRevenj' and the best extension method overload 'RevenjWebHostBuilderExtension.UseRevenj(IWebHostBuilder)' requires a receiver of type 'IWebHostBuilder'
		//		.UseRevenj()
		//		.ConfigureWebHostDefaults(webBuilder =>
		//		{
		//			webBuilder.UseStartup<Startup>();
		//		});
	
		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
                .UseRevenj()
                    .UseRevenjServiceProvider()
                    .WithCommands()
                    .Configure("server=localhost;database=tutorial2;user=postgres;password=postgres")
                .UseStartup<Startup>();
	}
}
