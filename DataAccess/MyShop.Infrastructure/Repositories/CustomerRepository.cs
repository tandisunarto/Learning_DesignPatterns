using System.Linq;
using MyShop.Domain.Models;
using MyShop.Infrastructure;

public class CustomerRepository : BaseRepository<Customer>
{
	private ShoppingContext context;

	public CustomerRepository(ShoppingContext context) : base(context) => this.context = context;

	public override Customer Update(Customer entity)
	{
		var customer = context.Customers
			.Single(c => c.CustomerId == entity.CustomerId);

		customer.Name = entity.Name;
		customer.City = entity.City;
		customer.PostalCode = entity.PostalCode;
		customer.ShippingAddress = entity.ShippingAddress;
		customer.Country = entity.Country;

		return base.Update(customer);
	}
}