
namespace Auktionssajt.Domain.Models
{
    public class NewAuctionModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal StartingPrice { get; set; }

        public NewAuctionModel()
        {
            Title ??= string.Empty;
            Description ??= string.Empty;
        }

        public NewAuctionModel(string title, string description, decimal startingPrice)
        {
            Title = title ?? string.Empty;
            Description = description ?? string.Empty;
            StartingPrice = startingPrice;
        }
    }
}