namespace RestService.Model;
public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public override string ToString() => Name + " - " + Email;
}