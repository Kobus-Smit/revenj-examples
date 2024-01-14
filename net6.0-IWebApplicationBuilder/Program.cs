using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Host.UseSerilog();
builder.Host.UseRevenj()
    .UseRevenjServiceProvider()
    .WithCommands()
    .ConfigureHostBuilder("server=localhost;database=tutorial2;user=postgres;password=postgres");

var app = builder.Build();
app.UseRevenjMiddleware(); //Revenj built-in middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();