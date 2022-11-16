using RestSharp;
using RestSharpTesterConsole.CustomerRestClient.Model;

namespace RestSharpTesterConsole.CustomerRestClient;

/// <summary>
/// This class implements the ICustomerClient and allows for CRUD on a REST service
/// which is located at the URL provided in the constructor
/// NOTE: this class hasn't implemented checks for errors in communication
/// </summary>
public class CustomerRestClient : ICustomerClient
{
    RestClient _client;

    public CustomerRestClient(string restUrl)
    {
        //instantiates and saves the RestSharp client
        //for use in the CRUD methods
        _client = new RestClient(restUrl);
    }
    public bool DeleteCustomer(int id)
    {
        //sends a DELETE request to "api/customers/{id}"
        //and returns the returnvalue
        var request = new RestRequest($"{id}", Method.Delete);
        return _client.Delete<bool>(request);
    }

    public CustomerDto? GetCustomerById(int id)
    {
        //sends a GET request to "api/customers/{id}"
        var request = new RestRequest($"{id}");
        return _client.Get<CustomerDto>(request);
    }

    public IEnumerable<CustomerDto>? GetCustomers()
    {
        //sends a GET request to "api/customers"
        return _client.Get<IEnumerable<CustomerDto>>(new RestRequest());
    }

    public IEnumerable<CustomerDto>? SearchCustomers(string partOfName, string? partOfEmail = null)
    {
        var request = new RestRequest("search?partOfName={partOfName}&partOfEmail={partOfEmail}")
           .AddUrlSegment("partOfName", partOfName)
           .AddUrlSegment("partOfEmail", partOfEmail ?? "");
        return _client.Get<IEnumerable<CustomerDto>>(request);
    }

    public int InsertCustomer(CustomerDto customer)
    {
        //sends a POST request to "api/customers"
        //with the Customer as a JSON object in body
        //and returns the primary of the inserted customer
        var request = new RestRequest("", Method.Post);
        request.AddBody(customer);
        return _client.Post<int>(request);
    }

    public bool UpdateCustomer(CustomerDto customer)
    {
        //sends a PUT request to "api/customers"
        //with the Customer as a JSON object in body
        //and returns whether the customer was found on the server
        var request = new RestRequest($"{customer.Id}");
        request.AddBody(customer);
        return _client.Put<bool>(request);
    }
}
