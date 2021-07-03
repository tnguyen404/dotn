using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Charater;
using dotnet_rpg.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Services
{
    public class CharacterService : ICharacterService
    {
        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private static List<Character> Characters = new List<Character>{
            new Character(),
            new Character{ Id = 1 ,Name = "Sam"}
        };

        private IMapper _mapper { get; }
        public DataContext _context { get; private set; }

        public async Task<ServiceResponse<newCharacterDto>> AddNewCharacter(AddCharacterDto newCharacter)
        {   
            var newDBCharacter = _mapper.Map<Character>(newCharacter);
           _context.Characters.Add(newDBCharacter);
           
            await _context.SaveChangesAsync();
            return new ServiceResponse<newCharacterDto> { data = _mapper.Map<newCharacterDto>(newDBCharacter), success = true };
        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAll(int userID)
        => new ServiceResponse<List<GetCharacterDto>> { data = _mapper.Map<List<GetCharacterDto>>(
            await _context.Characters.AsNoTracking().Where(c => c.user.Id.Equals(userID)).ToListAsync()), success = true };

        public async Task<ServiceResponse<GetCharacterDto>> GetCharatecById(int id)
        => new ServiceResponse<GetCharacterDto> 
        { 
            data =  _mapper.Map<GetCharacterDto>(await _context.Characters.FirstOrDefaultAsync(c => c.Id.Equals(id))), 
            success = true 
        };

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto characterUpdate)
        {
            var updateCharacterModel = _mapper.Map<Character>(characterUpdate);
           
            _context.Characters.Attach(updateCharacterModel);

            _context.Entry(updateCharacterModel).State = EntityState.Modified;
           
            await _context.SaveChangesAsync(); 

           return new ServiceResponse<GetCharacterDto> { data = _mapper.Map<GetCharacterDto>(updateCharacterModel), success = true };
        }

        public Task<ServiceResponse<GetCharacterDto>> DeleteCharacter(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}