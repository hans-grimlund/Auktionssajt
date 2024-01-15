using Auktionssajt.Core.Interfaces;
using Auktionssajt.Data.Repository;
using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepo _userRepo = new UserRepo();

        public void DeleteUser(int id)
        {
            _userRepo.DeleteUser(id);
        }

        public List<UserDTO> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUser(int id)
        {
            _userRepo.GetUser(id);
            throw new NotImplementedException();
        }

        public UserDTO GetUser(string userName)
        {
            throw new NotImplementedException();
        }

        public void NewUser(NewUserModel user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UpdateUserModel user)
        {
            throw new NotImplementedException();
        }
    }
}