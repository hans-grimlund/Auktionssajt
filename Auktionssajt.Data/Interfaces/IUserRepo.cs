using Auktionssajt.Domain.Entities;

namespace Auktionssajt.Data.Interfaces
{
    public interface IUserRepo
    {
        void NewUser(UserEntity user);
        void DeleteUser(int id);
        void UpdateUser(UserEntity user);
        UserEntity GetUser(int id);
        UserEntity GetUser(string username);
        List<UserEntity> GetAllUsers();
    }
}
