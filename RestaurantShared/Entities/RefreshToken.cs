using RestaurantDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantShared.Entities
{
    public class RefreshToken
    {
        public int RefreshTokenId { get; set; }
        public string RefreshTokenHash { get; set; } = null!;
        public DateTime RefreshTokenExpiresAt { get; set; } 
        public DateTime? RefreshTokenRevokedAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

    }
}
