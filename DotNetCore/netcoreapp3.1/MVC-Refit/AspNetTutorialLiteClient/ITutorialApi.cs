using System.Threading.Tasks;
using Refit;
using tutorial;

namespace ConsoleApp1
{
    public interface ITutorialApi
    {
        [Get("/weatherforecast")]
        Task<Customer> GetWeatherForecastIndex();        
    }
}