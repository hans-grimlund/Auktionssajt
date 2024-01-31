using Auktionssajt.Core.Interfaces;
using Auktionssajt.Data.Repository;
using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Entities;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Services
{
    public class BidService : IBidService
    {
        private readonly BidRepo _bidRepo = new();
        private readonly AuctionRepo _auctionRepo = new();
        private readonly MappingService _mappingService = new();
        private readonly UserService _userService = new();

        public Status PlaceBid(NewBidModel newBid, int userId)
        {
            var auction = _auctionRepo.GetAuction(newBid.AuctionID);
            var bids = _bidRepo.GetBidsFromAuction(newBid.AuctionID);
            if (auction.UserID == userId)
                return Status.Forbidden;
            
            if (auction.EndTime < DateTime.Now)
                return Status.Closed;

            if (bids.Count > 0 && bids.Max(b => b.BidPrice) > newBid.BidPrice)
                return Status.BidToLow;
            
            var bidEntity = _mappingService.ToBidEntity(newBid);
            bidEntity.UserId = userId;
            bidEntity.Placed = DateTime.Now;
            _bidRepo.InsertBid(bidEntity);

            return Status.Ok;
        }

        public Status DeleteBid(int id, int userId)
        {
            var user = _userService.GetUser(userId);
            var bid = _bidRepo.GetBid(id);

            if (bid == null || user == null)
                return Status.NotFound;

            var auction = _auctionRepo.GetAuction(bid.AuctionId);
            if (auction.EndTime < DateTime.Now)
                return Status.Closed;
            
            if (bid.UserId != userId)
                return Status.Unauthorized;
            
            _bidRepo.DeleteBid(id);
            return Status.Ok;
        }

        public List<BidDTO> GetBids(int id)
        {
            var bids = _bidRepo.GetBidsFromAuction(id);
            if (bids.Count < 1)
                return null!;
                
            return _mappingService.ToBidDTO(bids);
        }
    }
}