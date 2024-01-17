using System.Data.SqlTypes;

namespace Auktionssajt.Domain.Models
{
    public class NewBidModel
    {
        public decimal BidPrice { get; set; }
        public int UserId { get; set; }
    }
}