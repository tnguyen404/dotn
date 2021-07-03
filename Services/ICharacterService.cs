using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Charater;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAll(int userID);
        Task<ServiceResponse<GetCharacterDto>> GetCharatecById(int id);
        Task<ServiceResponse<newCharacterDto>> AddNewCharacter(AddCharacterDto newCharacter);

        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto characterUpdate);

        Task<ServiceResponse<GetCharacterDto>> DeleteCharacter(int id);
    }
}