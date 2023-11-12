namespace SqlApp.Models;

public class Product
{
    public int ProductID { get; set; }

    public string ProductName { get; set; } = String.Empty;

    public int Quantity { get; set; }
}
