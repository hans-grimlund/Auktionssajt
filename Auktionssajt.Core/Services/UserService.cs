using Auktionssajt.Core.Interfaces;
using Auktionssajt.Data.Repository;
using Auktionssajt.Domain.DTOs;
using Auktionssajt.Domain.Entities;
using Auktionssajt.Domain.Models;
using Auktionssajt.Core.Services; // Make sure to include this namespace for MappingService
using System.Collections.Generic;

namespace Auktionssajt.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly MappingService _mappingService;

        public UserService(IUserRepo userRepo, MappingService mappingService)
        {
            _userRepo = userRepo;
            _mappingService = mappingService;
        }

        public void DeleteUser(int id)
        {
            _userRepo.DeleteUser(id);
        }

        public List<UserDTO> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public UserDTO GetUser(int id)
        {
            var entity = _userRepo.GetUser(id);
            return _mappingService.UserEntityToUserDTO(entity);
        }

        public UserDTO GetUser(string userName)
        {
            var entity = _userRepo.GetUser(userName);
            return _mappingService.UserEntityToUserDTO(entity);
        }

        public void NewUser(NewUserModel user)
        {
            // Förutsatt att vi har en mappningsmetod för att konvertera NewUserModel till UserEntity vilket vi inte har än.
            var entity = _mappingService.NewUserModelToUserEntity(user);
            _userRepo.NewUser(entity);
        }

        public void UpdateUser(UpdateUserModel user)
        {
            // samma sak här fast konvertera UpdateUserModel till UserEntity vilket vi inte heller har klart än
            var entity = _mappingService.UpdateUserModelToUserEntity(user);
            _userRepo.UpdateUser(entity);
        }
    }
}
