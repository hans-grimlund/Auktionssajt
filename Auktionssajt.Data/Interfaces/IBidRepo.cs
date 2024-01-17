using Auktionssajt.Domain.Entities;

namespace Auktionssajt.Data.Interfaces
{
    public interface IBidRepo
    {
        void InsertBid(BidEntity bid);
        void DeleteBid(int id);
        List<BidEntity> GetBidsFromAuction(int id);
        List<BidEntity> GetBidsFromUser(int id);
    }
}