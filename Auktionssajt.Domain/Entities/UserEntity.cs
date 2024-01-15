using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auktionssajt.Domain.Entities
{
    public class UserEntity
    {
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserPsw { get; set; } = string.Empty;
    }
}
