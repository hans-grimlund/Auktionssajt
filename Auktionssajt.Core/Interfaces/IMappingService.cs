using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Entities;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Interfaces
{
    public interface IMappingService
    {
        UserEntity ToUserEntity(NewUserModel model);
        UserEntity ToUserEntity(UpdateUserModel model);
        UserDTO ToUserDTO(UserEntity entity);
        List<UserDTO> ToUserDTO(List<UserEntity> entities);
        AuctionEntity ToAuctionEntity(NewAuctionModel model, int userId = 0);
        AuctionDTO ToAuctionDTO(AuctionEntity entity);
        List<AuctionDTO> ToAuctionDTO(List<AuctionEntity> entities);
        AuctionEntity ToAuctionEntity(EditAuctionModel model);
        BidEntity ToBidEntity(NewBidModel newBid);
        BidDTO ToBidDTO(BidEntity entity);
        List<BidDTO> ToBidDTO(List<BidEntity> entities);
    }
}