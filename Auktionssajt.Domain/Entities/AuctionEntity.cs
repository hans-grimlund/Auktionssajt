namespace Auktionssajt.Domain.Entities
{
    public class AuctionEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Category { get; set; }
        public int User { get; set; }
    }
}