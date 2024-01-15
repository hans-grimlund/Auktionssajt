using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Interfaces
{
    public interface IUserService
    {
        void NewAuction(NewAuctionModel newAuction);
        void DeleteAuction(int id);
    }
}