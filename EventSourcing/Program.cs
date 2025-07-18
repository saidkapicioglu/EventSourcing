using EventSourcing;
using EventSourcing.CQRS.Command;
using EventSourcing.CQRS.Query;
using EventSourcing.Event;

class Program
{
    static void Main(string[] args)
    {
        var broker = new EventBroker();

        broker.Command(new CreateAdCommandRequest { Id = 4, Title = "PS5 Sıfır", Price = 25000 });
        broker.Command(new ChangePriceCommandRequest { Id = 2, Price = 36000 });
        broker.Command(new ChangePriceCommandRequest { Id = 2, Price = 37000 });

        broker.Query(new GetAllAdQueryRequest());
        broker.Query(new GetAdQueryRequest { Id = 2 });

        broker.WriteAllEvents();
        
        // Clear ad list for replay events
        Console.WriteLine($"----------------------------------------------------------");
        var clearList = AdSource.ClearList;
        AdSource.AdList.ForEach(e => Console.WriteLine($"{e}\n***********"));
        Console.WriteLine($"----------------------------------------------------------");

        // Replay the events
        var replayer = new ReplayEngine();
        var currentAds = replayer.Replay(broker.AllEvents);

        // Display the rebuilt ads after replaying events
        AdSource.AdList.ForEach(e => Console.WriteLine($"{e}\n***********"));
    }
}
