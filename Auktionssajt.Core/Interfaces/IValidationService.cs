using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Interfaces
{
    public interface IValidationService
    {
        Status ValidateNewUser(NewUserModel user);
        Status ValidatePassword(string password);
        Status ValidateNewAuction(NewAuctionModel auction);
        Status ValidateNewAuction(AuctionDTO auction);
    }
}