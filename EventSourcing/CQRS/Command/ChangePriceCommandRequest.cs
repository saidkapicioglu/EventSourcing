namespace EventSourcing.CQRS.Command;

class ChangePriceCommandRequest
{
    public int Id { get; set; }
    public decimal Price { get; set; }
}