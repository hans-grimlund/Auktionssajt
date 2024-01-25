using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Interfaces
{
    public interface IAuctionService
    {
        Status CreateAuction(NewAuctionModel auction, int userId);
        Status EditAuction(EditAuctionModel auction, int userId);
        Status CloseAuction(int auctionId, int userId);
        AuctionDTO GetAuction(int id);
        List<AuctionDTO> GetAllAuctions();
        List<AuctionDTO> FindAuction(string searchterm);
        List<AuctionDTO> GetAuctionsFromUser(int id);
    }
}