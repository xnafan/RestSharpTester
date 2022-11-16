namespace CustomerDataAccessLayer.Model;
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Email { get; set; }
    public bool IsReliable { get; set; }
}