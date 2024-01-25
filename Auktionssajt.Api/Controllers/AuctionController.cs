using Auktionssajt.Core.Interfaces;
using Auktionssajt.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auktionssajt.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuctionController(IAuctionService auctionService, IErrorhandler errorhandler) : ControllerBase
    {
        private readonly IAuctionService _auctionService = auctionService;
        private readonly IErrorhandler _errorhandler = errorhandler;

        [HttpPost]
        public IActionResult CreateAuction(NewAuctionModel newAuction)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var status = _auctionService.CreateAuction(newAuction, GetCurrentUserID());
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
        public IActionResult GetAuction([FromQuery]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            try
            {
                var auction = _auctionService.GetAuction(id);
                if (auction != null)
                    return Ok(auction);
                
                return NotFound();
            }
            catch (Exception ex)
            {
                _errorhandler.LogError(ex);
                return Problem();
            }
        }

        [HttpPut]
        public IActionResult EditAuction([FromQuery]EditAuctionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var status = _auctionService.EditAuction(model, GetCurrentUserID());
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

        [HttpPatch]
        public IActionResult CloseAuction([FromQuery]int auctionId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var status = _auctionService.CloseAuction(auctionId, GetCurrentUserID());
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

        public IActionResult GetAllAuctions()
        {
            try
            {
                var auctions = _auctionService.GetAllAuctions();
                if (auctions != null)
                    return Ok(auctions);

                return NotFound();
            }
            catch (Exception ex)
            {
                _errorhandler.LogError(ex);
                return Problem();
            }
        }

        public IActionResult FindAuction([FromQuery]string searchterm)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var auctions = _auctionService.FindAuction(searchterm);
                if (auctions != null)
                    return Ok(auctions);

                return NotFound();
            }
            catch (Exception ex)
            {
                _errorhandler.LogError(ex);
                return Problem();
            }
        }

        public IActionResult GetAuctionsFromUser([FromQuery]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var auctions = _auctionService.GetAuctionsFromUser(id);
                if (auctions != null)
                    return Ok(auctions);

                return NotFound();
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