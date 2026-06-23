using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantShared.DTOs.Auth
{
    public class LogoutRequest
    {
        public string Username { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
