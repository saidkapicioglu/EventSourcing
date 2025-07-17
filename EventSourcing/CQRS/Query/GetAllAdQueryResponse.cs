namespace EventSourcing.CQRS.Query;

class GetAllAdQueryResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
}