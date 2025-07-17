namespace EventSourcing.CQRS.Command.Handlers;

class CreateAdCommandHandler
{
    public CreateAdCommandResponse Handle(CreateAdCommandRequest request)
    {
        var ad = new Ad(request.Id, request.Title, request.Price);
        AdSource.AdList.Add(ad);
        return new CreateAdCommandResponse { Ad = ad };
    }
}