using Auktionssajt.Domain.Entities;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Interfaces
{
    public interface IBidService
    {
        Status InsertBid(NewBidModel newBid);
        void DeleteBid(int id);
        List<BidEntity> GetBidList(int id);

    }
}