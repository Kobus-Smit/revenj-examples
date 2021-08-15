using MagicOnion;
using tutorial;

namespace AspNetTutorial.Customers
{
    public interface ICustomerService: IService<ICustomerService>
    {
        UnaryResult<Customer> Lookup(string id); 
    }
}