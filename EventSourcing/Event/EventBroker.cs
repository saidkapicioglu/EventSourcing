using EventSourcing.CQRS.Command;
using EventSourcing.CQRS.Command.Handlers;
using EventSourcing.CQRS.Query;

namespace EventSourcing.Event;

class EventBroker
{
    public List<IEvent> AllEvents = new();

    public event EventHandler<object> Commands;
    public event EventHandler<object> Queries;

    public EventBroker()
    {
        this.Commands += (sender, command) =>
        {
            if (command is CreateAdCommandRequest createReq)
            {
                var handler = new CreateAdCommandHandler();
                var response = handler.Handle(createReq);
                AllEvents.Add(new AdCreatedEvent(response.Ad));
            }
            else if (command is ChangePriceCommandRequest priceReq)
            {
                var handler = new ChangePriceCommandHandler();
                var response = handler.Handle(priceReq);
                AllEvents.Add(new PriceChangedEvent(response.Ad, response.OldPrice, priceReq.Price));
            }
        };

        this.Queries += (sender, query) =>
        {
            if (query is GetAllAdQueryRequest)
            {
                var handler = new GetAllAdQueryHandler();
                var result = handler.GetAll(new GetAllAdQueryRequest());
                Console.WriteLine("ID\tTitle\t\t\tPrice");
                foreach (var ad in result)
                    Console.WriteLine($"{ad.Id}\t{ad.Title}\t\t{ad.Price}₺");
                Console.WriteLine("***********");
            }
            else if (query is GetAdQueryRequest req)
            {
                var handler = new GetAdQueryHandler();
                var result = handler.GetAd(req);
                Console.WriteLine($"ID: {result.Ad.Id}, Title: {result.Ad.Title}, Price: {result.Ad.Price}₺");
                Console.WriteLine("***********");
            }
        };
    }

    public void Command(object command) => Commands(this, command);
    public void Query(object query) => Queries(this, query);
    public void WriteAllEvents() => AllEvents.ForEach(e => Console.WriteLine($"{e}\n***********"));
}
