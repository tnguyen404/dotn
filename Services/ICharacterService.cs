using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetAll();
        Task<ServiceResponse<Character>> GetCharatecById(int id);
        Task<ServiceResponse<List<Character>>> AddNewCharacter(Character newCharacter);

    }
}