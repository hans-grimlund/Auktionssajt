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
        public AuctionEntity AuctionDTOToAuctionEntity(AuctionDTO DTO)
        {
            return new AuctionEntity()
            {
                Id = DTO.Id,
                Title = DTO.Title,
                Description = DTO.Description,
                UserId = _userRepo.GetUser(DTO.Username).UserID,
                StartingPrice = DTO.StartingPrice,
                StartTime = DTO.StartTime,
                EndTime = DTO.EndTime
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
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Username = _userRepo.GetUser(entity.UserId).UserName,
                StartingPrice = entity.StartingPrice,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime
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
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                StartingPrice = model.StartingPrice
            };
        }

        public AuctionEntity NewAuctionModelToAuctionEntity(NewAuctionModel model, int userId = 0)
        {
            return new AuctionEntity()
            {
                Title = model.Title,
                Description = model.Description,
                UserId = userId,
                StartingPrice = model.StartingPrice
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