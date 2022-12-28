using RentalHouseManagement.Entities.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalHouseManagement.Services.TokenServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
