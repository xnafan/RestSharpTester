using RestSharpTesterConsole.CustomerClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTesterConsole.CustomerClient
{
    public interface ICustomerClient
    {
        IEnumerable<Customer>? GetCustomers();
        Customer? GetCustomerById(int id);
        void DeleteCustomer(int id);
        void UpdateCustomer(Customer customer);
        void InsertCustomer(Customer customer);
    }
}
