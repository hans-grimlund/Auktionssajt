using Auktionssajt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auktionssajt.Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken (UserEntity user);


    }
}
