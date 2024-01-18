namespace Auktionssajt.Domain.Models
{
    public class EditAuctionModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime EndDate { get; set; }
    }
}