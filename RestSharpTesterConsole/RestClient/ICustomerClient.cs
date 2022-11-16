using RestSharpTesterConsole.CustomerRestClient.Model;

namespace RestSharpTesterConsole.CustomerRestClient;
public interface ICustomerClient
{
    IEnumerable<CustomerDto>? GetCustomers();
    IEnumerable<CustomerDto>? SearchCustomers(string partOfName, string? partOfEmail = null);
    CustomerDto? GetCustomerById(int id);
    bool DeleteCustomer(int id);
    bool UpdateCustomer(CustomerDto customer);
    int InsertCustomer(CustomerDto customer);
}