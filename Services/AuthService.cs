using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Charater;
using dotnet_rpg.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Services
{
    public class AuthService : IAuthService
    {
        public AuthService(DataContext context)
        {
            _context = context;
        }

        public DataContext _context { get; private set; }
        public IMapper _mapper { get; private set; }

        public async Task<ServiceResponse<string>> Login(LoginDto loginModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(loginModel.UserName));
            if (user == null)
            {
                return new ServiceResponse<string> { data = "wrong user name", success = false };
            }
            else
            {
                if (VerifyPasswordHash(loginModel.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return new ServiceResponse<string> { data = "Login successfull", success = true };
                }
                else
                {
                    return new ServiceResponse<string> { data = "invalid paswword", success = false };
                }
            }
        }

        public async Task<ServiceResponse<int>> Register(NewUserDto newUser)
        {

            if ((await UserExists(newUser.Username)).data)
            {
                var newUserModel = CreatePasswordHash(new User { Username = newUser.Username }, newUser.password);
                _context.Users.Add(newUserModel);

                await _context.SaveChangesAsync();

                return new ServiceResponse<int> { data = newUserModel.Id, success = true };
            }
            else
            {
                return new ServiceResponse<int> { data = -1, success = false, message = $"{newUser.Username} aleady exists" };
            }

        }

        public async Task<ServiceResponse<bool>> UserExists(string UserName)
        => new ServiceResponse<bool>
        {
            data = (await _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(UserName))) == null,
            success = true
        };

        private User CreatePasswordHash(User newUser, string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                newUser.PasswordSalt = hmac.Key;
                newUser.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            return newUser;

        }

        private bool VerifyPasswordHash(string password, byte[] pwHash, byte[] pwSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(pwSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != pwHash[i])
                    {
                        return false;
                    }
                    return true;
                }

            }
            return false;
        }
    }
}