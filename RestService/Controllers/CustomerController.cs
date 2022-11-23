using CustomerDataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using RestService.ConversionTools;
using RestService.Model;

namespace RestService.Controllers;

[Route("api/v1/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    ICustomerDao _customerDao;
    public CustomerController(ICustomerDao customerDao) => _customerDao = customerDao;

    [HttpGet]
    public ActionResult<IEnumerable<CustomerDto>?> Get()
    {
        return Ok(_customerDao.GetCustomers()?.ToDtos());
    }

    [HttpGet("{id}")]
    public ActionResult<CustomerDto?> Get(int id)
    {
        var customer = _customerDao.GetCustomerById(id);
        if(customer == null) { return NotFound(); }
        return Ok(customer.ToDto());
    }

    //https://localhost:7288/api/v1/customers/search?partOfName=e&partOfEmail=h'
    [HttpGet("search")]
    public ActionResult<IEnumerable<CustomerDto>?> SearchCustomers(
        [FromQuery] string partOfName, 
        [FromQuery] string? partOfEmail = null)
    {
        return Ok(_customerDao.SearchCustomers(partOfName, partOfEmail)?.ToDtos());
    }


    [HttpPost]
    public IActionResult Post([FromBody] CustomerDto customer)
    {
        _customerDao.InsertCustomer(customer.FromDto());
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] CustomerDto customerToUpdate)
    {
        var customer = customerToUpdate.FromDto();
        var customerFoundAndUpdated =_customerDao.UpdateCustomer(customer);
        if(!customerFoundAndUpdated) { return NotFound();}
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        if(!_customerDao.DeleteCustomer(id)) { return NotFound(); }
        return Ok();
    }
}