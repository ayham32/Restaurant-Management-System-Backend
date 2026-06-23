using Microsoft.EntityFrameworkCore;
using RestaurantDataAccess.Data;
using RestaurantDataAccess.InterfaceRepository;
using RestaurantShared.Entities;
using RestuarantDataAccess.UintOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDataAccess.Repository
{
    public class RefreshTokenRepository: IRefreshTokenRepository
    {
        private readonly RestaurantDbContext _context;

        public RefreshTokenRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task AddNewRefreshToken(RefreshToken newRefreshToken)
            => await _context.RefreshTokens.AddAsync(newRefreshToken);

        public async Task<bool> isExist(string RefreshToken, int UserId)
            => await _context.RefreshTokens.AnyAsync(rt => rt.UserId == UserId && rt.RefreshTokenHash == RefreshToken);

        public async Task<RefreshToken> GetRefreshToken(string RefreshToken)
            =>await _context.RefreshTokens.SingleOrDefaultAsync(rt => rt.RefreshTokenHash == RefreshToken);
    }
}
