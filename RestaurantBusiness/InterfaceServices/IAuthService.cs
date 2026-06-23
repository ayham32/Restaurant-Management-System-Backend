
using RestaurantShared.DTOs.Auth;

namespace RestaurantBusiness.InterfaceServices
{
    public interface IAuthService
    {
        public Task<TokenResponse> Login(LoginRequestDto request);

        public Task<TokenResponse> Refresh(RefreshRequest refreshRequest);

        public Task<bool> Logout(LogoutRequest request);
    }
}
