using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Entities;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Interfaces
{
    public interface IMappingService
    {
        UserEntity NewUserModelToUserEntity(NewUserModel model);
        UserDTO UserEntityToUserDTO(UserEntity entity);
        List<UserDTO> UserEntityToUserDTO(List<UserEntity> entities);
        AuctionEntity NewAuctionModelToAuctionEntity(NewAuctionModel model);
        AuctionDTO AuctionEntityToAuctionDTO(AuctionEntity entity);
        List<AuctionDTO> AuctionEntityToAuctionDTO(List<AuctionEntity> entities);
    }
}