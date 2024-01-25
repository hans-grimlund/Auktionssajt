namespace Auktionssajt.Domain.Models
{
    public class NewBidModel
    {
        public decimal BidPrice { get; set; }
        public int AuctionID { get; set; }
        public int UserID { get; set; }
    }
}