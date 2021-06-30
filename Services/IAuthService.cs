using System.Threading.Tasks;
using dotnet_rpg.Dtos.Charater;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(NewUserDto newUser);
        Task<ServiceResponse<string>> Login(LoginDto loginModel);
        Task<ServiceResponse<bool>> UserExists(string UserName);
    }
}