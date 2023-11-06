
using UzbekCuisines.Domain.Entities.Customers;

namespace UzbekCuisines.Domain.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(CustomerId id);
}
