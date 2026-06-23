using RestaurantShared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDataAccess.InterfaceRepository
{
    public interface IRefreshTokenRepository
    {
        public Task AddNewRefreshToken(RefreshToken newRefreshToken);

        public Task<bool> isExist(string RefreshToken , int UserId);

        public Task<RefreshToken> GetRefreshToken(string RefreshToken);

    }
}
