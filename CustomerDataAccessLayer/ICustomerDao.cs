using CustomerDataAccessLayer.Model;
namespace CustomerDataAccessLayer;
public interface ICustomerDao
{
    IEnumerable<Customer>? GetCustomers();
    IEnumerable<Customer>? SearchCustomers(string partOfName, string? partOfEmail = null);
    Customer? GetCustomerById(int id);
    bool DeleteCustomer(int id);
    bool UpdateCustomer(Customer customer);
    int InsertCustomer(Customer customer);
}