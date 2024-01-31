using Auktionssajt.Core.Interfaces;
using Auktionssajt.Data.Repository;
using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Entities;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Services
{
    public class MappingService : IMappingService 
    {
        private readonly UserRepo _userRepo = new();

        public AuctionDTO ToAuctionDTO(AuctionEntity entity)
        {
            return new()
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Username = _userRepo.GetUser(entity.UserID).UserName,
                StartingPrice = entity.StartingPrice,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime
            };
        }

        public List<AuctionDTO> ToAuctionDTO(List<AuctionEntity> entities)
        {
            List<AuctionDTO> DTOs = [];
            foreach (var entity in entities)
            {
                DTOs.Add(ToAuctionDTO(entity));
            }
            return DTOs;
        }

        public AuctionEntity ToAuctionEntity(EditAuctionModel model)
        {
            return new()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                StartingPrice = model.StartingPrice
            };
        }

        public AuctionEntity ToAuctionEntity(NewAuctionModel model, int userId = 0)
        {
            return new()
            {
                Title = model.Title,
                Description = model.Description,
                UserID = userId,
                StartingPrice = model.StartingPrice
            };
        }

        public BidEntity ToBidEntity(NewBidModel newBid)
        {
            return new BidEntity(0, newBid.BidPrice, auctionId: newBid.AuctionID);
           
        }

        public UserEntity ToUserEntity(NewUserModel model)
        {
            return new()
            {
                UserName = model.Username,
                UserPsw = model.Password
            };
        }

        public UserDTO ToUserDTO(UserEntity entity)
        {
            return new()
            {
                UserID = entity.UserID,
                UserName = entity.UserName
            };
        }

        public List<UserDTO> ToUserDTO(List<UserEntity> entities)
        {
            List<UserDTO> DTOs = [];
            foreach (var entity in entities)
            {
                DTOs.Add(ToUserDTO(entity));
            }
            return DTOs;
        }

        public BidDTO ToBidDTO(BidEntity entity)
        {
            return new()
            {
                BidId = entity.BidId,
                UserName = _userRepo.GetUser(entity.UserId).UserName,
                BidPrice = entity.BidPrice,
                Placed = entity.Placed,
                AuctionId = entity.AuctionId
            };
        }

        public List<BidDTO> ToBidDTO(List<BidEntity> entities)
        {
            List<BidDTO> DTOs = [];
            foreach (var entity in entities)
            {
                DTOs.Add(ToBidDTO(entity));
            }
            return DTOs;
        }

        public UserEntity ToUserEntity(UpdateUserModel model)
        {
            return new()
            {
                UserPsw = model.NewPassword
            };
        }
    }
}