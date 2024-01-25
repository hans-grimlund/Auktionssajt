using Auktionssajt.Core.Interfaces;
using Auktionssajt.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auktionssajt.Api.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;
        private readonly IAuctionService _auctionService;

        public BidController(IBidService bidService, IAuctionService auctionService)
        {
            _bidService = bidService;
            _auctionService = auctionService;
        }

        [HttpPost]
        public IActionResult InsertBid([FromQuery]NewBidModel newBid) 
        {
            var status = _bidService.InsertBid(newBid);
            if (status == Status.Ok)
            {
            return Ok();
            }
            return BadRequest(status.ToString());
        }
        [HttpDelete]
        public IActionResult DeleteBid(int bidID)
        {
            var status = _bidService.DeleteBid(bidID);
            if (status == Status.Ok)
            {
                return Ok();
            }
            return BadRequest(status.ToString());
        }
        [HttpGet]
        public IActionResult GetBidList(int auctionID)
        {
            var bids = _bidService.GetBidList(auctionID);
            if (!bids.Any())
            {
            return Ok(bids);
            }

            return BadRequest(Status.BadRequest);
        }


    }
}