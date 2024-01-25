using Auktionssajt.Domain.Entities;

namespace Auktionssajt.Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken (UserEntity user);


    }
}
