using Auktionssajt.Domain.Entities;

namespace Auktionssajt.Data.Interfaces
{
    public interface IBidRepo
    {
        void InsertBid(BidEntity bid);
        void DeleteBid(int id);
        List<BidEntity> GetBids(int id);
    }
}