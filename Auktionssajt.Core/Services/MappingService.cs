using Auktionssajt.Core.Interfaces;
using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Entities;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Services
{
    public class MappingService : IMappingService
    {
        public AuctionEntity AuctionDTOToAuctionEntity(AuctionDTO DTO)
        {
            return new AuctionEntity()
            {
                Id = DTO.Id,
                Title = DTO.Title,
                Description = DTO.Description,
                User = 1,
                StartDate = DTO.StartDate,
                EndDate = DTO.EndDate
            };
        }

        public List<AuctionEntity> AuctionDTOToAuctionEntity(List<AuctionDTO> DTOs)
        {
            List<AuctionEntity> entities = [];
            foreach (var DTO in DTOs)
            {
                entities.Add(AuctionDTOToAuctionEntity(DTO));
            }
            return entities;
        }

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

        public AuctionEntity EditAuctionModelToAuctionEntity(EditAuctionModel model)
        {
            return new AuctionEntity()
            {
                // TODO Code this
            };
        }

        public AuctionEntity NewAuctionModelToAuctionEntity(NewAuctionModel model, int userId = 0)
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