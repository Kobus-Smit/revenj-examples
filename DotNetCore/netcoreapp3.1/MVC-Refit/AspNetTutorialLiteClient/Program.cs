using System;
using System.Threading.Tasks;
using Refit;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var api = RestService.For<ITutorialApi>("https://localhost:44363");
            var customer = await api.GetWeatherForecastIndex();
            Console.WriteLine(customer.name);
            Console.ReadKey();
        }
    }
}
