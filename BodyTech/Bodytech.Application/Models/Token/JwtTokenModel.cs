using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bodytech.Application.Models.Token
{
    public class JwtTokenModel
    {
        public string Username { get; set; }
        public string UserId { get; set; }
        public IEnumerable<int> Roles { get; set; }
    }
}