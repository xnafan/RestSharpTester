using RestSharpTesterConsole.CustomerRestClient;
using RestSharpTesterConsole.CustomerRestClient.Model;

public class Program
{
    public static void Main()
    {
        string restUrl = "https://localhost:7288/api/customers";

        //Instantiate the client with the URL to contact
        ICustomerClient client = new CustomerRestClient(restUrl);
        
        //perform CRUD operations on the REST service using the client
        Console.WriteLine($"Getting all clients from '{restUrl}'");
        Console.WriteLine();
        foreach (var customer in client.GetCustomers())
        {
            Console.WriteLine($"- {customer}");
        }
        Console.WriteLine();

        //insert new customer
        Console.WriteLine($"Inserting Henning as new customer");
        client.InsertCustomer(new CustomerDto() { Name = "Henning", Email = "henning@gmail.com" });
        Console.WriteLine();
        
        //delete a customer using the id
        Console.WriteLine($"Deleting customer Anna using the ID 1");
        client.DeleteCustomer(1);
        Console.WriteLine();
        
        //update a customer 
        Console.WriteLine($"Updating Clara to Børge");
        client.UpdateCustomer(new CustomerDto() { Id=3, Name = "Børge", Email = "børge@gmail.com" });
        Console.WriteLine();

        //find a specific customer
        Console.WriteLine($"Finding Bob using ID 2");
        CustomerDto? bob = client.GetCustomerById(2);
        Console.WriteLine("Found: " + bob?.Name);
        Console.WriteLine();

        //search customers based on part of name and email
        Console.WriteLine($"Getting all clients having 'e' in their name and 'h' in their email address");
        foreach (var customer in client.SearchCustomers("e", "h"))
        {
            Console.WriteLine(customer.Name);
        }


        //getting all clients again, to see the changes
        Console.WriteLine($"Getting all clients from '{restUrl}'");
        foreach (var customer in client.GetCustomers())
        {
            Console.WriteLine(customer.Name);
        }
        Console.WriteLine();
        Console.WriteLine("ENTER to exit");
        Console.ReadLine();
    }
}