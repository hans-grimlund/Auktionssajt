namespace Auktionssajt.Domain.DTOs
{
    public class BidDTO
    {
        public int BidId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public decimal BidPrice { get; set; }
        public DateTime BidDateTime { get; set; }
        public int AuctionId { get; set; }
    }
}