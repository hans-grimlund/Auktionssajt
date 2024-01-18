namespace Auktionssajt.Domain.Models
{
    public class NewAuctionModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal StartingPrice { get; set; }
    }
}