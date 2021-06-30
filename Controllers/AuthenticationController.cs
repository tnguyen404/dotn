using System.Threading.Tasks;
using dotnet_rpg.Dtos.Charater;
using dotnet_rpg.Models;
using dotnet_rpg.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        public IAuthService _authService { get; private set; }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(NewUserDto newUser)
                => Ok(await _authService.Register(newUser));

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(LoginDto loginModel)
               => Ok(await _authService.Login(loginModel));



    }
}