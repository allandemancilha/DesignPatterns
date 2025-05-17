public class Costumer
{
    public string? Name { get; set; }
    public Address Address { get; set; }

    public Costumer()
    {
        Address = new Address();
    }  
}
