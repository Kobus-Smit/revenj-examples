using Revenj.DomainPatterns;
using Revenj.Extensibility;
using tutorial;

namespace AspNetTutorial.Customers
{
	public interface ICustomerService
	{
		Customer Lookup(string id);
	}

	[Service(InstanceScope.Context)]
	public class CustomerService : ICustomerService
	{
		private readonly IDataContext context;

		public CustomerService(IDataContext context)
		{
			this.context = context;
		}

		public Customer Lookup(string id)
		{
			return context.Find<Customer>(id);
		}
	}
}
