using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantShared.DTOs.Auth
{
    public class RefreshRequest
    {
        public string RefreshToken { get; set; }= null!;
        public string Username { get; set; } = null!;
    }
}
