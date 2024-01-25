using Auktionssajt.Core.Interfaces;
using Auktionssajt.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auktionssajt.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuctionController(IAuctionService auctionService) : ControllerBase
    {
        private readonly IAuctionService _auctionService = auctionService;

        [HttpPost]
        public IActionResult CreateAuction(NewAuctionModel newAuction)
        {

            var status = _auctionService.CreateAuction(newAuction, GetCurrentUserID());

            if (status == Status.Ok)
            {
                return Ok();
            }
            return BadRequest(status.ToString());
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