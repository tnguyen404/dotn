using AutoMapper;
using dotnet_rpg.Dtos.Charater;
using dotnet_rpg.Models;

namespace dotnet_rpg
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Character, GetCharacterDto>().ReverseMap();
            CreateMap<Character, AddCharacterDto>().ReverseMap();
            CreateMap<Character, newCharacterDto>().ReverseMap();
            
        }
    }
}