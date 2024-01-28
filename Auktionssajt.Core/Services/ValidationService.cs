using Auktionssajt.Core.Interfaces;
using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace Auktionssajt.Core.Services
{
    public class ValidationService : IValidationService
    {
        public Status ValidateAuction(EditAuctionModel auction)
        {
            if (auction.Title.IsNullOrEmpty())
                return Status.Invalid;

            if (auction.StartingPrice < 0)
                return Status.Invalid;
            
            if (auction.Description.IsNullOrEmpty())
                return Status.Invalid;
            return Status.Ok;
        }

        public Status ValidateAuction(NewAuctionModel auction)
        {
            if (auction.Title.IsNullOrEmpty())
                return Status.Invalid;

            if (auction.StartingPrice < 0)
                return Status.Invalid;
            
            if (auction.Description.IsNullOrEmpty())
                return Status.Invalid;
            return Status.Ok;
        }

        public Status ValidateUser(NewUserModel user)
        {
            if (user.Username.IsNullOrEmpty() || user.Password.IsNullOrEmpty())
                return Status.Invalid;

            return Status.Ok;
        }

        public Status ValidatePassword(string password)
        {
            if (password.IsNullOrEmpty())
                return Status.Invalid;
                
            return Status.Ok;
        }
    }
}