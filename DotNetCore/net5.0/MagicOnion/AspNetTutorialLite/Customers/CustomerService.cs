using MagicOnion;
using MagicOnion.Server;
using Revenj.DomainPatterns;
using Revenj.Extensibility;
using tutorial;

namespace AspNetTutorial.Customers
{
    [Service(InstanceScope.Context)]
	public class CustomerService : ServiceBase<ICustomerService>, ICustomerService
	{
		private readonly IDataContext context;

		public CustomerService(IDataContext context)
		{
			this.context = context;
		}

		public async UnaryResult<Customer> Lookup(string id)
        {
            return context.Find<Customer>(id);
        }
    }
}
