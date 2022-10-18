using Microsoft.AspNetCore.Mvc;

namespace RestService.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //a list of customers which we make static to save them on the class
        //and make them persistent between calls to the controller
        //this is to simulate a storage medium like a database
        private static List<Customer> customers = new List<Customer>() { new Customer() { Id = 1, Name = "Anna", Email = "Anna@gmail.com" }, new Customer() { Id = 2, Name = "Bob", Email = "Bob@gmail.com" }, new Customer() { Id = 3, Name = "Clara", Email = "Clara@gmail.com" }
    };
    [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer?> Get(int id)
        {
            Customer? customer = customers.FirstOrDefault(customer => customer.Id == id);
            if(customer == null) { return NotFound(); }
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Customer customer)
        {
            customers.Add(customer);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customer updateCustomer)
        {
            Customer? customer = customers.FirstOrDefault(customer => customer.Id == updateCustomer.Id);
            if(customer == null) { return NotFound();}
            customer.Name = updateCustomer.Name;
            customer.Email = updateCustomer.Email;
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(customers.RemoveAll(customer => customer.Id == id) > 0) { return Ok(); }
            return NotFound();
        }
    }
}