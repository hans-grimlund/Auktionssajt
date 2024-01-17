using Auktionssajt.Core.Interfaces;
using Auktionssajt.Data.Interfaces;
using Auktionssajt.Data.Repository;
using Auktionssajt.Domain.Entities;

namespace Auktionssajt.Core.Services
{
    public class BidService : IBidService
    {
        private readonly BidRepo _bidRepo = new BidRepo();
        public void DeleteBid(int id)
        {
            _bidRepo.DeleteBid(id);
        }

        public List<BidEntity> GetBidList(int id)
        {
            var bids = _bidRepo.GetBids(id);
            return bids;
        }

        public void InsertBid(BidEntity bid)
        {
            _bidRepo.InsertBid(bid);
        }
    }
}