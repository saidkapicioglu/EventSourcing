namespace EventSourcing.CQRS.Command.Handlers;

class ChangePriceCommandHandler
{
    public ChangePriceCommandResponse Handle(ChangePriceCommandRequest request)
    {
        var ad = AdSource.AdList.FirstOrDefault(p => p.Id == request.Id);
        var oldPrice = ad.Price;
        ad.ChangePrice(request.Price);
        return new ChangePriceCommandResponse { Ad = ad, OldPrice = oldPrice };
    }
}