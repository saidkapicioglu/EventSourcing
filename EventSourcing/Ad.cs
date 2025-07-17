namespace EventSourcing;

record Ad
{
    public int Id { get; init; }
    public string Title { get; private set; }
    public decimal Price { get; private set; }

    public Ad(int id, string title, decimal price)
    {
        Id = id;
        Title = title;
        Price = price;
    }

    public void ChangePrice(decimal price)
        => Price = price;
}

class AdSource
{
    public static List<Ad> AdList { get; } = new()
    {
        new(1, "iPhone 13", 22000),
        new(2, "Macbook Air M2", 34000),
        new(3, "Samsung TV", 18000),
    };
}
