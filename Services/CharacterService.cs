using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services
{
    public class CharacterService : ICharacterService
    {
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<Character> Characters = new List<Character>{
            new Character(),
            new Character{ Id = 1 ,Name = "Sam"}
        };

        private IMapper _mapper { get; }

        public async Task<ServiceResponse<List<Character>>> AddNewCharacter(Character newCharacter)
        {
            Characters.Add(newCharacter);
            return new ServiceResponse<List<Character>> { data = Characters, success = true };
        }


        public async Task<ServiceResponse<List<Character>>> GetAll()
        => new ServiceResponse<List<Character>> { data = Characters, success = true };

        public async Task<ServiceResponse<Character>> GetCharatecById(int id)
        => new ServiceResponse<Character> { data = Characters.FirstOrDefault(c => c.Id.Equals(id)), success = true };
    }
}