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

        public Status CloseAuction(int id)
        {
            throw new NotImplementedException();
        }

        public Status CreateAuction(NewAuctionModel auction, int userId)
        {
            var status = _validationService.ValidateNewAuction(auction);
            if ( status != Status.Ok)
                return status;
            
            var entity = _mappingService.NewAuctionModelToAuctionEntity(auction, userId);
            _auctionRepo.NewAuction(entity);

            return Status.Ok;
        }

        public Status EditAuction(AuctionDTO auction, int userId)
        {
            var oldAuction = _auctionRepo.GetAuction(auction.Id);
            if (oldAuction == null)
                return Status.NotFound;
            
            if (oldAuction.User != userId)
                return Status.Unauthorized;

            if (oldAuction.Status == "Ended")
                return Status.Unauthorized;
            
            if (_bidRepo.GetBidsFromAuction(auction.Id).Count > 0)
                return Status.Unauthorized;

            var status = _validationService.ValidateNewAuction(auction);
            if (status != Status.Ok)
                return status;
            
            _auctionRepo.EditAuction(_mappingService.AuctionDTOToAuctionEntity(auction));
            return Status.Ok;
        }

        public AuctionDTO GetAuction(int id)
        {
            var auction = _auctionRepo.GetAuction(id);
            if (auction == null)
                return new();
            return _mappingService.AuctionEntityToAuctionDTO(auction);
        }

        public List<AuctionDTO> FindAuction(string searchterm)
        {
            if (searchterm == null)
                return [];
            
            var entities = _auctionRepo.FindAuction(searchterm);
            if (entities.Count < 1)
                return [];
            return _mappingService.AuctionEntityToAuctionDTO(entities);
        }

        public List<AuctionDTO> GetAllAuctions()
        {
            var entities = _auctionRepo.GetAllAuctions();
            if (entities.Count < 1)
                return [];
            return _mappingService.AuctionEntityToAuctionDTO(entities);
        }

        public List<AuctionDTO> GetAuctionsFromUser(int id)
        {
            var entities = _auctionRepo.GetAuctionsFromUser(id);
            if (entities.Count < 1)
                return [];
            return _mappingService.AuctionEntityToAuctionDTO(entities);
        }
    }
}