using Auktionssajt.Domain.Entities;

namespace Auktionssajt.Core.Interfaces
{
    public interface IBidService
    {
        void InsertBid(BidEntity bid);
        void DeleteBid(int id);
        List<BidEntity> GetBidList(int id);

    }
}