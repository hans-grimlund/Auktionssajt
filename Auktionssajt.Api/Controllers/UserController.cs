using Auktionssajt.Core.Interfaces;
using Auktionssajt.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auktionssajt.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController(IErrorhandler errorhandler, IUserService userService) : ControllerBase
    {
        private readonly IErrorhandler _errorhandler = errorhandler;
        private readonly IUserService _userService = userService;

        [AllowAnonymous]
        [HttpPost]
        public IActionResult NewUser([FromBody]NewUserModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                
            try
            {
                var status = _userService.NewUser(user);
                if (status == Status.Ok)
                    return Ok();
                
                return BadRequest(status);
            }
            catch (Exception ex)
            {
                _errorhandler.LogError(ex);
                return Problem();
            }
        }

        [HttpPatch]
        public IActionResult UpdateUser([FromQuery]UpdateUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                
            try
            {
                var status = _userService.UpdateUser(model, GetCurrentUserID());
                if (status == Status.Ok)
                    return Ok();
                
                return BadRequest(status);
            }
            catch (Exception ex)
            {
                _errorhandler.LogError(ex);
                return Problem();
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser([FromQuery]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                
            try
            {
                var status = _userService.DeleteUser(id, GetCurrentUserID());
                if (status == Status.Ok)
                    return Ok();
                
                return BadRequest(status);
            }
            catch (Exception ex)
            {
                _errorhandler.LogError(ex);
                return Problem();
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAllUsers()
        {       
            try
            {
                var users = _userService.GetAllUsers();
                if (users != null)
                    return Ok(users);
                
                return NotFound();
            }
            catch (Exception ex)
            {
                _errorhandler.LogError(ex);
                return Problem();
            }
        }

        [HttpGet]
        public IActionResult GetUser([FromQuery]int id)
        {       
            try
            {
                var user = _userService.GetUser(id);
                if (user != null)
                    return Ok(user);
                
                return NotFound();
            }
            catch (Exception ex)
            {
                _errorhandler.LogError(ex);
                return Problem();
            }
        }

        [HttpGet("username")]
        public IActionResult GetUserFromUsername([FromQuery]string username)
        {       
            try
            {
                var user = _userService.GetUser(username);
                if (user != null)
                    return Ok(user);
                
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