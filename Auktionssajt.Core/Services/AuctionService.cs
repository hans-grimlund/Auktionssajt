using Auktionssajt.Core.Interfaces;
using Auktionssajt.Data.Repository;
using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly ValidationService _validationService = new();
        private readonly MappingService _mappingService = new();
        private readonly AuctionRepo _auctionRepo = new();
        private readonly BidRepo _bidRepo = new();


        public Status CreateAuction(NewAuctionModel auction, int userId)
        {
            var status = _validationService.ValidateAuction(auction);
            if (status != Status.Ok)
                return status;
            
            var entity = _mappingService.ToAuctionEntity(auction, userId);
            entity.EndTime = DateTime.Now.AddDays(7);

            _auctionRepo.NewAuction(entity);
            return Status.Ok;
        }

        public Status EditAuction(EditAuctionModel auction, int userId)
        {
            var oldAuction = _auctionRepo.GetAuction(auction.Id);
            if (oldAuction == null)
                return Status.NotFound;
            
            if (oldAuction.UserID != userId)
                return Status.Unauthorized;

            if (DateTime.Now > oldAuction.EndTime)
                return Status.BadRequest;
            
            if (_bidRepo.GetBidsFromAuction(auction.Id).Count > 0)
                auction.StartingPrice = oldAuction.StartingPrice;

            var status = _validationService.ValidateAuction(auction);
            if (status != Status.Ok)
                return status;
            
            _auctionRepo.EditAuction(_mappingService.ToAuctionEntity(auction));
            return Status.Ok;
        }

        public Status CloseAuction(int auctionId, int userId)
        {
            var auction = _auctionRepo.GetAuction(auctionId);
            if (auction == null)
                return Status.NotFound;

            if (auction.UserID != userId)
                return Status.Unauthorized;
            
            if (DateTime.Now > auction.EndTime)
                return Status.BadRequest;

            if (_bidRepo.GetBidsFromAuction(auctionId).Count > 0)
                return Status.Forbidden;

            _auctionRepo.CloseAuction(auctionId);
            return Status.Ok;
        }

        public AuctionDTO GetAuction(int id)
        {
            var auction = _auctionRepo.GetAuction(id);
            if (auction == null)
                return null!;
            return _mappingService.ToAuctionDTO(auction);
        }

        public List<AuctionDTO> FindAuction(string searchterm)
        {
            if (searchterm == null)
                return null!;
            
            var entities = _auctionRepo.FindAuction(searchterm);
            if (entities.Count < 1)
                return null!;
            return _mappingService.ToAuctionDTO(entities);
        }

        public List<AuctionDTO> GetAllAuctions()
        {
            var entities = _auctionRepo.GetAllAuctions();
            if (entities.Count < 1)
                return null!;
            return _mappingService.ToAuctionDTO(entities);
        }

        public List<AuctionDTO> GetAuctionsFromUser(int id)
        {
            var entities = _auctionRepo.GetAuctionsFromUser(id);
            if (entities.Count < 1)
                return null!;
            return _mappingService.ToAuctionDTO(entities);
        }
    }
}