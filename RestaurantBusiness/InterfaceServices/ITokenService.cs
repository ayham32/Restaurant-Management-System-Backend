

using RestaurantDataAccess.Entities;

namespace RestaurantBusiness.InterfaceServices
{
    public interface ITokenService
    {

        public  Task<string> GenerateToken(User user, List<string> roles);
        public  Task<string> GenerateRefreshToken();
    }

}
