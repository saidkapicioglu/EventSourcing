namespace EventSourcing.CQRS.Command;

class CreateAdCommandRequest
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
}