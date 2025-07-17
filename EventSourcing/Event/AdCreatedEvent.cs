namespace EventSourcing.Event;

class AdCreatedEvent : IEvent
{
    public Ad Ad;
    public AdCreatedEvent(Ad ad) => Ad = ad;

    public override string ToString()
        => $"Yeni ilan oluşturuldu → {Ad.Id}: {Ad.Title}, Fiyat: {Ad.Price}";
}