namespace EventSourcing.CQRS.Query;

class GetAllAdQueryHandler
{
    public List<GetAllAdQueryResponse> GetAll(GetAllAdQueryRequest request)
    {
        return AdSource.AdList.Select(ad => new GetAllAdQueryResponse
        {
            Id = ad.Id,
            Title = ad.Title,
            Price = ad.Price
        }).ToList();
    }
}