using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Interfaces
{
    public interface IValidationService
    {
        Status ValidateNewUser(NewUserModel user);
        Status ValidateNewAuction(NewAuctionModel auction);
    }
}