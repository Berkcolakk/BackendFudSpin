using FudSpin.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Services.TokenServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
