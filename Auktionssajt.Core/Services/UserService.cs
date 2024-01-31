using Auktionssajt.Core.Interfaces;
using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Models;
using Auktionssajt.Data.Repository;
using Auktionssajt.Domain;

namespace Auktionssajt.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepo _userRepo = new();
        private readonly MappingService _mappingService = new();
        private readonly ValidationService _validationService = new();
        private readonly TokenService _tokenService = new();

        public LoginResponse Login(LoginRequestModel request)
        {
            var user = _userRepo.GetUser(request.Username);
            if (user == null)
                return new(status: Status.NotFound);
            
            if (!BCrypt.Net.BCrypt.EnhancedVerify(request.Password, user.UserPsw))
                return new(status: Status.Unauthorized);

            var token = _tokenService.GenerateToken(user);

            return new(Status.Ok, token);
        }

        public Status NewUser(NewUserModel user)
        {
            var status = _validationService.ValidateUser(user);
            if (status != Status.Ok)
                return status;

            user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Password);

            var entity = _mappingService.ToUserEntity(user);
            _userRepo.NewUser(entity);

            return Status.Ok;
        }

        public Status UpdateUser(UpdateUserModel model, int userId)
        {
            var user = _userRepo.GetUser(userId);
            if (user == null)
                return Status.NotFound;
            
            if (user.UserID != userId)
                return Status.Unauthorized;    
                
            var status = _validationService.ValidatePassword(model.NewPassword);
            if (status != Status.Ok)
                return status;
            
            var entity = _mappingService.ToUserEntity(model);
            _userRepo.UpdateUser(entity);

            return Status.Ok;
        }

        public Status DeleteUser(int id, int userId)
        {
            var user = _userRepo.GetUser(id);
            if (user == null)
                return Status.NotFound;
            
            if (user.UserID != userId)
                return Status.Unauthorized;
            
            _userRepo.DeleteUser(id);
            return Status.Ok;
        }

        public List<UserDTO> GetAllUsers()
        {
            var entities = _userRepo.GetAllUsers();
            if (entities.Count < 1)
                return null!;

            return _mappingService.ToUserDTO(entities);
        }

        public UserDTO GetUser(int id)
        {
            var entity = _userRepo.GetUser(id);
            if (entity == null)
                return null!;
            
            return _mappingService.ToUserDTO(entity);
        }
    }
}
