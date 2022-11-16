namespace RestSharpTesterConsole.CustomerRestClient.Model
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Customer {Id} : {Name}, email: {Email} ";
        }
    }
}