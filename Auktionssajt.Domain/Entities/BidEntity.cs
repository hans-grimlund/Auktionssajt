namespace Auktionssajt.Domain.Entities
{
    public class BidEntity
    {
        public int BidId { get; set; }
        public decimal BidPrice { get; set; }
        public DateTime BidDateTime { get; set; }
        public int AuctionId { get; set; }
        public int UserId { get; set; }

        public BidEntity(int bidId, decimal bidPrice, int auctionId, DateTime? bidDateTime = null)
        {
            BidId = bidId;
            BidPrice = bidPrice;
            BidDateTime = bidDateTime ?? DateTime.MinValue;
            AuctionId = auctionId;
        }
    }
}