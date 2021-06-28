using dotnet_rpg.Models;

namespace dotnet_rpg.Dtos.Charater
{
    public class UpdateCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; } 
        public int Defensive { get; set; }
        public int Intelligence { get; set; }
        public RpgClass CharacterClass { get; set; }
    }
}