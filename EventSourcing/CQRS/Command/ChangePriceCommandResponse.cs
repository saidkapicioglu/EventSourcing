namespace EventSourcing.CQRS.Command;

class ChangePriceCommandResponse
{
    public Ad Ad { get; set; }
    public decimal OldPrice { get; set; }
}