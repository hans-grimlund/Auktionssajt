using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Entities;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Interfaces
{
    public interface IBidService
    {
        Status PlaceBid(NewBidModel newBid, int userId);
        Status DeleteBid(int id, int userId);
        List<BidDTO> GetBids(int id);
    }
}