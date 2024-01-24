using Auktionssajt.Core.Interfaces;
using Auktionssajt.Domain.Entities;
using Auktionssajt.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auktionssajt.Api.Controllers
{
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

        [Authorize]
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

    }
}