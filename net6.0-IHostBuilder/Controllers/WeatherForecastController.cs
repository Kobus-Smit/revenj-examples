using AspNetTutorial.Customers;
using Microsoft.AspNetCore.Mvc;
using tutorial;

namespace AspNetTutorial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        private readonly ICustomerService customerService;

        public WeatherForecastController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public Customer Index()
        {
            return customerService.Lookup("b7e5a8bfd7864c0");
        }
    }
}