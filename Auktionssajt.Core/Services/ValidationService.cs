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
            if (auction.Title.IsNullOrEmpty() || auction.StartingPrice < 0)
            {
                return Status.Invalid;
            }
            return Status.Ok;
        }

        public Status ValidateAuction(NewAuctionModel auction)
        {
            if (auction.Title.IsNullOrEmpty() || auction.StartingPrice < 0)
            {
                return Status.Invalid;
            }
            return Status.Ok;
        }

        public Status ValidateAuction(AuctionDTO auction)
        {
            if (auction.Title.IsNullOrEmpty())
            {
                return Status.NotFound;
            }
            return Status.Ok;
        }

        public Status ValidateUser(NewUserModel user)
        {
            if (user.UserPsw.IsNullOrEmpty() || user.UserName.IsNullOrEmpty())
            {
                return Status.Invalid;
            }
            return Status.Ok;
        }

        public Status ValidateUser(UpdateUserModel user)
        {
            if (user.UserID >= 0)
            {
                return Status.Unauthorized;
            }
            return Status.Ok;
        }

        public Status ValidatePassword(string password)
        {
            if (password == null)
            {
                return Status.Unauthorized;
            }
            return Status.Ok;
        }
    }
}