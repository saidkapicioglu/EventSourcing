namespace EventSourcing.Event;

class PriceChangedEvent : IEvent
{
    public Ad Ad;
    public decimal OldPrice;
    public decimal NewPrice;

    public PriceChangedEvent(Ad ad, decimal oldPrice, decimal newPrice)
    {
        Ad = ad;
        OldPrice = oldPrice;
        NewPrice = newPrice;
    }

    public override string ToString()
        => $"İlan {Ad.Id} fiyatı değişti: {OldPrice}₺ → {NewPrice}₺";
}