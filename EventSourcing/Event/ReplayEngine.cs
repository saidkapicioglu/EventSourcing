using EventSourcing.CQRS.Command;

namespace EventSourcing.Event;

public class ReplayEngine
{
    public List<Ad> Replay(List<IEvent> events)
    {
        var rebuiltAds = new List<Ad>();
        var broker = new EventBroker();

        foreach (var e in events)
        {
            switch (e)
            {
                case AdCreatedEvent created:
                    broker.Command(new CreateAdCommandRequest
                        { Id = created.Ad.Id, Title = created.Ad.Title, Price = created.Ad.Price });
                    break;

                case PriceChangedEvent priceChanged:
                    var _event = (PriceChangedEvent)e;
                    if (_event != null)
                        broker.Command(new ChangePriceCommandRequest { Id = _event.Ad.Id, Price = _event.NewPrice });
                    break;
            }
        }

        return rebuiltAds;
    }
}