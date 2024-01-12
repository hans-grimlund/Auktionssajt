using Auktionssajt.Domain.Entities;
namespace Auktionssajt.Data.Interfaces
{
    public interface IAuctionRepo
    {
        void NewAuction(AuctionEntity auction);
        void EditAuction(AuctionEntity auction);
        void DeleteAuction(int id);
        AuctionEntity GetAuction(int id);
        List<AuctionEntity> GetAllAuctions();
        List<AuctionEntity> GetAuctionsFromUser(int id);
        List<AuctionEntity> GetAuctionsFromUser(string username);
    }
}