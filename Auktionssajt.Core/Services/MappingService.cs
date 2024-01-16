using Auktionssajt.Core.Interfaces;
using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Entities;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Services
{
    public class MappingService : IMappingService
    {
        public AuctionDTO AuctionEntityToAuctionDTO(AuctionEntity entity)
        {
            return new AuctionDTO()
            {
                // TODO Code this
            };
        }

        public List<AuctionDTO> AuctionEntityToAuctionDTO(List<AuctionEntity> entities)
        {
            List<AuctionDTO> DTOs = [];
            foreach (var entity in entities)
            {
                DTOs.Add(AuctionEntityToAuctionDTO(entity));
            }
            return DTOs;
        }

        public AuctionEntity NewAuctionModelToAuctionEntity(NewAuctionModel model)
        {
            return new AuctionEntity()
            {
                // TODO Code this
            };
        }

        public UserEntity NewUserModelToUserEntity(NewUserModel model)
        {
            return new UserEntity()
            {
                // TODO Code this
            };
        }

        public UserDTO UserEntityToUserDTO(UserEntity entity)
        {
            return new UserDTO()
            {
                // TODO Code this
            };
        }

        public List<UserDTO> UserEntityToUserDTO(List<UserEntity> entities)
        {
            List<UserDTO> DTOs = [];
            foreach (var entity in entities)
            {
                DTOs.Add(UserEntityToUserDTO(entity));
            }
            return DTOs;
        }
    }
}