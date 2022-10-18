using RestSharp;
using RestSharpTesterConsole.CustomerClient.Model;

namespace RestSharpTesterConsole.CustomerClient
{
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
        public void DeleteCustomer(int id)
        {
            //sends a DELETE request to "api/customers/{id}"
            var request = new RestRequest($"{id}", Method.Delete);
            _client.Delete<Customer>(request);
        }

        public Customer? GetCustomerById(int id)
        {
            //sends a GET request to "api/customers/{id}"
            var request = new RestRequest($"{id}");
            return _client.Get<Customer>(request);
        }

        public IEnumerable<Customer>? GetCustomers()
        {
            //sends a GET request to "api/customers"
            return _client.Get<IEnumerable<Customer>>(new RestRequest());
        }

        public void InsertCustomer(Customer customer)
        {
            //sends a POST request to "api/customers"
            //with the Customer as a JSON object in body
            var request = new RestRequest("", Method.Post);
            request.AddBody(customer);
            _client.Post<Customer>(request);
        }

        public void UpdateCustomer(Customer customer)
        {
            //sends a PUT request to "api/customers"
            //with the Customer as a JSON object in body
            var request = new RestRequest($"{customer.Id}");
            request.AddBody(customer);
            _client.Put<Customer>(request);
        }
    }
}
