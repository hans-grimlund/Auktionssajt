using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Entities;
using Auktionssajt.Domain.Models;
using System.Data;

namespace Auktionssajt.Core.Interfaces
{
    public interface IUserService
    {
        void NewUser(NewUserModel user);
        void DeleteUser(int id);
        void UpdateUser(UpdateUserModel user);
        UserDTO GetUser(int id);
        UserDTO GetUser(string userName);
        List<UserDTO> GetAllUsers();
    }
}