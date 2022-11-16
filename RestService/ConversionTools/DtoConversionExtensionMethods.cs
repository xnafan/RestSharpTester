using CustomerDataAccessLayer.Model;
using RestService.Model;

namespace RestService.ConversionTools;
public static class DtoConversionExtensionMethods
{
    public static IEnumerable<CustomerDto> ToDtos(this IEnumerable<Customer> customers)
    {
        foreach (var customer in customers)
        {
            yield return customer.ToDto();
        }
    }

    public static CustomerDto ToDto(this Customer customer)
    {
        return customer.CopyPropertiesTo(new CustomerDto());
    }

    public static IEnumerable<Customer> FromDtos(this IEnumerable<CustomerDto> customerDtos)
    {
        foreach (var customer in customerDtos)
        {
            yield return customer.FromDto();
        }
    }

    public static Customer FromDto(this CustomerDto customerDto)
    {
        return customerDto.CopyPropertiesTo(new Customer());
    }
}