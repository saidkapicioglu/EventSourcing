namespace EventSourcing.CQRS.Query;

class GetAdQueryHandler
{
    public GetAdQueryResponse GetAd(GetAdQueryRequest request)
    {
        var ad = AdSource.AdList.FirstOrDefault(p => p.Id == request.Id);
        return new GetAdQueryResponse { Ad = ad };
    }
}