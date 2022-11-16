using CustomerDataAccessLayer.Model;

namespace CustomerDataAccessLayer;
public class CustomerDao : ICustomerDao
{
    //a list of customers which we make static to save them on the class
    //and make them persistent between calls to the controller
    //this is to simulate a storage medium like a database
    private static List<Customer> _customers = new List<Customer>() { 
        new Customer() { Id = 1, Name = "Anna", Email = "Anna@gmail.com" }, 
        new Customer() { Id = 2, Name = "Bob", Email = "Bob@hotmail.com" }, 
        new Customer() { Id = 3, Name = "Clara", Email = "Clara@gmail.com" },
        new Customer() { Id = 4, Name = "Dennis", Email = "Dennis@syncmail.com" },
        new Customer() { Id = 5, Name = "Erica", Email = "Erica@protonmail.com" },
        new Customer() { Id = 6, Name = "Ferdinand", Email = "Ferdinand@ubermail.org" },
        new Customer() { Id = 7, Name = "Greta", Email = "Greta@ubermailsavetheplanet.org" },
        new Customer() { Id = 8, Name = "Hubert", Email = "Hubert@ubermail.org" },
        new Customer() { Id = 9, Name = "Ingrid", Email = "Ingrid@geek.it" },
        new Customer() { Id = 10, Name = "James", Email = "James@hotmail.com" },

    };
    public IEnumerable<Customer>? GetCustomers() => _customers;
    public bool DeleteCustomer(int id) => _customers.RemoveAll(customer => customer.Id == id) > 0;
    public Customer? GetCustomerById(int id) => _customers.FirstOrDefault(customer => customer.Id == id);

    public int InsertCustomer(Customer customer)
    {
        customer.Id = _customers.Max(customer => customer.Id) + 1;
        _customers.Add(customer);
        return customer.Id;
    }

    public IEnumerable<Customer>? SearchCustomers(string partOfName, string? partOfEmail = null)
    {
        var customersWithPartOfName = _customers.Where(customer => customer.Name.Contains(partOfName, StringComparison.InvariantCultureIgnoreCase));
        if (partOfEmail == null) { return customersWithPartOfName; } 
            
        return customersWithPartOfName.Where(customer =>customer.Email != null && customer.Email.Contains(partOfEmail, StringComparison.InvariantCultureIgnoreCase));
    }

    public bool UpdateCustomer(Customer customerToUpdate)
    {
        var customerFound = DeleteCustomer(customerToUpdate.Id) ;
        _customers.Add(customerToUpdate);
        return customerFound;
    }
}