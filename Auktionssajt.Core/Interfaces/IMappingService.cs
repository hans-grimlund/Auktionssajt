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
        AuctionEntity NewAuctionModelToAuctionEntity(NewAuctionModel model, int userId = 0);
        AuctionDTO AuctionEntityToAuctionDTO(AuctionEntity entity);
        List<AuctionDTO> AuctionEntityToAuctionDTO(List<AuctionEntity> entities);
        AuctionEntity AuctionDTOToAuctionEntity(AuctionDTO DTO);
        List<AuctionEntity> AuctionDTOToAuctionEntity(List<AuctionDTO> DTOs);
        AuctionEntity EditAuctionModelToAuctionEntity(EditAuctionModel model);
        UserEntity UpdateUserModelToUserEntity(UpdateUserModel model);
    }
}