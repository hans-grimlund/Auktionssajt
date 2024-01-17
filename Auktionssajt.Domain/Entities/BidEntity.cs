using System.Data.SqlTypes;

namespace Auktionssajt.Domain.Entities
{
    public class BidEntity
    {
        public int BidId { get; set; }
        public decimal BidPrice { get; set; }
        public DateTime BidDateTime { get; set; }
        public int AuctionId { get; set; }
        public int UserId { get; set; }

        public BidEntity(int bidId, decimal bidPrice, DateTime bidDateTime, int auctionId)
        {
            BidId = bidId;
            BidPrice = bidPrice;
            BidDateTime = bidDateTime;
            AuctionId = auctionId;
        }
    }
}