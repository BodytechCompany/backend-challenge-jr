using Bodytech.Application.Models.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodytech.Application.Services.Jwt
{
    public interface IJwtService
    {
        string CreateToken(int userId, string username, IEnumerable<int> roles);
        bool ValidateToken(string token);
        JwtTokenModel ReadToken(string token);
    }
}
