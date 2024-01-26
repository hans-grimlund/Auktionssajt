namespace Auktionssajt.Domain.Models
{
    public enum Status
    {
        None,
        Ok,
        NotFound,
        Unauthorized,
        BadRequest,
        Forbidden,
        BidToLow,
        Closed,
        Error,
        Invalid
    }
}