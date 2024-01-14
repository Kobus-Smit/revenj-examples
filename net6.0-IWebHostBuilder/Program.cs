using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace AspNetTutorial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                
                //Deprecated in Serilog v5, removed in Serilog v8
                //https://github.com/serilog/serilog-aspnetcore/releases/tag/v5.0.0
                //https://github.com/serilog/serilog-aspnetcore/pull/338/files#diff-78851308a284bcd2f55cb4b79b556d6148801c57bd8c3d492684f417eef00a1f
                //.UseSerilog((_, lc) => lc.WriteTo.Console())
                
                .UseRevenj()
                    .UseRevenjServiceProvider()
                    .WithCommands()
                    .Configure("server=localhost;database=tutorial2;user=postgres;password=postgres")
                .UseStartup<Startup>();
    }
}