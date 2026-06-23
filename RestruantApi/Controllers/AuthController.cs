using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using RestaurantBusiness.InterfaceServices;
using RestaurantShared.DTOs.Auth;

namespace RestaurantApi.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        private readonly ILogger<AuthController> _logger;


        public AuthController(IAuthService auth , ILogger<AuthController> logger)
        {
            _auth = auth;
            _logger = logger;
        }

        [HttpPost("Login")]
        [EnableRateLimiting("AuthLimiter")]
        public async Task<ActionResult<TokenResponse>> Login([FromBody] LoginRequestDto request) 
        {

            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            var token = await _auth.Login(request);

            if(token == null)
            {
                _logger.LogWarning(
                "Failed login . Username={Username}, IP={IP}",
                request.Username,
                ip);

                return Unauthorized("Invalid credentials");
            }

            
            _logger.LogInformation(
                 "Successful login. UserId={UserId}, IP={IP}",
                 User.Identities,   
                 ip
             );

            return Ok(new { Token = token.AccessToken , RefreshToken = token.RefreshToken});
        
        }

        [HttpPost("Refresh")]
        [EnableRateLimiting("AuthLimiter")]
        public async Task<ActionResult<TokenResponse>> Refresh([FromBody] RefreshRequest refreshRequest) 
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            var token = await _auth.Refresh(refreshRequest);
            
            if(token == null)
            {
                _logger.LogWarning(
                    "Invalid refresh token attempt. Username={Username}, IP={IP}",
                    refreshRequest.Username,
                    ip
                );
                return Unauthorized("Invalid refresh request");
            }

            _logger.LogInformation(
                 "Refresh succeeded. UserId={UserId}, IP={IP}",
                 User.Identity,
                 
                 ip
             );
            return Ok(new { Token = token.AccessToken, RefreshToken = token.RefreshToken });

        }


        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(LogoutRequest request)
        {

            var isLogout = await _auth.Logout(request);

            return isLogout? Ok("Logout is successfully") : Unauthorized();

        }

    }
}
