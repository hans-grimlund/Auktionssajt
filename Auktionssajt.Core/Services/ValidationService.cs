using Auktionssajt.Core.Interfaces;
using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Services
{
    public class ValidationService : IValidationService
    {
        public Status ValidateNewAuction(NewAuctionModel auction)
        {
            return Status.Ok;
        }

        public Status ValidateNewAuction(AuctionDTO auction)
        {
            return Status.Ok;
        }

        public Status ValidateNewUser(NewUserModel user)
        {
            return Status.Ok;
        }

        public Status ValidatePassword(string password)
        {
            return Status.Ok;
        }
    }
}