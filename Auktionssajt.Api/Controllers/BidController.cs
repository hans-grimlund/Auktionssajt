using Auktionssajt.Core.Interfaces;
using Auktionssajt.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auktionssajt.Api.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BidController(IBidService bidService, IAuctionService auctionService, IErrorhandler errorhandler) : ControllerBase
    {
        private readonly IBidService _bidService = bidService;
        private readonly IAuctionService _auctionService = auctionService;
        private readonly IErrorhandler _errorhandler = errorhandler;

        [HttpPost]
        public IActionResult PlaceBid([FromQuery]NewBidModel newBid) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var status = _bidService.PlaceBid(newBid, GetCurrentUserID());
                if (status == Status.Ok)
                    return Ok();

                return BadRequest(status.ToString());    
            }
            catch (Exception ex)
            {
                _errorhandler.LogError(ex);
                return Problem();
            }
        }

        [HttpDelete]
        public IActionResult DeleteBid([FromQuery]int bidId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var status = _bidService.DeleteBid(bidId, GetCurrentUserID());
                if (status == Status.Ok)
                    return Ok();

                return BadRequest(status.ToString());
            }
            catch (Exception ex)
            {
                _errorhandler.LogError(ex);
                return Problem();
            }
        }

        [HttpGet]
        public IActionResult GetBids([FromQuery]int auctionID)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var bids = _bidService.GetBids(auctionID);
                if (bids.Count > 0)
                    return Ok(bids);

                return BadRequest(Status.BadRequest);
            }
            catch (Exception ex)
            {
                _errorhandler.LogError(ex);
                return Problem();
            }
        }

        private int GetCurrentUserID()
        {
            var idClaim = User.FindFirst("UserID");
            if (idClaim == null)
                return 0;

            var parsed = int.TryParse(idClaim.Value, out int id);
            if (parsed)
                return id;

            return 0;
        }
    }
}