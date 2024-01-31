namespace Auktionssajt.Domain.Entities
{
    public class BidEntity
    {
        public int BidId { get; set; }
        public decimal BidPrice { get; set; }
        public int AuctionId { get; set; }
        public int UserId { get; set; }
        public DateTime Placed { get; set; }

        public BidEntity(int bidId, decimal bidPrice, int auctionId, int userId = 0, DateTime? Placed = null)
        {
            BidId = bidId;
            BidPrice = bidPrice;
            AuctionId = auctionId;
            UserId = userId;
            Placed = Placed ?? DateTime.MinValue;
        }
        public BidEntity()
        {
            
        }
    }
}